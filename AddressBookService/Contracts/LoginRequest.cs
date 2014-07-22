using System.Net;
using AddressBookServiceGateway.Interfaces;

namespace AddressBookServiceGateway.Contracts
{
    public class LoginRequest : ILoginRequest
    {
        public NetworkCredential UserCredential { get; set; }
    }
}