using AddressBookDomain.Enums;
using AddressBookDomain.Model.Interfaces;

namespace AddressBookDomain.Model
{
    public class Email : IEmail
    {
        public EmailType EmailType { get; set; }
        public string EmailAddress { get; set; }
    }
}