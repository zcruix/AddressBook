using AddressBookDomain.Model.Interfaces;

namespace AddressBookDataStore.Interfaces
{
    public interface IUserDao
    {
        IUser GetUser(string userName);
    }
}