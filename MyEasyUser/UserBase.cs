using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasy.Common;

namespace MyEasy.User
{
    public class UserBase : MyEasyBase
    {
        #region Members

        UserInfo mUserInfo;

        #endregion

        public UserBase()
        {
        }

        #region properties

        public UserInfo UserInfo
        {
            get { return mUserInfo; }
            set
            {
            }
        }

        #endregion

    }
}
