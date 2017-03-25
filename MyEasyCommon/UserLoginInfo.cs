using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyEasy.Common
{
    public class UserLoginInfo
    {
        private UInt64 mUniqueID;

        private string mPassword;

        private string mEmail;

        public UserLoginInfo(string password, string email, UInt64 uniqueID)
        {
            mUniqueID = uniqueID;
            mPassword = password;
            mEmail = email;
        }

        public UInt64 UniqueID
        {
            get { return mUniqueID; }
            set { mUniqueID = value; }
        }

        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        public bool MatchPassword(string password)
        {
            return (password == Password);
        }

        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }
    }
}
