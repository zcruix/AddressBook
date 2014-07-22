using System.Collections.Generic;
using AddressBookDomain.Model.Interfaces;

namespace AddressBookServiceGateway.Interfaces
{
    public interface ISaveContactsRequest
    {
        List<IContact> Contacts { get; set; }
    }
}