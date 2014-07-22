using AddressBookDomain.Model.Interfaces;

namespace AddressBookServiceGateway.Interfaces
{
    public interface ISaveUserResponse
    {
        bool HasBeenAdded { get; set; }
        IUser User { get; set; }
    }
}