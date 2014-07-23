using System;
using System.Collections.Generic;
using AddressBookDomain.Model.Interfaces;

namespace AddressBookDomain.Model
{
    public class Contact : IContact
    {
        public string UserName { get; set; }
        public string ContactId { get; set; }

        public List<IAddress> Addresses { get; set; }
        public List<IPhone> Phones { get; set; }
        public List<IEmail> Emails { get; set; }
        public bool Self { get; set; }

        public bool IsUser(string userName)
        {
            return userName.Equals(UserName);
        }

        public string Summary()
        {
            throw new NotImplementedException();
        }
    }
}