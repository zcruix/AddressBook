using System.Collections.Generic;
using System.Net;
using AddressBookDomain.Model.Interfaces;

namespace AddressBookDomain.Model
{
    public class User : IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public NetworkCredential UserCredential { get; set; }
        public List<IContact> Contacts { get; set; }
        public string UserName { get { return UserCredential.UserName; } }
        public string Password { get { return UserCredential.Password; } }

        public bool IsAuthenticated(string password)
        {
            return Password.Equals(password);
        }

        public bool IsUser(string userName)
        {
            return UserName.Equals(userName);
        }
    }
}