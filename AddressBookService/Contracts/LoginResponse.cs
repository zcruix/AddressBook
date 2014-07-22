using AddressBookServiceGateway.Interfaces;

namespace AddressBookServiceGateway.Contracts
{
    public class LoginResponse : ILoginResponse
    {
        public bool IsLoggedIn { get; set; }
    }
}