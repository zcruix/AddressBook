using System.Collections.Generic;
using System.Net;

namespace AddressBookDomain.Model.Interfaces
{
    public interface IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        NetworkCredential UserCredential { get; set; }
        List<IContact> Contacts { get; set; }
        bool IsAuthenticated(string password);
    }
}