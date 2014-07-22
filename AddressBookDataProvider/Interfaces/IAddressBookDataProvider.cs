namespace AddressBookDataStore.Interfaces
{
    public interface IAddressBookDataProvider
    {
        IUserDao User { get; set; }
        IContactsDao Contacts { get; set; }
    }
}