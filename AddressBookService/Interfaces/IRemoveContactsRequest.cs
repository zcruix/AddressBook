using System.Collections.Generic;
using AddressBookDomain.Model.Interfaces;

namespace AddressBookServiceGateway.Interfaces
{
    public interface IRemoveContactsRequest
    {
        List<IContact> Contacts { get; set; }
    }
}