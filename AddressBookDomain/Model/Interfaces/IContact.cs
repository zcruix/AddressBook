using System.Collections.Generic;

namespace AddressBookDomain.Model.Interfaces
{
    public interface IContact
    {
        string UserName { get; set; }
        string ContactId { get; set; }
        List<IAddress> Addresses { get; set; }
        List<Phone> Phones { get; set; }
        List<Email> Emails { get; set; }
        bool Self { get; set; }
    }
}