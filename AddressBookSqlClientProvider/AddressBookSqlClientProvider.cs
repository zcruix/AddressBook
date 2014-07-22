using AddressBookDataStore.Interfaces;

namespace AddressBookSqlClientProvider
{
    public class AddressBookSqlClientProvider : IAddressBookDataProvider
    {
        public IUserDao User { get; set; }
        public IContactsDao Contacts { get; set; }

        public AddressBookSqlClientProvider(IUserDao userDao = null, IContactsDao contactsDao = null)
        {
            User = userDao ?? new UserDao();
            Contacts = contactsDao ?? new ContactsDao();
        }
    }
}