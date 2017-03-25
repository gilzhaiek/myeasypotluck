using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.User;
using MyEasy.Common;

namespace MyEasy.MyEasyIDAL
{
    public interface LoginManagerIDAL
    {
        UInt64 GetUserUniqueID(string loginName, string password);

        void AddUser(UserLoginInfo userLoginInfo);

        bool LoginNameExists(string loginName);

        bool EmailExists(string email);
    }
}
