using System;
using System.Collections.Generic;
using AddressBookDataStore.Interfaces;
using AddressBookDomain.Model.Interfaces;

namespace AddressBookDataStore
{
    public class AddressBookRepository : IAddressBookRepository
    {
        private readonly IAddressBookDataProvider _addressBookDataProvider;

        public AddressBookRepository(IAddressBookDataProvider addressBookDataProvider = null)
        {
            _addressBookDataProvider = addressBookDataProvider ?? new AddressBookDataProvider();
        }

        public IUser GetUser(string userName)
        {
            return _addressBookDataProvider.User.GetUser(userName);
        }

        public bool AddUser(IUser user)
        {
            throw new NotImplementedException();
        }

        public List<IContact> GetContactsForUser(string userName)
        {
            throw new NotImplementedException();
        }


        public bool AddContacts(List<IContact> contacts)
        {
            throw new NotImplementedException();
        }
    }
}