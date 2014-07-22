using AddressBookDataStore.Interfaces;
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
        private IAddressBookService _addressBookService;
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
            IAddressBookRepository addressBookRepository = new MockAddressBookRepository();
            _addressBookService = new AddressBookService(addressBookRepository);
            MockUser.AddTestableUser(_addressBookService, Username, Validpassword);
        }

        private void WhenUserLogsinWith(string password)
        {
            _loginResponse =
                _addressBookService.Login(new LoginRequest
                {
                    UserCredential = MockUser.GetTestableUserCredentials(Username, password)
                });
        }
    }
}