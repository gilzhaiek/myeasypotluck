using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.Resource;

namespace MyEasyIDAL.Resource
{
    public interface ResourceImageIDAL
    {
        void Load(ResourceImage resourceImage, UInt64 uniqueID);

        bool IsLatest(ResourceImage resourceImage);

        void Save(ResourceImage resourceImage);
    }
}
