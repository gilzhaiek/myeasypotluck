using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using MyEasyObjects.User;
using MyEasyBO.Event;
using MyEasyBO.UserBO;
using MyEasyObjects.Event;
using System.Globalization;
using MyEasyObjects.Holding;
using MyEasyObjects.Item;
using MyEasyBO.Item;
using MyEasyBO.HoldingBO;
using MyEasy.Common;

/// <summary>
/// Summary description for EventBriefWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
[ScriptService]
public class EventBriefWebService : System.Web.Services.WebService
{
	#region Members

	bool					mIsInit			= false;
	UserBase				mCurrentUser	= null;
	EventBaseBO				mEventBaseBO	= null;
	UserBaseBO				mUserBaseBO		= null;
	ItemBaseBO				mItemBaseBO		= null;
	HoldingsInfoBO			mHoldingsInfoBO = null;
    EventsInvitationsBO     mEventsInvitationsBO = null;
	

	#endregion

	public EventBriefWebService()
	{
		mEventBaseBO			= new EventBaseBO();
		mUserBaseBO				= new UserBaseBO();
		mItemBaseBO				= new ItemBaseBO();
		mHoldingsInfoBO			= new HoldingsInfoBO();
        mEventsInvitationsBO    = new EventsInvitationsBO();
	}

	private void InitMembers()
	{
		mCurrentUser	= (UserBase)Session["CurrentUser"];

		if(mCurrentUser != null)
		{
			if(mCurrentUser.IsNull)
				mCurrentUser = null;
		}

		if(mEventBaseBO	== null)
			mEventBaseBO = new EventBaseBO();

		if(mUserBaseBO	== null)
			mUserBaseBO = new UserBaseBO();

        if (mEventsInvitationsBO == null)
            mEventsInvitationsBO = new EventsInvitationsBO();

        if (mHoldingsInfoBO == null)
            mHoldingsInfoBO = new HoldingsInfoBO();

        mIsInit = true;
	}

	protected EventBase FindEventInPool(UInt64 uniqueID)
	{
		return (EventBase)Session["EVENT_" + uniqueID.ToString()];
	}

	protected void AddEventToPool(EventBase userBase)
	{
		Session["EVENT_" + userBase.UniqueID.ToString()] = userBase;
	}

	protected EventBase GetEventBase(UInt64 uniqueID)
	{
		EventBase retEventBase = null; //FindEventInPool(uniqueID);
		if(retEventBase == null)
		{
			retEventBase = new EventBase(uniqueID);
			mEventBaseBO.Load(retEventBase, mCurrentUser);
			//AddEventToPool(retEventBase);
		}

		return retEventBase;
	}

