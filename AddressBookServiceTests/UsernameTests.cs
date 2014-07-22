using System.Net;
using AddressBookDataStore.Exceptions;
using AddressBookDomain.Model;
using AddressBookServiceGateway.Contracts;
using AddressBookServiceGateway.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockAddressBookDataStore;

namespace AddressBookServiceTests
{
    [TestClass]
    public class UsernameTests
    {
        private AddressBookService _addressBookService;

        [TestMethod]
        public void UserWithValidUserNameAndValidPassword_CanGetTheUser()
        {
            var user = GetNewUser();

            var getUserResponse =
                _addressBookService.GetUser(new GetUserRequest {UserCredential = user.UserCredential});

            Assert.IsNotNull(getUserResponse.User);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateUserNameException))]
        public void AddingOtherUserWithTheSameUserName_ShouldThrowDuplicateUserNameException()
        {
            GetNewUser();
            GetNewUserWithTheSameUserNameAsBefore();
        }
        
        [TestInitialize]
        public void Initialize()
        {
            _addressBookService = new AddressBookService(new MockAddressBookRepository());
        }

        private User GetNewUser()
        {
            var user = new User
            {
                UserCredential = new NetworkCredential {UserName = "ValidUserName", Password = "ValidPassword"}
            };

            _addressBookService.SaveUser(new SaveUserRequest {User = user});
            return user;
        }

        private void GetNewUserWithTheSameUserNameAsBefore()
        {
            GetNewUser();
        }
    }
}