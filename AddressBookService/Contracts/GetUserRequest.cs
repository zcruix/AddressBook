using System.Net;
using AddressBookServiceGateway.Interfaces;

namespace AddressBookServiceGateway.Contracts
{
    public class GetUserRequest : IGetUserRequest
    {
        public NetworkCredential UserCredential { get; set; }
    }
}
