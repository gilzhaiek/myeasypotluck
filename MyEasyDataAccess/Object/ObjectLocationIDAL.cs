using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.Object;

namespace MyEasyIDAL.Object
{
    public interface ObjectLocationIDAL
    {
        void Load(ObjectLocation objectLocation, UInt64 uniqueID);

        bool IsLatest(ObjectLocation objectLocation);

        void Save(ObjectLocation objectLocation);
    }
}
