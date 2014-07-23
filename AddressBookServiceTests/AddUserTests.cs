using AddressBookDataStore.Exceptions;
using AddressBookDomain.Model.Interfaces;
using AddressBookServiceGateway.Contracts;
using AddressBookServiceGateway.Implementation;
using AddressBookServiceGateway.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockAddressBookDataStore;

namespace AddressBookServiceTests
{
    [TestClass]
    public class AddUserTests
    {
        private IAddressBookService _addressBookService;
        private IUser _user;

        [TestMethod]
        public void UserWithValidUserNameAndValidPasswordCanGetTheUser()
        {
            IGetUserResponse getUserResponse =
                _addressBookService.GetUser(new GetUserRequest {UserCredential = _user.UserCredential});

            Assert.IsNotNull(getUserResponse.User);
        }

        [TestMethod]
        [ExpectedException(typeof (DuplicateUserNameException))]
        public void AddingOtherUserWithTheSameUserNameShouldThrowDuplicateUserNameException()
        {
            GetNewUserWithTheSameUserNameAsBefore();
        }

        [TestInitialize]
        public void Initialize()
        {
            _addressBookService = new AddressBookService(new MockAddressBookRepository());
            _user = GetNewUser();
        }

        private IUser GetNewUser()
        {
            return MockUser.AddTestableUser(_addressBookService, "ValidUserName", "ValidPassword");
        }

        private void GetNewUserWithTheSameUserNameAsBefore()
        {
            GetNewUser();
        }
    }
}