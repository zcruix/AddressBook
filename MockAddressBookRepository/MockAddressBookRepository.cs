using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public List<IContact> GetContactsForUser(string userName)
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

        private void ValidateNewContactsBeingAddded(List<IContact> contactsToBeAdded)
        {
            ThrowExceptionIfAnyContactIsFoundWithNoContactId(contactsToBeAdded);
            ThrowExceptionIfDuplicateItemsFound<String, DuplicateContactIdFoundException>(contactsToBeAdded, contact => contact.ContactId);
            ThrowExceptionIfDuplicateItemsFound<List<IEmail>, DuplicateContactEmailAddressFoundException>(GetCombinedContactsList(contactsToBeAdded), contact => contact.Emails);
        }

        private IEnumerable<IContact> GetCombinedContactsList(List<IContact> contacts)
        {
            var userContacts = new List<IContact>();
            userContacts.AddRange(GetContactsForUser(GetUserNameFromTheFirstContactInGivenList(contacts)));
            userContacts.AddRange(contacts);
            return userContacts;
        }

        private static string GetUserNameFromTheFirstContactInGivenList(IEnumerable<IContact> contacts)
        {
            var firstContact = contacts.FirstOrDefault();
            if (firstContact == null) return string.Empty;
            var username = firstContact.UserName;
            return username;
        }

        private static void ThrowExceptionIfDuplicateItemsFound<T, TE>(IEnumerable<IContact> contacts, Func<IContact, T> filter) where TE : Exception, new()
        {
            var duplicates = contacts.Select(filter).GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();

            if (duplicates.Any())
                throw new TE();
        }

        private static void ThrowExceptionIfAnyContactIsFoundWithNoContactId(IEnumerable<IContact> contacts)
        {
            var contactsWithNoContactIdSet = contacts.ToList().FindAll(c => string.IsNullOrEmpty(c.ContactId));
            if (contactsWithNoContactIdSet.Any())
                throw new ContactIdMustBeSetOnAllContactsException();
        }
    }
}