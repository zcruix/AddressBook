using System;
using AddressBookDataStore.Interfaces;
using AddressBookDomain.Model.Interfaces;

namespace AddressBookSqlClientProvider
{
    public class UserDao : IUserDao
    {
        public IUser GetUser(string userName)
        {
            throw new NotImplementedException();
        }
    }
}