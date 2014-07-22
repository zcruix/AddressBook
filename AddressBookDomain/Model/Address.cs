using AddressBookDomain.Enums;
using AddressBookDomain.Model.Interfaces;

namespace AddressBookDomain.Model
{
    public class Address : IAddress
    {
        public Address(bool self)
        {
            Self = self;
        }

        public string UserName { get; set; }
        public AddressType AddressType { get; set; }
        public string HouseNumber { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool Self { get; private set; }
    }
}