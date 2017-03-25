using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.Resource;
using MyEasy.Common;
using MyEasyIDAL.Event;
using System.IO;
using MyEasyObjects.Event;
using System.Data.SqlClient;
using System.Data;

namespace MyEasyDAL.Event
{
    public class EventTimeInfoDAL : MyObjectBaseDAL, EventTimeInfoIDAL
    {
        public bool IsLatest(EventTimeInfo eventTimeInfo)
        {
            EventTimeInfo upToDateEventTimeInfo = new EventTimeInfo();

            Load(upToDateEventTimeInfo, eventTimeInfo.UniqueID);

            return (upToDateEventTimeInfo.LastDALChange == eventTimeInfo.LastDALChange);
        }

        // Exceptions:
        //	System.ArgumentException:
        //		eventTimeInfo is null when saving EventTimeInfo
        public void Save(EventTimeInfo eventTimeInfo)
        {
            if (eventTimeInfo.IsNull)
            {
                throw new System.ArgumentException("eventTimeInfo is null when saving EventTimeInfo", "eventTimeInfo");
            }

            if (EventTimeInfoExists(eventTimeInfo.UniqueID))
            {
                EventTimeInfo upToDateItemBase = new EventTimeInfo();

                try
                {
                    Load(upToDateItemBase, eventTimeInfo.UniqueID);
                }
                catch
                {
                    SaveInternal(eventTimeInfo);
                    return;
                }

                if (eventTimeInfo.CompareTo(upToDateItemBase) != 0)
                    UpdateInternal(eventTimeInfo);
            }
            else
                SaveInternal(eventTimeInfo);
        }

        public void Delete(EventTimeInfo eventTimeInfo)
        {
            if (eventTimeInfo.IsNull)
            {
                throw new System.ArgumentException("eventTimeInfo is null when removing EventTimeInfo", "eventTimeInfo");
            }

            if (EventTimeInfoExists(eventTimeInfo.UniqueID))
            {
                DeleteInternal(eventTimeInfo);
            }
            else
                throw new System.ArgumentException("eventTimeInfo does not exists while removing EventTimeInfo", "eventTimeInfo");
        }

        public bool EventTimeInfoExists(UInt64 uniqueID)
        {
            SqlDataReader sqlReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                bool rValue;
                sqlCommand = new SqlCommand("select * from EventTimeInfo where EventUniqueID = @1", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = uniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlReader = sqlCommand.ExecuteReader();
                rValue = sqlReader.Read();

                return rValue;
            }
            catch (Exception exception)
            {
                sqlReader.Close();
                throw exception;
            }
            finally
            {
                sqlReader.Close();
                mSqlConnection.Close();
            }
        }

        protected void DeleteInternal(EventTimeInfo eventTimeInfo)
        {
            try
            {
                eventTimeInfo.LastDALChange = DateTime.Now.Ticks;

                SqlCommand sqlCommand = new SqlCommand("delete from EventTimeInfo where " +
                            "EventUniqueID = '" + eventTimeInfo.EventUniqueID.ToString() + "';");

                sqlCommand.Connection = mSqlConnection;

                int lineRemoved = sqlCommand.ExecuteNonQuery();

                if (lineRemoved != 1)
                {
                    throw new System.ArgumentException("Delete from EventTimeInfo Where EventUniqueID=" + eventTimeInfo.EventUniqueID.ToString() + " failed", "EventUniqueID");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                mSqlConnection.Close();
            }
        }

        public void Load(EventTimeInfo eventTimeInfo, UInt64 eventUniqueID)
        {
            SqlDataReader sqlReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("select * from EventTimeInfo where EventUniqueID = @1", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = eventUniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlReader = sqlCommand.ExecuteReader();
                if (!sqlReader.Read())
                {
                    throw new System.ArgumentException("eventTimeInfo with EventUniqueID=" + eventUniqueID.ToString() + " was not found", "eventUniqueID");
                }

                eventTimeInfo.EventUniqueID = eventUniqueID;
                eventTimeInfo.LastDALChange = Convert.ToInt64(sqlReader["LastDALChange"].ToString());
                eventTimeInfo.CreationTime = new DateTime(Convert.ToInt64(sqlReader["CreationTime"].ToString()));
                eventTimeInfo.BecomeActive = new DateTime(Convert.ToInt64(sqlReader["BecomeActive"].ToString()));
                eventTimeInfo.BecomeInactive = new DateTime(Convert.ToInt64(sqlReader["BecomeInactive"].ToString()));

                if (sqlReader.Read())
                {
                    throw new ArgumentException("Multiple EventUniqueID=" + eventUniqueID.ToString() + " were found in EventTimeInfo", "eventUniqueID");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                sqlReader.Close();
                mSqlConnection.Close();
            }
        }

        protected void UpdateInternal(EventTimeInfo eventTimeInfo)
        {
            try
            {
                eventTimeInfo.LastDALChange = DateTime.Now.Ticks;

                SqlCommand sqlCommand = new SqlCommand("Update EventTimeInfo set " +
                    "LastDALChange='" + eventTimeInfo.LastDALChange.ToString() + "'," +
                    "CreationTime='" + eventTimeInfo.CreationTime.Value.Ticks.ToString() + "'," +
                    "BecomeActive='" + eventTimeInfo.BecomeActive.Value.Ticks.ToString() + "'," +
                    "BecomeInactive='" + eventTimeInfo.BecomeInactive.Value.Ticks.ToString() + "' " +
                    "Where EventUniqueID='" + eventTimeInfo.EventUniqueID.ToString() + "'");

                sqlCommand.Connection = mSqlConnection;

                int lineInserted = sqlCommand.ExecuteNonQuery();

                if (lineInserted != 1)
                {
                    throw new System.ArgumentException("Update Into EventTimeInfo Where EventUniqueID=" + eventTimeInfo.UniqueID.ToString() + " failed", "EventUniqueID");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                mSqlConnection.Close();
            }
        }

        protected void SaveInternal(EventTimeInfo eventTimeInfo)
        {
            try
            {
                eventTimeInfo.LastDALChange = DateTime.Now.Ticks;

                SqlCommand sqlCommand = new SqlCommand("Insert Into EventTimeInfo" +
                    " (EventUniqueID, LastDALChange, CreationTime, BecomeActive, BecomeInactive) values ('" +
                    eventTimeInfo.EventUniqueID.ToString() + "', '" +
                    eventTimeInfo.LastDALChange.ToString() + "', '" +
                    eventTimeInfo.CreationTime.Value.Ticks.ToString() + "', '" +
                    eventTimeInfo.BecomeActive.Value.Ticks.ToString() + "', '" +
                    ((eventTimeInfo.BecomeInactive != null) ?
                        eventTimeInfo.BecomeInactive.Value.Ticks.ToString() :
                        "0") + "');");

                sqlCommand.Connection = mSqlConnection;

                int lineInserted = sqlCommand.ExecuteNonQuery();

                if (lineInserted != 1)
                {
                    throw new System.ArgumentException("Insert Into EventTimeInfo UniqueID=" + eventTimeInfo.EventUniqueID + " failed", "eventTimeInfo");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                mSqlConnection.Close();
            }
        }
    }
}
