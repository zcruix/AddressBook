using System;
using AddressBookDataStore.Interfaces;
using AddressBookDomain.Model.Interfaces;

namespace AddressBookDataStore
{
    public class UserDao : IUserDao
    {
        public IUser GetUser(string userName)
        {
            throw new NotImplementedException();
        }
    }
}