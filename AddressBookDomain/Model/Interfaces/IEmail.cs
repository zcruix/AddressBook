using AddressBookDomain.Enums;

namespace AddressBookDomain.Model.Interfaces
{
    internal interface IEmail
    {
        string EmailAddress { get; set; }
        EmailType EmailType { get; set; }
    }
}