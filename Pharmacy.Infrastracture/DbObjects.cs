using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Infrastracture
{
    public static class DbObjects
    {
        public static class BaseDbObjects
        {
            public static class Functions
            {
                public static class Users
                {
                    public const string users_getloginbyuserid = "fn_users_getloginbyuserid";
                    public const string users_getloginbyusertokens = "fn_users_getloginbyusertokens";
                }
            }
        }
    }
}
