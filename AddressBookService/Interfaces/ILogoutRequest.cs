using System.Net;

namespace AddressBookServiceGateway.Interfaces
{
    public interface ILogoutRequest
    {
        NetworkCredential UserCredential { get; set; }
    }
}