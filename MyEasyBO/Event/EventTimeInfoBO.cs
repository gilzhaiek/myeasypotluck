using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyDAL.Resource;
using MyEasyObjects.Resource;
using MyEasyObjects.Event;
using MyEasyDAL.Event;

namespace MyEasyBO.ResourceBO
{
    public class EventTimeInfoBO
    {
        #region Members

        EventTimeInfoDAL mEventTimeInfoDAL = new EventTimeInfoDAL();

        #endregion

        public void ClearValues(EventTimeInfo eventTimeInfo)
        {
            eventTimeInfo.UniqueID = 0;

            eventTimeInfo.CreationTime = null;

            eventTimeInfo.BecomeActive = null;

            eventTimeInfo.BecomeInactive = null;
        }

        public void Save(EventTimeInfo eventTimeInfo)
        {
            mEventTimeInfoDAL.Save(eventTimeInfo);
        }


        public void Delete(EventTimeInfo eventTimeInfo)
        {
            if (!eventTimeInfo.IsLoaded())
                Load(eventTimeInfo);

            mEventTimeInfoDAL.Delete(eventTimeInfo);
        }

        // Exceptions:
        //	System.ArgumentException:
        //		eventTimeInfo is null when loading EventTimeInfo
        //		Load Failed
        public void Load(EventTimeInfo eventTimeInfo)
        {
            try
            {
                if (eventTimeInfo.IsNull)
                {
                    throw new System.ArgumentException("eventTimeInfo is null when loading EventTimeInfo", "eventTimeInfo");
                }

                LoadInternal(eventTimeInfo);
            }
            catch
            {
                throw new System.ArgumentException("Load Failed", "eventTimeInfo");
            }
        }

        // Exceptions:
        //	System.ArgumentException:
        //		Load Failed
        protected void LoadInternal(EventTimeInfo eventTimeInfo)
        {
            try
            {
                mEventTimeInfoDAL.Load(eventTimeInfo, eventTimeInfo.UniqueID);
            }
            catch
            {
                throw new System.ArgumentException("Load Failed", "eventTimeInfo");
            }
        }
    }
}
