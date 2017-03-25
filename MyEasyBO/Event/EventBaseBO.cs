using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyBO.ResourceBO;
using MyEasyBO.Object;
using MyEasyDAL.Event;
using MyEasyObjects.Event;
using MyEasyObjects.User;
using MyEasyObjects.Resource;
using MyEasy.Common;
using MyEasyObjects.Object;
using MyEasyDAL.Item;
using MyEasyObjects.Item;
using MyEasyBO.Item;
using MyEasyBO.HoldingBO;
using MyEasyObjects.Holding;

namespace MyEasyBO.Event
{
    public class EventBaseBO : ResourceBaseBO
    {
        #region Members

        EventBaseDAL mEventBaseDAL = new EventBaseDAL();
        ItemBaseDAL mItemBaseDAL = new ItemBaseDAL();
        ItemBaseBO mItemBaseBO = new ItemBaseBO();
        EventTimeInfoBO mEventTimeInfoBO = new EventTimeInfoBO();
        ObjectLocationBO mEventLocationBO = new ObjectLocationBO();
        ResourceDescriptionBO mResourceDescriptionBO = new ResourceDescriptionBO();
        HoldingsInfoBO mHoldingsInfoBO = new HoldingsInfoBO();
        EventsInvitationsBO mEventsInvitationsBO = new EventsInvitationsBO();

        #endregion

        #region Functions

        public void ClearValues(EventBase eventBase)
        {
            // ResourceBase
            base.ClearValues((ResourceBase)eventBase);

            // EventBase
            eventBase.EventParent = new EventBase();
            eventBase.EventChildren.Clear();
            eventBase.ItemChildren.Clear();
            eventBase.EventTimeInfo = new EventTimeInfo();
            eventBase.EventLocation = new ObjectLocation();
            eventBase.IsPublic = false;
        }

        public void Delete(EventBase eventBase)
        {
            mEventsInvitationsBO.Delete(eventBase.UniqueID);

            mEventLocationBO.Delete(eventBase.EventLocation);

            mResourceDescriptionBO.Delete(eventBase.ResourceDescription);

            mEventTimeInfoBO.Delete(eventBase.EventTimeInfo);

            foreach (HoldingsInfo holdingsInfo in eventBase.HoldingsInfo)
            {
                mHoldingsInfoBO.Delete(holdingsInfo);
            }

            foreach (ItemBase itemBase in eventBase.ItemChildren)
            {
                mItemBaseBO.Delete(itemBase);
            }

            foreach (EventBase eventChildran in eventBase.EventChildren)
            {
                Delete(eventChildran);
            }

            mEventBaseDAL.Delete(eventBase);
        }

        public void Save(EventBase eventBase)
        {
            mEventLocationBO.Save(eventBase.EventLocation);

            mEventBaseDAL.Save(eventBase);

            mResourceDescriptionBO.Save(eventBase.ResourceDescription);

            mEventTimeInfoBO.Save(eventBase.EventTimeInfo);

            foreach (HoldingsInfo holdingsInfo in eventBase.HoldingsInfo)
            {
                mHoldingsInfoBO.Save(holdingsInfo);
            }
        }

        public List<UInt64> GetEventsUniqueIDByAdminUniqueID(UInt64 adminUniqueID)
        {
            return mEventBaseDAL.GetEventsUniqueIDByAdminUniqueID(adminUniqueID);
        }

        public List<UInt64> GetEventsUniqueIDByHolderUniqueID(UInt64 holdingUserUniqueID)
        {
            return mHoldingsInfoBO.GetEventsUniqueIDByHolderUniqueID(holdingUserUniqueID);
        }

        // Exceptions:
        //	System.ArgumentException:
        //		eventBase is null when loading EventBase
        //		Load Failed
        public void Load(EventBase eventBase, UserBase currentUser, bool loadChildren = true)
        {
            try
            {
                if (eventBase.IsNull)
                {
                    throw new System.ArgumentException("eventBase is null when loading EventBase", "eventBase");
                }

                LoadInternal(eventBase, currentUser, loadChildren);
            }
            catch
            {
                throw new System.ArgumentException("Load Failed", "eventBase");
            }
        }

        public bool EventExists(UInt64 uniqueID)
        {
            return mEventBaseDAL.EventBaseExists(uniqueID);
        }

        // Exceptions:
        //	System.ArgumentException:
        //		Load Failed
        // currentUser is to check validation
        protected void LoadInternal(EventBase eventBase, UserBase currentUser, bool loadChildren)
        {
            try
            {
                mEventBaseDAL.Load(eventBase, eventBase.UniqueID);

                mEventTimeInfoBO.Load(eventBase.EventTimeInfo);

                mEventLocationBO.Load(eventBase.EventLocation);

                mResourceDescriptionBO.Load(eventBase.ResourceDescription);

                if (loadChildren)
                {
                    List<UInt64> uniqueIDs = mEventBaseDAL.GetChildrenUniqueIDs(eventBase.UniqueID);
                    foreach (UInt64 tempUniqueID in uniqueIDs)
                    {
                        EventBase childEventBase = new EventBase(tempUniqueID);
                        Load(childEventBase, currentUser);
                        eventBase.EventChildren.Add(childEventBase);
                    }

                    uniqueIDs = mItemBaseDAL.GetChildrenUniqueIDsByEventParent(eventBase.UniqueID);
                    foreach (UInt64 tempUniqueID in uniqueIDs)
                    {
                        ItemBase childItemBase = new ItemBase(tempUniqueID);
                        mItemBaseBO.Load(childItemBase);
                        eventBase.ItemChildren.Add(childItemBase);
                    }

                    uniqueIDs = mHoldingsInfoBO.GetUniqueIDsByEventOwner(eventBase.UniqueID);
                    foreach (UInt64 tempUniqueID in uniqueIDs)
                    {
                        HoldingsInfo holdingsInfo = new HoldingsInfo(tempUniqueID);
                        mHoldingsInfoBO.Load(holdingsInfo);  // Should I load it here??
                        eventBase.HoldingsInfo.Add(holdingsInfo);
                    }
                }
            }
            catch
            {
                throw new System.ArgumentException("Load Failed", "eventBase");
            }
        }

        public bool IsLatest(EventBase eventBase, bool checkRelations)
        {
            return mEventBaseDAL.IsLatest(eventBase, checkRelations);
        }

        public void GetLatest(EventBase eventBase, UserBase currentUser)
        {
            if (!mEventBaseDAL.IsLatest(eventBase, true))
                Load(eventBase, currentUser);
        }

        #endregion

    }
}
