using AddressBookDataProvider.Interfaces;
using AddressBookDomain.Model.Interfaces;

namespace AddressBookDataSqlProvider
{
    public class AddressBookDataSqlProvider : IAddressBookDataProvider
    {
        public IUserInfo GetUser(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}
