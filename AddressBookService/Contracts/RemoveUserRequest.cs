using AddressBookServiceGateway.Interfaces;

namespace AddressBookServiceGateway.Contracts
{
    public class RemoveUserRequest : IRemoveUserRequest
    {
        public string UserName { get; set; }
    }
}