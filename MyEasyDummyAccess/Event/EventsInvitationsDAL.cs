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
    public class EventsInvitationsDAL : MyObjectBaseDAL
    {
        public EInvitationStatus GetInvitationStatus(UInt64 eventUniqueID, string inviteeEmail)
        {
            SqlDataReader sqlReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("select * from EventsInvitations where EventUniqueID = @1 and InviteeEmail = @2", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = eventUniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@2", SqlDbType.VarChar);
                sqlParameter.Value = inviteeEmail;
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

        public void SetInvitationStatus(UInt64 eventUniqueID, string inviteeEmail, EInvitationStatus invitationStatus)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Update EventsInvitations set " +
                    "EInvitationStatus='" + invitationStatus.ToString() + "' " +
                    "Where EventUniqueID='" + eventUniqueID.ToString() + "' and " +
                    "InviteeEmail='" + inviteeEmail + "';");

                sqlCommand.Connection = mSqlConnection;

                int lineInserted = sqlCommand.ExecuteNonQuery();

                if (lineInserted != 1)
                {
                    throw new System.ArgumentException("Update Into EventsInvitations Where EventUniqueID=" + eventUniqueID.ToString() + " failed", "EventUniqueID");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void AddNewInvitation(UInt64 eventUniqueID, string inviteeEmail, EInvitationStatus invitationStatus)
        {
            if (GetInvitationStatus(eventUniqueID, inviteeEmail) != EInvitationStatus.eInvitationNull)
            {
                throw new System.ArgumentException("Invitation Exists alread on Event=" + eventUniqueID.ToString() + " and Email=" + inviteeEmail, "eventUniqueID");
            }

            try
            {
                SqlCommand sqlCommand = new SqlCommand("Insert Into EventsInvitations" +
                    " (EventUniqueID, InviteeEmail, EInvitationStatus) values ('" +
                    eventUniqueID.ToString() + "', '" +
                    inviteeEmail + "', '" +
                    invitationStatus.ToString() + "');");

                sqlCommand.Connection = mSqlConnection;

                int lineInserted = sqlCommand.ExecuteNonQuery();

                if (lineInserted != 1)
                {
                    throw new System.ArgumentException("Insert Into EventsInvitations eventUniqueID=" + eventUniqueID.ToString() + " failed", "eventUniqueID");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        public List<EventBase> GetInvitedEvents(string inviteeEmail, EInvitationStatus invitationStatus)
        {
            List<EventBase> invitedEvents = new List<EventBase>();
            SqlDataReader sqlReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("select * from EventsInvitations where InviteeEmail = @1 and EInvitationStatus = @2", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.VarChar);
                sqlParameter.Value = inviteeEmail;
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

        public List<string> GetEmailsInvitationsByStatus(UInt64 eventUniqueID, EInvitationStatus invitationStatus)
        {
            List<string> emailsInvitations = new List<string>();
            SqlDataReader sqlReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("select * from EventsInvitations where EventUniqueID = @1 and EInvitationStatus = @2", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = eventUniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@2", SqlDbType.VarChar);
                sqlParameter.Value = invitationStatus.ToString();
                sqlCommand.Parameters.Add(sqlParameter);

                sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    emailsInvitations.Add(sqlReader["InviteeEmail"].ToString());
                }

                sqlReader.Close();
                return emailsInvitations;
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
            return ObjectBaseExists(eventUniqueID, "EventsInvitations", "EventUniqueID");
        }

        protected void DeleteInternal(UInt64 eventUniqueID)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("delete from EventsInvitations where " +
                            "EventUniqueID = '" + eventUniqueID.ToString() + "';");

                sqlCommand.Connection = mSqlConnection;

                int lineRemoved = sqlCommand.ExecuteNonQuery();

                if (lineRemoved != 1)
                {
                    throw new System.ArgumentException("Delete from EventsInvitations Where EventUniqueID=" + eventUniqueID.ToString() + " failed", "eventUniqueID");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
