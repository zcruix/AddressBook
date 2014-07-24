using System;
using System.Collections.Generic;
using System.Linq;
using AddressBookDataStore.Exceptions;
using AddressBookDataStore.Interfaces;
using AddressBookDomain.Model.Interfaces;

namespace MockAddressBookDataStore
{
    public class MockAddressBookRepository : IAddressBookRepository
    {
        private readonly List<IContact> _contacts;
        private readonly List<IUser> _users;

        public MockAddressBookRepository(List<IUser> users = null, List<IContact> contacts = null)
        {
            _users = users ?? new List<IUser>();
            _contacts = contacts ?? new List<IContact>();
        }

        public IUser GetUser(string userName)
        {
            return _users.Find(u => u.IsUser(userName));
        }

        public bool AddUser(IUser user)
        {
            if (GetUser(user.UserName) != null)
                throw new DuplicateUserNameException();

            _users.Add(user);
            return true;
        }

        public List<IContact> GetContacts(string userName)
        {
            return _contacts.FindAll(c => c.IsUser(userName));
        }

        public bool AddContacts(List<IContact> contacts)
        {
            if (contacts == null || !contacts.Any()) return false;
            ValidateNewContactsBeingAddded(contacts);
            _contacts.AddRange(contacts);
            return true;
        }

        private void ValidateNewContactsBeingAddded(List<IContact> contacts)
        {
            ThrowExceptionIfAnyContactIsFoundWithNoContactId(contacts);
            SearchForDuplicate<string, DuplicateContactIdFoundException>(contacts.Select(c => c.ContactId));
            ThrowExceptionIfDuplicateEmailAddressesFoundInTheUserContacts(contacts);
        }

        private void ThrowExceptionIfDuplicateEmailAddressesFoundInTheUserContacts(IEnumerable<IContact> contacts)
        {
            var newContactsToBeAdded = contacts as IList<IContact> ?? contacts.ToList();
            var firstContact = newContactsToBeAdded.FirstOrDefault();
            if (firstContact == null) return;

            var username = firstContact.UserName;
            var userContacts = new List<IContact>();
            userContacts.AddRange(GetContacts(username));
            userContacts.AddRange(newContactsToBeAdded);            

            SearchForDuplicate<List<IEmail>, DuplicateContactEmailAddressFoundException>(userContacts.Select(c => c.Emails));            
        }

        private static void SearchForDuplicate<T, TE>(IEnumerable<T> items) where TE : Exception, new()
        {
            var duplicates = items.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();

            if (duplicates.Any())
                throw new TE();
        }

        private static void ThrowExceptionIfAnyContactIsFoundWithNoContactId(IEnumerable<IContact> contacts)
        {
            var contactsWithNoContactIdSet = contacts.ToList().FindAll(c => string.IsNullOrEmpty(c.ContactId));
            if(contactsWithNoContactIdSet.Any())
                throw new ContactIdMustBeSetOnAllContactsException();
        }      
    }
}