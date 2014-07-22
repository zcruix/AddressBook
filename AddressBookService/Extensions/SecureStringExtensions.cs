using System;
using System.Runtime.InteropServices;
using System.Security;

namespace AddressBookServiceGateway.Extensions
{
    public static class SecureStringExtensions
    {
        public static SecureString GetSecurePassword(this string somepassword)
        {
            var securePassword = new SecureString();
            foreach (var character in somepassword)
            {
                securePassword.AppendChar(character);
            }
            return securePassword;
        }

        public static string ConvertToUnSecureString(this SecureString securePassword)
        {
            var unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}