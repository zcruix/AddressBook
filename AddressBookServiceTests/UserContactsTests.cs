using System.Collections.Generic;
using System.Linq;
using System.Net;
using AddressBookDomain.Model;
using AddressBookDomain.Model.Interfaces;
using AddressBookServiceGateway.Contracts;
using AddressBookServiceGateway.Implementation;
using AddressBookServiceGateway.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockAddressBookDataStore;

namespace AddressBookServiceTests
{
    [TestClass]
    public class UserContactsTests
    {
        private IAddressBookService _addressBookService;
        private IUser _loggedInUser;
        private IGetContactsResponse _getContactsResponse;

        [TestMethod]
        public void ForALoggedInUser_GetHisContacts()
        {
            _getContactsResponse = _addressBookService.GetContacts(new GetContactsRequest {User = _loggedInUser});
            Assert.IsTrue(_getContactsResponse.Contacts.Any());
        }


        [TestInitialize]
        public void Initialize()
        {
            _addressBookService = new AddressBookService(new MockAddressBookRepository());
            _loggedInUser = new User
            {
                UserCredential = GetUserCredentials()
            };

            _addressBookService.SaveUser(new SaveUserRequest {User = _loggedInUser});

            _addressBookService.Login(new LoginRequest
            {
                UserCredential = GetUserCredentials()
            });

            _addressBookService.SaveContacts(new SaveContactRequest { Contacts = UserContacts(_loggedInUser) });

        }

        private static List<IContact> UserContacts(IUser user)
        {
            var contacts = new List<IContact> {new Contact {UserName = user.UserCredential.UserName, Addresses = new List<IAddress>(), Emails = new List<IEmail>()}};

            return contacts;
        }

        private static NetworkCredential GetUserCredentials()
        {
            const string username = "Username";
            const string validpassword = "ValidPassword";

            return new NetworkCredential { UserName = username, Password = validpassword };
        }
    }
}