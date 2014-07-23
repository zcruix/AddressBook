using AddressBookDomain.Model.Interfaces;
using AddressBookServiceGateway.Interfaces;

namespace AddressBookServiceGateway.Contracts
{
    public class GetContactsRequest : IGetContactsRequest
    {
        public IUser User { get; set; }
        public string ContactEmail { get; set; }
    }
}