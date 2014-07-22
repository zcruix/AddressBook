using System.Collections.Generic;
using AddressBookDataStore.Exceptions;
using AddressBookDataStore.Interfaces;
using AddressBookDomain.Model.Interfaces;

namespace MockAddressBookDataStore
{
    public class MockAddressBookRepository : IAddressBookRepository
    {
        private readonly List<IUser> _users;

        public MockAddressBookRepository(List<IUser> users = null)
        {
            _users = users ?? new List<IUser>();
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
    }
}