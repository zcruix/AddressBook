using System.Collections.Generic;

namespace AddressBookDomain.Model.Interfaces
{
    public interface IContact
    {
        string UserName { get; set; }
        string ContactId { get; set; }
        List<IAddress> Addresses { get; set; }
        List<IPhone> Phones { get; set; }
        List<IEmail> Emails { get; set; }
        bool Self { get; set; }
        bool IsUser(string userName);
        string Summary();
    }
}