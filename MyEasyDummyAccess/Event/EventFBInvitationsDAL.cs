using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasy.Common;
using System.Data.SqlClient;
using System.Data;
using MyEasyObjects.Event;

namespace MyEasyDAL.Event
{
    public class EventFBInvitationsDAL : MyObjectBaseDAL
    {
        public EInvitationStatus GetInvitationStatus(UInt64 eventUniqueID, UInt64 fbUserUniqueID)
        {
            SqlDataReader sqlReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("select * from EventsFBInvitations where EventUniqueID = @1 and FBUserUniqueID = @2", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = eventUniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@2", SqlDbType.BigInt);
                sqlParameter.Value = fbUserUniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlReader = sqlCommand.ExecuteReader();
                if (sqlReader.Read())
                {
                    EInvitationStatus invitationStatus = (EInvitationStatus)Enum.Parse(typeof(EInvitationStatus), sqlReader["EInvitationStatus"].ToString());
                    sqlReader.Close();
                    return invitationStatus;
                }
                else
                {
                    sqlReader.Close();
                    return EInvitationStatus.eInvitationNull;
                }
            }
            catch (Exception exception)
            {
                sqlReader.Close();
                throw exception;
            }
        }

        public void SetInvitationStatus(UInt64 eventUniqueID, UInt64 fbUserUniqueID, EInvitationStatus invitationStatus)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Update EventsFBInvitations set " +
                    "EInvitationStatus='" + invitationStatus.ToString() + "' " +
                    "Where EventUniqueID='" + eventUniqueID.ToString() + "' and " +
                    "FBUserUniqueID='" + fbUserUniqueID.ToString() + "';");

                sqlCommand.Connection = mSqlConnection;

                int lineInserted = sqlCommand.ExecuteNonQuery();

                if (lineInserted != 1)
                {
                    throw new System.ArgumentException("Update Into EventsFBInvitations Where EventUniqueID=" + eventUniqueID.ToString() + " failed", "EventUniqueID");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void AddNewInvitation(UInt64 eventUniqueID, UInt64 fbUserUniqueID, EInvitationStatus invitationStatus)
        {
            if (GetInvitationStatus(eventUniqueID, fbUserUniqueID) != EInvitationStatus.eInvitationNull)
            {
                //throw new System.ArgumentException("Invitation Exists alread on Event=" + eventUniqueID.ToString() + " and FBUserUniqueID=" + fbUserUniqueID.ToString(), "eventUniqueID");
                return;
            }

            try
            {
                SqlCommand sqlCommand = new SqlCommand("Insert Into EventsFBInvitations" +
                    " (EventUniqueID, FBUserUniqueID, EInvitationStatus) values ('" +
                    eventUniqueID.ToString() + "', '" +
                    fbUserUniqueID.ToString() + "', '" +
                    invitationStatus.ToString() + "');");

                sqlCommand.Connection = mSqlConnection;

                int lineInserted = sqlCommand.ExecuteNonQuery();

                if (lineInserted != 1)
                {
                    throw new System.ArgumentException("Insert Into EventsFBInvitations eventUniqueID=" + eventUniqueID.ToString() + " failed", "eventUniqueID");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        public List<EventBase> GetInvitedEvents(UInt64 fbUserUniqueID, EInvitationStatus invitationStatus)
        {
            List<EventBase> invitedEvents = new List<EventBase>();
            SqlDataReader sqlReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("select * from EventsFBInvitations where FBUserUniqueID = @1 and EInvitationStatus = @2", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = fbUserUniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@2", SqlDbType.VarChar);
                sqlParameter.Value = invitationStatus.ToString();
                sqlCommand.Parameters.Add(sqlParameter);

                sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    invitedEvents.Add(new EventBase(Convert.ToUInt64(sqlReader["EventUniqueID"].ToString())));
                }

                sqlReader.Close();
                return invitedEvents;
            }
            catch (Exception exception)
            {
                sqlReader.Close();
                throw exception;
            }
        }

        public List<UInt64> GetFBUniqueIDInvitationsByStatus(UInt64 eventUniqueID, EInvitationStatus invitationStatus)
        {
            List<UInt64> fbUniqueIDInvitations = new List<UInt64>();
            SqlDataReader sqlReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("select * from EventsFBInvitations where EventUniqueID = @1 and EInvitationStatus = @2", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = eventUniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@2", SqlDbType.VarChar);
                sqlParameter.Value = invitationStatus.ToString();
                sqlCommand.Parameters.Add(sqlParameter);

                sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    fbUniqueIDInvitations.Add(UInt64.Parse(sqlReader["FBUserUniqueID"].ToString()));
                }

                sqlReader.Close();
                return fbUniqueIDInvitations;
            }
            catch (Exception exception)
            {
                sqlReader.Close();
                throw exception;
            }
        }

        public List<UInt64> GetInvitedFBGuests(UInt64 eventUniqueID)
        {
            List<UInt64> fbUniqueIDInvitations = new List<UInt64>();
            SqlDataReader sqlReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("select * from EventsFBInvitations where EventUniqueID = @1", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = eventUniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    fbUniqueIDInvitations.Add(UInt64.Parse(sqlReader["FBUserUniqueID"].ToString()));
                }

                sqlReader.Close();
                return fbUniqueIDInvitations;
            }
            catch (Exception exception)
            {
                sqlReader.Close();
                throw exception;
            }
        }


        public void Delete(UInt64 eventUniqueID)
        {
            if (EventsInvitationExists(eventUniqueID))
            {
                DeleteInternal(eventUniqueID);
            }
            else
                throw new System.ArgumentException("eventBase does not exists while removing EventBase", "eventBase");
        }

        public bool EventsInvitationExists(UInt64 eventUniqueID)
        {
            return ObjectBaseExists(eventUniqueID, "EventsFBInvitations", "EventUniqueID");
        }

        protected void DeleteInternal(UInt64 eventUniqueID)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("delete from EventsFBInvitations where " +
                            "EventUniqueID = '" + eventUniqueID.ToString() + "';");

                sqlCommand.Connection = mSqlConnection;

                int lineRemoved = sqlCommand.ExecuteNonQuery();

                if (lineRemoved != 1)
                {
                    throw new System.ArgumentException("Delete from EventsFBInvitations Where EventUniqueID=" + eventUniqueID.ToString() + " failed", "eventUniqueID");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
