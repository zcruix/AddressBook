using System.Collections.Generic;
using AddressBookDomain.Model.Interfaces;

namespace AddressBookServiceGateway.Interfaces
{
    public interface IGetContactsResponse
    {
        List<IContact> Contacts { get; set; }
    }
}