using AddressBookDomain.Model.Interfaces;

namespace AddressBookServiceGateway.Interfaces
{
    public interface IAddressBookService
    {
        ILoginResponse Login(ILoginRequest loginRequest);
        ISaveUserResponse SaveUser(ISaveUserRequest saveUserRequest);
        IGetUserResponse GetUser(IGetUserRequest getUserRequest);
        ISaveContactsResponse SaveContacts(ISaveContactsRequest saveContactRequest);
        IRemoveContactsResponse RemoveContacts(IRemoveContactsRequest removeContactsRequest);
        IGetContactsResponse GetContacts(IGetContactsRequest getContactsRequest);
        ILogoutResponse Logout(ILogoutRequest logoutRequest);
        IRemoveUserResponse RemoveUser(IRemoveUserRequest removeUserrequest);
    }
}