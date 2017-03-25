using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.Item;

namespace MyEasyIDAL.Item
{
    public interface ItemBaseIDAL
    {
        void Load(ItemBase itemBase, UInt64 uniqueID);

        bool IsLatest(ItemBase itemBase, bool checkRelations);

        void Save(ItemBase itemBase);

        List<UInt64> GetChildrenUniqueIDsByEventParent(UInt64 eventParentUniqueID);

        List<UInt64> GetChildrenUniqueIDsByItemParent(UInt64 itemParentUniqueID);
    }
}
