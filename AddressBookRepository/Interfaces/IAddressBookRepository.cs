﻿using System.Collections.Generic;
using AddressBookDomain.Model.Interfaces;

namespace AddressBookDataStore.Interfaces
{
    public interface IAddressBookRepository
    {
        IUser GetUser(string userName);
        bool AddUser(IUser user);
        List<IContact> GetContacts();
        bool AddContacts(List<IContact> contacts);
    }
}