	protected string GetEventHTMLStr(EventBase eventBase)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentUser == null)
			return "User is not Loaded";

        if (!eventBase.IsLoaded())
            mEventBaseBO.Load(eventBase, mCurrentUser);

        string uID = eventBase.UniqueID.ToString();

		string infoStr = "";

		if(eventBase.EventTimeInfo.BecomeActive.Value.Year != 1)
		{
            infoStr += eventBase.EventTimeInfo.BecomeActive.Value.ToString("d-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
			if(eventBase.EventTimeInfo.BecomeInactive.Value.Year != 1)
			{
				string toStr = eventBase.EventTimeInfo.BecomeInactive.Value.ToString("d-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
                if (toStr == infoStr)
                    infoStr = " At " + infoStr;
				else
                    infoStr += " to " + toStr;
			}
		}

        if(mCurrentUser.UniqueID != eventBase.Admin.UniqueID)
        {
            if(!eventBase.Admin.IsLoaded())
                mUserBaseBO.Load(eventBase.Admin);

            infoStr += "  <i>(" + eventBase.Admin.FirstName + " " + eventBase.Admin.LastName + ")</i>"; 
        }

        return "<div class=\"myEventsTopicItems\" id=\"event_h_" + uID + "\" onclick=\"EventClicked('" + uID + "');\"" +
                "onmouseover=\"EventMouseOver('" + uID + "');\" onmouseout=\"EventMouseOut('" + uID + "');\"" +
                "><span>&nbsp;" + eventBase.ResourceDescription.Topic + "<div style=\"font-size:0.5em;text-align: center;\">" + infoStr + "</div></span></div>" +
                "<div class=\"myEventsDescriptionItems\" style=\"display: none;\" id=\"event_d_" + uID + "\" onclick=\"EventClicked('" + uID + "');\"" +
                "onmouseover=\"EventMouseOver('" + uID + "');\" onmouseout=\"EventMouseOut('" + uID + "');\"" +
				"><span>" + eventBase.ResourceDescription.Summary.Replace("\n", "<br/>") + "</span></div>";

	}

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string AcceptInvite(string uniqueID)
    {
        if (!mIsInit)
            InitMembers();

        if (mCurrentUser == null)
            return "User is not Loaded";

        UInt64 uID = UInt64.Parse(uniqueID);

        mEventsInvitationsBO.AcceptInvitation(uID, mCurrentUser.Email);

        EventBase eventBase = GetEventBase(uID);

        // Add Holding Info
        HoldingsInfo holdingsInfo = new HoldingsInfo();
        holdingsInfo.HoldingUser = mCurrentUser;
        holdingsInfo.HoldingUserPermissions = EHoldingPermissions.eParticipator;
        holdingsInfo.EventOwner = eventBase;

        mHoldingsInfoBO.Save(holdingsInfo);

        eventBase.HoldingsInfo.Add(holdingsInfo);

        mCurrentUser.Events.Add(eventBase);

        return "";
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string RejectInvite(string uniqueID)
    {
        if (!mIsInit)
            InitMembers();

        if (mCurrentUser == null)
            return "User is not Loaded";

        mEventsInvitationsBO.RejectInvitation(UInt64.Parse(uniqueID), mCurrentUser.Email);

        return "";
    }
    

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string GetEventsHTMLStr()
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentUser == null)
			return "User is not Loaded";

		string retHTMLStr = "";

        Session["CurrentEvent"] = null;

		for(int i = mCurrentUser.Events.Count - 1; i >= 0; i--)
		{
			retHTMLStr += GetEventHTMLStr(mCurrentUser.Events[i]);
		}

		return retHTMLStr ;
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetInvitationsHTMLStr()
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentUser == null)
			return "User is not Loaded";

		string retHTMLStr = "";

        List<EventBase> invitedEvents = mEventsInvitationsBO.GetInvitedEvents(mCurrentUser.Email);

        foreach (EventBase eventBase in invitedEvents)
        {
            if (!mEventBaseBO.EventExists(eventBase.UniqueID))
                continue;

            if (!eventBase.IsLoaded())
                mEventBaseBO.Load(eventBase, mCurrentUser);

            if (!mUserBaseBO.UserExists(eventBase.Admin.UniqueID))
                continue;

            if (!eventBase.Admin.IsLoaded())
                mUserBaseBO.Load(eventBase.Admin);

            string uID = eventBase.UniqueID.ToString();

            retHTMLStr += "<div class=\"myInvitedEvents\" id=\"invited_" + uID + "\" onclick=\"InvitationClicked('" + uID + "');\"" +
                    "onmouseover=\"InvitationMouseOver('" + uID + "');\" onmouseout=\"InvitationMouseOut('" + uID + "');\"" +
                    "><span>&nbsp;" + eventBase.ResourceDescription.Topic +
                    "<div style=\"font-size:0.75em;margin-left:3px;\">Invited by " + eventBase.Admin.FirstName + " " + eventBase.Admin.LastName + "</div></span></div>";
        }

		return retHTMLStr ;
	}

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string DeleteEvent(string uniqueID)
    {
        if (!mIsInit)
            InitMembers();

        if (mCurrentUser == null)
            return "User is not Loaded";

        string retStr = SetCurrentEvent(uniqueID);
        
        if (retStr.Length > 0)
            return retStr;

        EventBase eventBase = (EventBase)Session["CurrentEvent"];

        foreach (EventBase userEventBase in mCurrentUser.Events)
        {
            if (eventBase.UniqueID == userEventBase.UniqueID)
            {
                mCurrentUser.Events.Remove(userEventBase);
                break;
            }
        }

        if (eventBase.Admin.UniqueID != mCurrentUser.UniqueID)
        {
            foreach (ItemBase itemBase in eventBase.ItemChildren)
            {
                if (!itemBase.IsLoaded())
                    mItemBaseBO.Load(itemBase);

                foreach (HoldingsInfo holdingsInfo in itemBase.HoldingsInfo)
                {
                    if (!holdingsInfo.IsLoaded())
                        mHoldingsInfoBO.Load(holdingsInfo);

                    if (holdingsInfo.HoldingUser.UniqueID == mCurrentUser.UniqueID)
                    {
                        holdingsInfo.HoldingUser = new UserBase();
                        holdingsInfo.HoldingUser.UniqueID = 0;
                        mHoldingsInfoBO.Save(holdingsInfo);
                    }
                }
            }

            foreach (HoldingsInfo holdingsInfo in eventBase.HoldingsInfo)
            {
                if (!holdingsInfo.IsLoaded())
                    mHoldingsInfoBO.Load(holdingsInfo);

                if (holdingsInfo.HoldingUser.UniqueID == mCurrentUser.UniqueID)
                {
                    mHoldingsInfoBO.Delete(holdingsInfo);
                    break;
                }
            }
        }
        else // Admin
        {
            mEventBaseBO.Delete(eventBase);
        }

        Session["CurrentUser"] = mCurrentUser;

        return "";
    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string SetCurrentEvent(string uniqueID)
    {
        if (!mIsInit)
            InitMembers();

        if (mCurrentUser == null)
            return "User is not Loaded";

        EventBase eventBase = (EventBase)Session["CurrentEvent"];
        if (eventBase == null)
        {
            eventBase = GetEventBase(UInt64.Parse(uniqueID));
            Session["CurrentEvent"] = eventBase;
        }
        else if (eventBase.UniqueID.ToString() != uniqueID)
        {
            eventBase = GetEventBase(UInt64.Parse(uniqueID));
            Session["CurrentEvent"] = eventBase;
        }

        return "";
    }
	
	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string GetCurrentEventTopic(string uniqueID)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentUser == null)
			return "User is not Loaded";

        EventBase eventBase = (EventBase)Session["CurrentEvent"];

        if (eventBase == null)
        {
            eventBase = GetEventBase(UInt64.Parse(uniqueID));
            Session["CurrentEvent"] = eventBase;
        }
        else if (eventBase.UniqueID.ToString() != uniqueID)
        {
            eventBase = GetEventBase(UInt64.Parse(uniqueID));
            Session["CurrentEvent"] = eventBase;
        }

		return eventBase.ResourceDescription.Topic;
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string GetCurrentEventDetails(string uniqueID)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentUser == null)
			return "User is not Loaded";

        EventBase eventBase = (EventBase)Session["CurrentEvent"];
        if (eventBase == null)
        {
            eventBase = GetEventBase(UInt64.Parse(uniqueID));
            Session["CurrentEvent"] = eventBase;
        }
        else if (eventBase.UniqueID.ToString() != uniqueID)
        {
            eventBase = GetEventBase(UInt64.Parse(uniqueID));
            Session["CurrentEvent"] = eventBase;
        }

        string retDesc = "";

		if(eventBase.EventTimeInfo.BecomeActive.Value.Year != 1)
		{
			retDesc += eventBase.EventTimeInfo.BecomeActive.Value.ToString("d-MMM-yyyy hh:mm tt", CultureInfo.CreateSpecificCulture("en-US"));
		}
		else
		{
			retDesc += " --- ";
		}

		if(eventBase.EventTimeInfo.BecomeInactive.Value.Year != 1)
		{
			retDesc += "(#)" + eventBase.EventTimeInfo.BecomeInactive.Value.ToString("d-MMM-yyyy hh:mm tt", CultureInfo.CreateSpecificCulture("en-US"));
		}
		else
		{
			retDesc += "(#) --- ";
		}

		// Friends
		retDesc += "(#)" + eventBase.HoldingsInfo.Count;

		// Items
		retDesc += "(#)" + eventBase.ItemChildren.Count;

		// Holdings
		int totalEmptyHoldings = 0;
		int totalHoldHoldings = 0;
		foreach(ItemBase itemBase in eventBase.ItemChildren)
		{
			if(!itemBase.IsLoaded())
				mItemBaseBO.Load(itemBase);

			foreach(HoldingsInfo holdingsInfo in itemBase.HoldingsInfo)
			{
				if(!holdingsInfo.IsLoaded())
					mHoldingsInfoBO.Load(holdingsInfo);

				if(holdingsInfo.HoldingUser.UniqueID == 0)
					totalEmptyHoldings++;
				else
					totalHoldHoldings++;
			}
		}
		retDesc += "(#)" + totalHoldHoldings.ToString() + " out of " + (totalHoldHoldings + totalEmptyHoldings).ToString();

		// Location
		if(eventBase.EventLocation.Address1.Length > 26)
			retDesc += "(#)" + eventBase.EventLocation.Address1.Substring(0,25) + "...";
		else
			retDesc += "(#)" + eventBase.EventLocation.Address1;

		retDesc += "(#)" + eventBase.UniqueID.ToString();

		return retDesc;
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string CreateNewEvent(string topic, string description,
		string startDate, string startTime, string finishDate, string finishTime,
		string value, string isPublic)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentUser == null)
			return "User is not Loaded";

		string timeText = "";
		string dateText = "";
		EventBase newEvent = new EventBase();
		DateTime today = DateTime.Today;

		newEvent.Admin = mCurrentUser;
		newEvent.ResourceDescription.Topic		= topic;
		newEvent.ResourceDescription.Summary	= description;
		newEvent.Value = int.Parse(value);
		newEvent.IsPublic = (isPublic == "1") ? true : false;

		timeText = startTime;
		dateText = startDate;
		if(dateText == string.Empty)
			dateText = today.ToString("d-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
		newEvent.EventTimeInfo.BecomeActive		= CommonStaticFunctions.ParseDateTime(dateText, timeText);

		timeText = finishTime;
		dateText = finishDate;
		if(dateText == string.Empty)
			dateText = today.ToString("d-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
		newEvent.EventTimeInfo.BecomeInactive	= CommonStaticFunctions.ParseDateTime(dateText, timeText);
		
		mEventBaseBO.Save(newEvent);

		mCurrentUser.Events.Add(newEvent);

		mUserBaseBO.Save(mCurrentUser);

		Session["CurrentUser"] = mCurrentUser;

		Session["CurrentEvent"] = newEvent;

		return "Success";
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string GetFinishDate(string startDate, string startTime, string finishDate, string finishTime)
	{
		DateTime? dateTimeStart		= CommonStaticFunctions.ParseDateTime(startDate, startTime);
		DateTime? dateTimeFinish	= CommonStaticFunctions.ParseDateTime(finishDate, finishTime);

		if(dateTimeFinish.Value.Ticks < dateTimeStart.Value.Ticks)
			return dateTimeStart.Value.ToString("d-MMM-yyyy!hh:mm tt", CultureInfo.CreateSpecificCulture("en-US"));
		
		return "";
	}
}

