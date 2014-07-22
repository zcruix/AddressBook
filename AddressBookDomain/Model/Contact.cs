using System.Collections.Generic;
using AddressBookDomain.Model.Interfaces;

namespace AddressBookDomain.Model
{
    public class Contact : IContact
    {
        public List<Address> Addresses { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Email> Emails { get; set; }
    }
}