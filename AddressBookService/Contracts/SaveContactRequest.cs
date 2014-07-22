using System.Collections.Generic;
using AddressBookDomain.Model.Interfaces;
using AddressBookServiceGateway.Interfaces;

namespace AddressBookServiceGateway.Contracts
{
    public class SaveContactRequest : ISaveContactsRequest
    {
        public List<IContact> Contacts { get; set; }
    }
}