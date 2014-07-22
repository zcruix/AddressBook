using AddressBookDomain.Enums;

namespace AddressBookDomain.Model.Interfaces
{
    public interface IPhone
    {
        string PhoneNumber { get; set; }
        PhoneType PhoneType { get; set; }
    }
}