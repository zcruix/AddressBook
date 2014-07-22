using System.Net;

namespace AddressBookServiceGateway.Interfaces
{
    public interface IGetUserRequest
    {
        NetworkCredential UserCredential { get; set; }
    }
}