using AddressBookDomain.Enums;

namespace AddressBookDomain.Model.Interfaces
{
    internal interface IAddress
    {
        AddressType AddressType { get; set; }
        string City { get; set; }
        string HouseNumber { get; set; }
        string State { get; set; }
        string StreetLine1 { get; set; }
        string StreetLine2 { get; set; }
        string Zip { get; set; }
    }
}