using AddressBookDomain.Model.Interfaces;

namespace AddressBookDataStore.Interfaces
{
    public interface IAddressBookRepository
    {
        IUser GetUser(string userName);
        bool AddUser(IUser user);
    }
}