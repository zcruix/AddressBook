using System;
using System.Collections.Generic;
using AddressBookDataStore.Interfaces;
using AddressBookDomain.Model.Interfaces;

namespace AddressBookDataStore
{
    public class ContactsDao : IContactsDao
    {
        public List<IContact> GetContacts()
        {
            throw new NotImplementedException();
        }
    }
}