using AddressBookDomain.Model.Interfaces;

namespace AddressBookServiceGateway.Interfaces
{
    public interface ISaveUserRequest
    {
        IUser User { get; set; }
    }
}