using AddressBookDomain.Enums;

namespace AddressBookDomain.Model.Interfaces
{
    internal interface IPhone
    {
        string PhoneNumber { get; set; }
        PhoneType PhoneType { get; set; }
    }
}