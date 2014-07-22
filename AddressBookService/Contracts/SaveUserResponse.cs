using AddressBookDomain.Model.Interfaces;
using AddressBookServiceGateway.Interfaces;

namespace AddressBookServiceGateway.Contracts
{
    public class SaveUserResponse : ISaveUserResponse
    {
        public bool HasBeenAdded { get; set; }
        public IUser User { get; set; }
    }
}