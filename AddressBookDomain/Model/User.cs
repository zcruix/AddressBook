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
        
        public bool IsAuthenticated(string password)
        {
            return UserCredential.Password.Equals(password);
        }
    }
}