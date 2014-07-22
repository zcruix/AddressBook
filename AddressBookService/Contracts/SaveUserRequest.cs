using AddressBookDomain.Model.Interfaces;
using AddressBookServiceGateway.Interfaces;

namespace AddressBookServiceGateway.Contracts
{
    public class SaveUserRequest : ISaveUserRequest
    {
        public IUser User { get; set; }
    }
}