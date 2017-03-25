using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyBO.ResourceBO;
using MyEasyDAL.Item;
using MyEasyBO.Object;
using MyEasyObjects.Resource;
using MyEasyObjects.Item;
using MyEasy.Common;
using MyEasyObjects.Holding;
using MyEasyBO.HoldingBO;
using MyEasyObjects.Event;

namespace MyEasyBO.Item
{
    public class ItemBaseBO : ResourceBaseBO
    {
        #region Members

        ItemBaseDAL mItemBaseDAL = new ItemBaseDAL();
        ResourceDescriptionBO mResourceDescriptionBO = new ResourceDescriptionBO();

        HoldingsInfoBO mHoldingsInfoBO = new HoldingsInfoBO();

        #endregion

        #region Functions

        public void ClearValues(ItemBase itemBase)
        {
            // ResourceBase
            base.ClearValues((ResourceBase)itemBase);

            // ItemBase
            itemBase.ItemParent = new ItemBase();
            itemBase.ItemChildren.Clear();
            itemBase.ThumbNameImage = new NameImage();
            itemBase.FullNameImage = new NameImage();
        }

        public void Save(ItemBase itemBase)
        {
            mItemBaseDAL.Save(itemBase);

            mResourceDescriptionBO.Save(itemBase.ResourceDescription);

            foreach (HoldingsInfo holdingsInfo in itemBase.HoldingsInfo)
            {
                if (holdingsInfo.EventOwner.UniqueID == 0)
                    holdingsInfo.EventOwner.UniqueID = itemBase.EventParent.UniqueID;

                if (holdingsInfo.ItemOwner.UniqueID == 0)
                    holdingsInfo.ItemOwner.UniqueID = itemBase.UniqueID;

                mHoldingsInfoBO.Save(holdingsInfo);
            }
        }

        public void Delete(ItemBase itemBase)
        {
            mResourceDescriptionBO.Delete(itemBase.ResourceDescription);

            foreach (HoldingsInfo holdingsInfo in itemBase.HoldingsInfo)
            {
                mHoldingsInfoBO.Delete(holdingsInfo);
            }

            if (!itemBase.IsLoaded())
                Load(itemBase);

            mItemBaseDAL.Delete(itemBase);
        }

        // Exceptions:
        //	System.ArgumentException:
        //		itemBase is null when loading ItemBase
        //		Load Failed
        public void Load(ItemBase itemBase, bool loadChildren = true)
        {
            try
            {
                if (itemBase.IsNull)
                {
                    throw new System.ArgumentException("itemBase is null when loading ItemBase", "itemBase");
                }

                //mResourceDescriptionBO.Load(itemBase.ResourceDescription);
                LoadInternal(itemBase, loadChildren);
            }
            catch
            {
                throw new System.ArgumentException("Load Failed", "resourceBase");
            }
        }

        // Exceptions:
        //	System.ArgumentException:
        //		Load Failed
        protected void LoadInternal(ItemBase itemBase, bool loadChildren)
        {
            try
            {
                List<UInt64> uniqueIDs;
                //ClearValues(itemBase);  Not sure why I did this

                mItemBaseDAL.Load(itemBase, itemBase.UniqueID);

                try
                {
                    mResourceDescriptionBO.Load(itemBase.ResourceDescription);
                }
                catch
                {
                    itemBase.ResourceDescription = new ResourceDescription(itemBase.UniqueID);
                    mResourceDescriptionBO.Save(itemBase.ResourceDescription);
                }

                if (loadChildren)
                {
                    uniqueIDs = mItemBaseDAL.GetChildrenUniqueIDsByEventParent(itemBase.UniqueID);
                    foreach (UInt64 childUniqueID in uniqueIDs)
                    {
                        ItemBase childItemBase = new ItemBase(childUniqueID);
                        Load(childItemBase);
                        itemBase.ItemChildren.Add(childItemBase);
                    }
                }

                uniqueIDs = mHoldingsInfoBO.GetUniqueIDsByItemOwner(itemBase.UniqueID);
                foreach (UInt64 holdingsUniqueID in uniqueIDs)
                {
                    HoldingsInfo holdingsInfo = new HoldingsInfo(holdingsUniqueID);
                    // mHoldingsInfoBO.Load(holdingsInfo); // No Need to load yet...
                    itemBase.HoldingsInfo.Add(holdingsInfo);
                }
            }
            catch
            {
                throw new System.ArgumentException("Load Failed", "itemBase");
            }
        }

        public bool IsLatest(ItemBase itemBase, bool checkRelations)
        {
            return mItemBaseDAL.IsLatest(itemBase, checkRelations);
        }

        public void GetLatest(ItemBase itemBase)
        {
            if (!mItemBaseDAL.IsLatest(itemBase, true))
                Load(itemBase);
        }

        public HoldingsInfo AddHolding(EventBase eventOwner, ItemBase itemOwner)
        {
            HoldingsInfo holdingsInfo = new HoldingsInfo(0, eventOwner, itemOwner);
            mHoldingsInfoBO.Save(holdingsInfo);

            itemOwner.HoldingsInfo.Add(holdingsInfo);

            return holdingsInfo;
        }

        public HoldingsInfo DeleteHolding(EventBase eventOwner, ItemBase itemOwner, HoldingsInfo holdingsInfo)
        {
            mHoldingsInfoBO.Save(holdingsInfo);

            itemOwner.HoldingsInfo.Add(holdingsInfo);

            return holdingsInfo;
        }

        public int GetItemsCount(UInt64 eventUniqueID)
        {
            return mItemBaseDAL.GetChildrenUniqueIDsByEventParent(eventUniqueID).Count();
        }

        #endregion

    }
}
