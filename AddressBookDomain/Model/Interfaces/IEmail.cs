using AddressBookDomain.Enums;

namespace AddressBookDomain.Model.Interfaces
{
    public interface IEmail
    {
        string EmailAddress { get; set; }
        EmailType EmailType { get; set; }
    }
}