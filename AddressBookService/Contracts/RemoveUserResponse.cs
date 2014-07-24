using AddressBookServiceGateway.Interfaces;

namespace AddressBookServiceGateway.Contracts
{
    public class RemoveUserResponse : IRemoveUserResponse
    {
        public bool HasBeenRemoved { get; set; }
    }
}