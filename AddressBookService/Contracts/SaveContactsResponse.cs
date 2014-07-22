using AddressBookServiceGateway.Interfaces;

namespace AddressBookServiceGateway.Contracts
{
    public class SaveContactsResponse : ISaveContactsResponse
    {
        public bool HasSavedContacts { get; set; }
    }
}