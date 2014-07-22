using AddressBookServiceGateway.Interfaces;

namespace AddressBookServiceGateway.Contracts
{
    public class SaveUserResponse : ISaveUserResponse
    {
        public bool HasBeenAdded { get; set; }
    }
}