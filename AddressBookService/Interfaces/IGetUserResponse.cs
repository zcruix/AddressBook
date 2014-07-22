using AddressBookDomain.Model.Interfaces;

namespace AddressBookServiceGateway.Interfaces
{
    public interface IGetUserResponse
    {
        IUser User { get; set; }
    }
}