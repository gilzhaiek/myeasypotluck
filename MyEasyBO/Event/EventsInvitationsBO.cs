using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.Event;
using MyEasyDAL.Event;
using MyEasy.Common;

namespace MyEasyBO.Event
{
    public class EventsInvitationsBO
    {
        #region Members

        EventsInvitationsDAL mEventsInvitationsDAL = new EventsInvitationsDAL();

        #endregion

        public EInvitationStatus GetInvitationStatus(UInt64 eventUniqueID, string inviteeEmail)
        {
            return mEventsInvitationsDAL.GetInvitationStatus(eventUniqueID, inviteeEmail);
        }

        public void CreateNewInvitation(UInt64 eventUniqueID, string inviteeEmail)
        {
            mEventsInvitationsDAL.AddNewInvitation(eventUniqueID, inviteeEmail, EInvitationStatus.eInvitationPending);
        }

        public List<EventBase> GetInvitedEvents(string inviteeEmail)
        {
            return mEventsInvitationsDAL.GetInvitedEvents(inviteeEmail, EInvitationStatus.eInvitationPending);
        }

        public List<string> GetPendingEmailsInvitations(UInt64 eventUniqueID)
        {
            return mEventsInvitationsDAL.GetEmailsInvitationsByStatus(eventUniqueID, EInvitationStatus.eInvitationPending);
        }

        public void AcceptInvitation(UInt64 eventUniqueID, string inviteeEmail)
        {
            EInvitationStatus currentInvitationStatus = GetInvitationStatus(eventUniqueID, inviteeEmail);
            if (currentInvitationStatus != EInvitationStatus.eInvitationPending)
            {
                throw new System.ArgumentException("AcceptInvitation for EventUniqueID=" + eventUniqueID.ToString() + " failed", "EventUniqueID");
            }

            mEventsInvitationsDAL.SetInvitationStatus(eventUniqueID, inviteeEmail, EInvitationStatus.eInvitationAccepted);
        }

        public void RejectInvitation(UInt64 eventUniqueID, string inviteeEmail)
        {
            mEventsInvitationsDAL.SetInvitationStatus(eventUniqueID, inviteeEmail, EInvitationStatus.eInvitationRejected);
        }


        public void Delete(UInt64 eventUniqueID)
        {
            mEventsInvitationsDAL.Delete(eventUniqueID);
        }

    }
}
