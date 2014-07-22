using AddressBookDataProvider;
using AddressBookDataProvider.Interfaces;

namespace AddressBookMockDataProvider
{
    public class AddressBookMockDataProvider : IAddressBookDataProvider
    {
        public IUserDao User { get; set; }
        public IContactsDao Contacts { get; set; }

        public AddressBookMockDataProvider(IUserDao userDao = null, IContactsDao contactsDao = null)
        {
            User = userDao ?? new UserDao();
            Contacts = contactsDao ?? new ContactsDao();
        }


    }
}
