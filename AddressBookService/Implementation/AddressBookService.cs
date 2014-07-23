using System;
using System.Collections.Generic;
using AddressBookDataStore;
using AddressBookDataStore.Interfaces;
using AddressBookDomain.Model.Interfaces;
using AddressBookServiceGateway.Contracts;
using AddressBookServiceGateway.Interfaces;

namespace AddressBookServiceGateway.Implementation
{
    public class AddressBookService : IAddressBookService
    {
        private readonly IAddressBookRepository _addressBookRepository;

        private bool _isUserAuthenticated;

        public AddressBookService(IAddressBookRepository addressBookRepository = null,
            IAddressBookDataProvider addressBookDataProvider = null)
        {
            _addressBookRepository = addressBookRepository ??
                                     new AddressBookRepository(addressBookDataProvider ??
                                                               new AddressBookSqlClientProvider.
                                                                   AddressBookSqlClientProvider());
        }

        public ILoginResponse Login(ILoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.UserCredential.UserName))
                throw new ArgumentNullException("loginRequest");

            _isUserAuthenticated =
                _addressBookRepository.GetUser(loginRequest.UserCredential.UserName)
                    .IsAuthenticated(loginRequest.UserCredential.Password);

            return new LoginResponse {IsLoggedIn = _isUserAuthenticated};
        }

        public ISaveUserResponse SaveUser(ISaveUserRequest saveUserRequest)
        {
            return new SaveUserResponse
                   {
                       HasBeenAdded = _addressBookRepository.AddUser(saveUserRequest.User),
                       User = saveUserRequest.User
                   };
        }

        public IGetUserResponse GetUser(IGetUserRequest getUserRequest)
        {
            return new GetUserResponse {User = _addressBookRepository.GetUser(getUserRequest.UserCredential.UserName)};
        }

        public ISaveContactsResponse SaveContacts(ISaveContactsRequest saveContactRequest)
        {
            bool hasSavedContacts = _addressBookRepository.AddContacts(saveContactRequest.Contacts);
            return new SaveContactsResponse {HasSavedContacts = hasSavedContacts};
        }

        public IRemoveContactsResponse RemoveContacts(IRemoveContactsRequest removeContactsRequest)
        {
            throw new NotImplementedException();
        }

        public IGetContactsResponse GetContacts(IGetContactsRequest getContactsRequest)
        {
            return _isUserAuthenticated
                ? new GetContactsResponse
                  {
                      Contacts = _addressBookRepository.GetContacts(getContactsRequest.User.UserCredential.UserName)
                  }
                : new GetContactsResponse {Contacts = new List<IContact>()};
        }

        public ILogoutResponse Logout(ILogoutRequest logoutRequest)
        {
            throw new NotImplementedException();
        }
    }
}