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
        string UserName { get; }
        string Password { get; }
        bool IsAuthenticated(string password);
        bool IsUser(string userName);
    }
}