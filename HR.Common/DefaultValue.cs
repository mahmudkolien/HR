
using System.Collections.Generic;

namespace HR.Common
{
    public static class DefaultValue
    {
        public static string UserPassword => "12345";
        public static string UserResetPassword => "12345";
        public static UserRoleName UserRoleName => new UserRoleName();
    }

    public class UserRoleName
    {
        public string SuperAdmin => "SuperAdmin";
        public string Admin => "Admin";                              
    }
}