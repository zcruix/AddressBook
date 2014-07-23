using System.Collections.Generic;
using System.Linq;
using AddressBookDomain.Model.Interfaces;
using AddressBookServiceGateway.Contracts;
using AddressBookServiceGateway.Implementation;
using AddressBookServiceGateway.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockAddressBookDataStore;

namespace AddressBookServiceTests
{
    [TestClass]
    public class AddContactsTests
    {
        private IAddressBookService _addressBookService;
        private IUser _loggedInUser;
        private List<IContact> _someContacts;
        private ISaveContactsResponse _saveContactsresponse;

        [TestMethod]
        public void ALoggedInUser_CanAddContact()
        {
            GivenThisContact();
            WhenSaveContact();
            ThenTheContactIsSaved();
        }


        [TestMethod]
        public void ALoggedInUser_CanAddContactAndFindContact()
        {
            GivenThisContact();
            WhenSaveContact();
            ThenTheContactIsFound();
        }

        private void ThenTheContactIsFound()
        {
            var emailAddress = MockUser.UserContacts(_loggedInUser).First().Emails.First().EmailAddress;
            var getContactsRequest = new GetContactsRequest
            {
                User = _loggedInUser,
                ContactEmail = emailAddress
            };
            var getContactsResponse = _addressBookService.GetContacts(getContactsRequest);

            Assert.IsTrue(getContactsResponse.Contacts.Select(c => c.Emails.Find(e => e.EmailAddress.Equals(emailAddress))) != null);
        }

        private void ThenTheContactIsSaved()
        {
            Assert.IsTrue(_saveContactsresponse.HasSavedContacts);
        }

        private void WhenSaveContact()
        {
            _saveContactsresponse =_addressBookService.SaveContacts(new SaveContactRequest { Contacts = _someContacts });
        }

        private void GivenThisContact()
        {
            _someContacts = MockUser.UserContacts(_loggedInUser);
        }


        [TestInitialize]
        public void Initialize()
        {
            const string username = "Username";
            const string validpassword = "ValidPassword";

            var addressBookRepository = new MockAddressBookRepository();
            _addressBookService = new AddressBookService(addressBookRepository);

            _loggedInUser = MockUser.LoggedInTestableUser(_addressBookService, username, validpassword);

            _addressBookService.SaveContacts(new SaveContactRequest { Contacts = MockUser.UserContacts(_loggedInUser) });
        }
    }
}
