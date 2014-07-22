using System.Net;

namespace AddressBookServiceGateway.Interfaces
{
    public interface ILoginRequest
    {
        NetworkCredential UserCredential { get; set; }
    }
}