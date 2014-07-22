using System.Collections.Generic;

namespace AddressBookDomain.Model.Interfaces
{
    public interface IContact
    {
        List<Address> Addresses { get; set; }
        List<Phone> Phones { get; set; }
        List<Email> Emails { get; set; }
    }
}