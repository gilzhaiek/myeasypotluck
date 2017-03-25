using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.Object;

namespace MyEasyIDAL.Object
{
    public interface UserNameImageListIDAL
    {
        //void Load(UserNameImageList userNameImageList, UInt64 uniqueID);

        void LoadToImageList(UserNameImageList userNameImageList, UInt64 uniqueID, int index);

        //bool IsLatest(UserNameImageList userNameImageList);

        void Save(UserNameImageList userNameImageList);
    }
}
