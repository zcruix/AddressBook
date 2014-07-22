using AddressBookDomain.Model.Interfaces;
using AddressBookServiceGateway.Interfaces;

namespace AddressBookServiceGateway.Contracts
{
    public class GetUserResponse : IGetUserResponse
    {
        public IUser User { get; set; }
    }
}