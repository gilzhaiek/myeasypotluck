using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.Holding;

namespace MyEasyIDAL.HoldingsIDAL
{
    public interface HoldingsInfoIDAL
    {
        void Load(HoldingsInfo holdingsInfo, UInt64 uniqueID);

        bool IsLatest(HoldingsInfo holdingsInfo);

        void Save(HoldingsInfo holdingsInfo);

        List<UInt64> GetUniqueIDsByItemOwner(UInt64 itemOwnerUniqueID);
    }
}
