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

            var firstContact = contacts.FirstOrDefault();

            var userContacts = new List<IContact>();

            if (firstContact != null)
            {
                var username = firstContact.UserName;
                userContacts.AddRange(GetContacts(username));
                userContacts.AddRange(contacts);

                var duplicateEmails = userContacts.Select(x => x.Emails).GroupBy(x => x)
                    .Where(g => g.Count() > 1)
                    .Select(y => y.Key)
                    .ToList();

                if (duplicateEmails.Any())
                    throw new DuplicateContactEmailAddressFoundException();

            }

            _contacts.AddRange(contacts);

            return true;
        }
    }
}