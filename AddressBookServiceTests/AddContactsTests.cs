using System.Collections.Generic;
using System.Linq;
using AddressBookDataStore.Exceptions;
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

        [TestMethod]
        public void LoggedInUserAddsTwoContacts_ShouldHaveTwoContacts()
        {            
            WhenSaveAnotherContactAfterInitialized();
            ThenTheGetContactsShouldReturnTwoContacts();
        }        

        [TestMethod]
        [ExpectedException(typeof(DuplicateContactEmailAddressFoundException))]
        public void LoggedInUser_CannotAddContactsWithSameEmailAddress()
        {
            GivenAContactWithAValidEmailAddress();            
            WhenSaveContact();            
        }

        [TestInitialize]
        public void Initialize()
        {
            var addressBookRepository = new MockAddressBookRepository();
            _addressBookService = new AddressBookService(addressBookRepository);

            GivenThisLoggedInUser(Username, Validpassword);

            _addressBookService.SaveContacts(new SaveContactRequest { Contacts = MockUser.UserContacts(_loggedInUser) });
        }

        private void GivenThisLoggedInUser(string username, string validpassword)
        {
            _loggedInUser = MockUser.LoggedInTestableUser(_addressBookService, username, validpassword);
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
            AddContact(new SaveContactRequest { Contacts = _someContacts });
        }

        private void GivenThisContact()
        {
            _someContacts = MockUser.UserContacts(_loggedInUser);
        }

        private void GivenAContactWithAValidEmailAddress()
        {
            _someContacts = MockUser.UserContacts(_loggedInUser);
            AddContact(new SaveContactRequest { Contacts = _someContacts });
        }

        private void AddContact(ISaveContactsRequest saveContactRequest)
        {
            _saveContactsresponse = _addressBookService.SaveContacts(saveContactRequest);
        }

        private void WhenSaveAnotherContactAfterInitialized()
        {
            var contacts = new List<IContact>
                           {
                               new Contact
                               {
                                   UserName = _loggedInUser.UserName,
                                   Addresses = new List<IAddress>(),
                                   Emails = new List<IEmail>{new Email{EmailAddress = "email2@email.com"}}
                               }
                           };

            _addressBookService.SaveContacts(new SaveContactRequest{Contacts = contacts});
        }

        private void ThenTheGetContactsShouldReturnTwoContacts()
        {
            var getContactsResponse =_addressBookService.GetContacts(new GetContactsRequest {User = _loggedInUser});
            Assert.IsTrue(getContactsResponse.Contacts.Count == 2);
        }

        private const string Username = "Username";
        private const string Validpassword = "ValidPassword";
    }
}