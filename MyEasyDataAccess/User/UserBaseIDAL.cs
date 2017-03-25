using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.User;

namespace MyEasyIDAL.User
{
    public interface UserBaseIDAL
    {
        void Load(UserBase userBase, UInt64 uniqueID);

        bool IsLatest(UserBase userBase);

        void Save(UserBase userBase);
    }
}
