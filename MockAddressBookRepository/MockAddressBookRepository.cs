using System.Collections.Generic;
using System.Linq;
using AddressBookDataStore.Exceptions;
using AddressBookDataStore.Interfaces;
using AddressBookDomain.Model.Interfaces;

namespace MockAddressBookDataStore
{
    public class MockAddressBookRepository : IAddressBookRepository
    {
        private readonly List<IUser> _users;
        private readonly List<IContact> _contacts;

        public MockAddressBookRepository(List<IUser> users = null, List<IContact> contacts = null)
        {
            _users = users ?? new List<IUser>();
            _contacts = contacts ?? new List<IContact>();            
        }

        public IUser GetUser(string userName)
        {
            return _users.Find(u => u.UserCredential.UserName.Equals(userName));
        }

        public bool AddUser(IUser user)
        {
            if (GetUser(user.UserCredential.UserName) != null)
                throw new DuplicateUserNameException();

            _users.Add(user);
            return true;
        }

        public List<IContact> GetContacts()
        {
            return _contacts;
        }

        public bool AddContacts(List<IContact> contacts)
        {
            if (!contacts.Any()) return false;

            _contacts.AddRange(contacts);
            return true;
        }
    }
}