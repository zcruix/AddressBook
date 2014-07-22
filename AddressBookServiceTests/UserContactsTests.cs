using System.Collections.Generic;
using System.Linq;
using System.Net;
using AddressBookDataStore.Interfaces;
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
            const string username = "Username";
            const string validpassword = "ValidPassword";

            IAddressBookRepository addressBookRepository = new MockAddressBookRepository();
            _addressBookService = new AddressBookService(addressBookRepository);

            _loggedInUser = MockUser.LoggedInTestableUser(_addressBookService, username, validpassword);            

            _addressBookService.SaveContacts(new SaveContactRequest { Contacts = MockUser.UserContacts(_loggedInUser) });
        }
    }
}