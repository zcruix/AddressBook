using System.Collections.Generic;
using AddressBookDomain.Model;
using AddressBookDomain.Model.Interfaces;
using AddressBookServiceGateway.Contracts;
using AddressBookServiceGateway.Interfaces;

namespace AddressBookServiceTests
{
    public class ContactsUtility
    {
        private readonly AddContactsTests _addContactsTests;

        public ContactsUtility(AddContactsTests addContactsTests)
        {
            _addContactsTests = addContactsTests;
        }

        public void AddContact(ISaveContactsRequest saveContactRequest)
        {
            _addContactsTests.SaveContactsresponse = _addContactsTests.AddressBookService.SaveContacts(saveContactRequest);
        }

        public void WhenSaveAnotherContactAfterInitialized()
        {
            var contacts = new List<IContact>
            {
                new Contact
                {
                    ContactId = "ContactId",
                    UserName = _addContactsTests.LoggedInUser.UserName,
                    Addresses = new List<IAddress>(),
                    Emails = new List<IEmail>{new Email{EmailAddress = "email1@email.com"}}
                }
            };

            _addContactsTests.AddressBookService.SaveContacts(new SaveContactRequest{Contacts = contacts});
        }

        public void GivenAContactWithNoContactId()
        {
            _addContactsTests.SomeContacts = new List<IContact>
            {
                new Contact
                {
                    UserName = _addContactsTests.LoggedInUser.UserName,
                    Addresses = new List<IAddress>(),
                    Emails = new List<IEmail>{new Email{EmailAddress = "email2@email.com"}}
                }
            };

        }

        public void GivenAContactWithEmptyContactId()
        {
            _addContactsTests.SomeContacts = new List<IContact>
            {
                new Contact
                {
                    ContactId = string.Empty,
                    UserName = _addContactsTests.LoggedInUser.UserName,
                    Addresses = new List<IAddress>(),
                    Emails = new List<IEmail>{new Email{EmailAddress = "email3@email.com"}}
                }
            };

        }

        public void GivenAContactWithNullContactId()
        {
            _addContactsTests.SomeContacts = new List<IContact>
            {
                new Contact
                {
                    ContactId = null,
                    UserName = _addContactsTests.LoggedInUser.UserName,
                    Addresses = new List<IAddress>(),
                    Emails = new List<IEmail>{new Email{EmailAddress = "email4@email.com"}}
                }
            };

        }

        public void GivenContactsWithSameContactId()
        {
            _addContactsTests.SomeContacts = new List<IContact>
            {
                new Contact
                {
                    ContactId = "SameContactId",
                    UserName = _addContactsTests.LoggedInUser.UserName,
                    Addresses = new List<IAddress>(),
                    Emails = new List<IEmail>{new Email{EmailAddress = "email4@email.com"}}
                },

                new Contact
                {
                    ContactId = "SameContactId",
                    UserName = _addContactsTests.LoggedInUser.UserName,
                    Addresses = new List<IAddress>(),
                    Emails = new List<IEmail>{new Email{EmailAddress = "email4@email.com"}}
                }
            };

        }
    }
}