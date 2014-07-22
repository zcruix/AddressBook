using System.Collections.Generic;
using AddressBookDomain.Model.Interfaces;

namespace AddressBookDataStore.Interfaces
{
    public interface IContactsDao
    {
        List<IContact> GetContacts();
    }
}