using System.Net;
using AddressBookDomain.Model;
using AddressBookServiceGateway.Contracts;
using AddressBookServiceGateway.Implementation;
using AddressBookServiceGateway.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockAddressBookDataStore;

namespace AddressBookServiceTests
{
    [TestClass]
    public class UserLoginTests
    {
        private const string Username = "Username";
        private const string Validpassword = "ValidPassword";
        private const string Invalidpassword = "InValidPassword";
        private AddressBookService _addressBookService;
        private ILoginResponse _loginResponse;

        [TestMethod]
        public void UserWithInValidPassword_CannotLogin()
        {
            WhenUserLogsinWith(Invalidpassword);
            Assert.IsFalse(_loginResponse.IsLoggedIn);
        }

        [TestMethod]
        public void UserWithValidPassword_CanLogin()
        {
            WhenUserLogsinWith(Validpassword);
            Assert.IsTrue(_loginResponse.IsLoggedIn);
        }

        [TestInitialize]
        public void Initialize()
        {
            _addressBookService = new AddressBookService(new MockAddressBookRepository());
            var user = new User
            {
                UserCredential = new NetworkCredential {UserName = Username, Password = Validpassword}
            };

            _addressBookService.SaveUser(new SaveUserRequest {User = user});
        }


        private void WhenUserLogsinWith(string password)
        {
            _loginResponse =
                _addressBookService.Login(new LoginRequest
                {
                    UserCredential = new NetworkCredential {UserName = Username, Password = password}
                });
        }
    }
}