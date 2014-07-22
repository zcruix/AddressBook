using AddressBookDomain.Enums;
using AddressBookDomain.Model.Interfaces;

namespace AddressBookDomain.Model
{
    public class Phone : IPhone
    {
        public PhoneType PhoneType { get; set; }
        public string PhoneNumber { get; set; }
    }
}