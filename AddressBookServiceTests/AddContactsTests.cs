using System.Collections.Generic;
using System.Linq;
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
    public class AddContactsTests 
    {
        internal IAddressBookService AddressBookService;
        internal IUser LoggedInUser;
        internal List<IContact> SomeContacts;
        internal ISaveContactsResponse SaveContactsresponse;
        private readonly ContactsUtility _contactsUtility;

        public AddContactsTests()
        {
            _contactsUtility = new ContactsUtility(this);
        }

        [TestMethod]
        public void ALoggedInUser_CanAddContact()
        {          
            ThenTheContactIsSaved();
        }

        [TestMethod]
        public void ALoggedInUser_CanAddContactAndFindContact()
        {
            WhenSaveContact();
            ThenTheContactIsFound();
        }

        [TestMethod]
        public void LoggedInUserAddsTwoContacts_ShouldHaveTwoContacts()
        {
            _contactsUtility.WhenSaveAnotherContactAfterInitialized();
            ThenTheGetContactsShouldReturnTwoContacts();
        }        

        [TestMethod]
        [ExpectedException(typeof(DuplicateContactEmailAddressFoundException))]
        public void LoggedInUser_CannotAddContactsWithSameEmailAddress()
        {
            GivenAContactWithAValidEmailAddress();            
            WhenSaveContact();            
        }

        [TestMethod]
        [ExpectedException(typeof(ContactIdMustBeSetOnAllContactsException))]
        public void LoggedInUser_CannotAddContactsWithNoContactId()
        {
            _contactsUtility.GivenAContactWithNoContactId();
            WhenSaveContact();
        }

        [TestMethod]
        [ExpectedException(typeof(ContactIdMustBeSetOnAllContactsException))]
        public void LoggedInUser_CannotAddContactsWithNullContactId()
        {
            _contactsUtility.GivenAContactWithNullContactId();
            WhenSaveContact();
        }

        [TestMethod]
        [ExpectedException(typeof(ContactIdMustBeSetOnAllContactsException))]
        public void LoggedInUser_CannotAddContactsWithEmptyContactId()
        {
            _contactsUtility.GivenAContactWithEmptyContactId();
            WhenSaveContact();
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateContactIdFoundException))]
        public void LoggedInUser_CannotAddContactsWithSameContactId()
        {
            _contactsUtility.GivenContactsWithSameContactId();
            WhenSaveContact();
        }

        [TestInitialize]
        public void Initialize()
        {
            var addressBookRepository = new MockAddressBookRepository();
            AddressBookService = new AddressBookService(addressBookRepository);
            GivenThisLoggedInUser(Username, Validpassword);
            SaveContactsresponse = AddressBookService.SaveContacts(new SaveContactRequest { Contacts = MockUser.UserContacts(LoggedInUser) });            
        }

        private void GivenThisLoggedInUser(string username, string validpassword)
        {
            LoggedInUser = MockUser.LoggedInTestableUser(AddressBookService, username, validpassword);
        }

        private void ThenTheContactIsFound()
        {
            var emailAddress = MockUser.UserContacts(LoggedInUser).First().Emails.First().EmailAddress;
            var getContactsRequest = new GetContactsRequest
            {
                User = LoggedInUser,
                ContactEmail = emailAddress
            };

            var getContactsResponse = AddressBookService.GetContacts(getContactsRequest);

            Assert.IsTrue(getContactsResponse.Contacts.Select(c => c.Emails.Find(e => e.EmailAddress.Equals(emailAddress))) != null);
        }

        private void ThenTheContactIsSaved()
        {
            Assert.IsTrue(SaveContactsresponse.HasSavedContacts);
        }

        private void WhenSaveContact()
        {
            _contactsUtility.AddContact(new SaveContactRequest { Contacts = SomeContacts });
        }

        private void GivenAContactWithAValidEmailAddress()
        {
            SomeContacts = MockUser.UserContacts(LoggedInUser);
            _contactsUtility.AddContact(new SaveContactRequest { Contacts = SomeContacts });
        }

        private void ThenTheGetContactsShouldReturnTwoContacts()
        {
            var getContactsResponse =AddressBookService.GetContacts(new GetContactsRequest {User = LoggedInUser});
            Assert.IsTrue(getContactsResponse.Contacts.Count == 2);
        }

        private const string Username = "Username";
        private const string Validpassword = "ValidPassword";
    }
}