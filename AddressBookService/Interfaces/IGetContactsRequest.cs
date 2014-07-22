using AddressBookDomain.Model.Interfaces;

namespace AddressBookServiceGateway.Interfaces
{
    public interface IGetContactsRequest
    {
        IUser User { get; set; }
    }
}