using AddressBookDataStore.Interfaces;

namespace AddressBookDataStore
{
    public class AddressBookDataProvider : IAddressBookDataProvider
    {
        public IUserDao User { get; set; }
        public IContactsDao Contacts { get; set; }

         public AddressBookDataProvider(IUserDao userDao = null, IContactsDao contactsDao = null)
        {
            User = userDao ?? new UserDao();
            Contacts = contactsDao ?? new ContactsDao();
        }
    }
}