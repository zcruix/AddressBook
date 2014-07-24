using System.Collections.Generic;
using System.Net;
using AddressBookDomain.Model;
using AddressBookDomain.Model.Interfaces;
using AddressBookServiceGateway.Contracts;
using AddressBookServiceGateway.Interfaces;

namespace MockAddressBookDataStore
{
    public static class MockUser
    {
        public static IUser LoggedInTestableUser(IAddressBookService addressBookService, string username,
            string validpassword)
        {
            var user = AddTestableUser(addressBookService, username, validpassword);
            addressBookService.Login(new LoginRequest
                                     {
                                         UserCredential = GetTestableUserCredentials(username, validpassword)
                                     });

            return user;
        }

        public static IUser AddTestableUser(IAddressBookService addressBookService, string username,
            string validpassword)
        {
            var user = new User
                       {
                           UserCredential = GetTestableUserCredentials(username, validpassword)
                       };

            var saveUserResponse = addressBookService.SaveUser(new SaveUserRequest {User = user});

            return saveUserResponse.HasBeenAdded ? saveUserResponse.User : user;
        }

        public static List<IContact> UserContacts(IUser user)
        {
            var contacts = new List<IContact>
                           {
                               new Contact
                               {
                                   ContactId = "ContactIdInitial",
                                   UserName = user.UserName,
                                   Addresses = new List<IAddress>(),
                                   Emails = new List<IEmail>{new Email{EmailAddress = "emailInitial@email.com"}}
                               }
                           };

            return contacts;
        }

        public static NetworkCredential GetTestableUserCredentials(string username, string validpassword)
        {
            return new NetworkCredential {UserName = username, Password = validpassword};
        }
    }
}