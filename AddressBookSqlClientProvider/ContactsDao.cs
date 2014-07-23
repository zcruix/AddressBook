using System;
using System.Collections.Generic;
using AddressBookDataStore.Interfaces;
using AddressBookDomain.Model.Interfaces;

namespace AddressBookSqlClientProvider
{
    public class ContactsDao : IContactsDao
    {
        public List<IContact> GetContacts()
        {
            throw new NotImplementedException();
        }
    }
}