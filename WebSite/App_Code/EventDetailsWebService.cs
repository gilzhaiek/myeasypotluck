using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using MyEasyObjects.User;
using MyEasyObjects.Event;
using MyEasyBO.Event;
using MyEasyBO.UserBO;
using MyEasyBO.ResourceBO;
using MyEasy.Common;
using MyEasyObjects.Object;
using MyEasyBO.Object;
using MyEasyObjects.Item;
using MyEasyBO.Item;
using MyEasyObjects.Icons;
using MyEasyBO.HoldingBO;
using MyEasyObjects.Holding;
using System.Text.RegularExpressions;


/// <summary>
/// Summary description for EventDetailsWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
[ScriptService]
public class EventDetailsWebService : System.Web.Services.WebService
{
	#region Members

	bool					mIsInit						= false;
	UserBase				mCurrentUser				= null;
	EventBase				mCurrentEvent				= null;
	EventBaseBO				mEventBaseBO				= null;
	UserBaseBO				mUserBaseBO					= null;
	ResourceDescriptionBO	mResourceDescriptionBO		= null;
	EventTimeInfoBO			mEventTimeInfoBO			= null;
	ObjectLocationBO		mObjectLocationBO			= null;
	UserNameImageList		mCurrentUserNameImageList	= null;
	UserNameImageListBO		mUserNameImageListBO		= null;
	ItemBaseBO				mItemBaseBO					= null;
	HoldingsInfoBO			mHoldingsInfoBO				= null;
	EventsInvitationsBO		mEventsInvitationsBO		= null;
	UsersConnectionBO		mUsersConnectionBO			= null;

	Regex					mEmailRegex					= new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

	#endregion

	public EventDetailsWebService()
	{
		mEventBaseBO			= new EventBaseBO();
		mUserBaseBO				= new UserBaseBO();
		mResourceDescriptionBO	= new ResourceDescriptionBO();
		mEventTimeInfoBO		= new EventTimeInfoBO();
		mObjectLocationBO		= new ObjectLocationBO();
		mUserNameImageListBO	= new UserNameImageListBO();
		mItemBaseBO				= new ItemBaseBO();
		mHoldingsInfoBO			= new HoldingsInfoBO();
		mEventsInvitationsBO	= new EventsInvitationsBO();
		mUsersConnectionBO		= new UsersConnectionBO();

		Session["HoldingsInfoBO"] = mHoldingsInfoBO;

		//Uncomment the following line if using designed components 
		//InitializeComponent(); 
	}

	private void InitMembers()
	{
		mCurrentUser	= (UserBase)Session["CurrentUser"];

		if(mCurrentUser != null)
		{
			if(!mCurrentUser.IsNull)
			{
				mCurrentEvent = (EventBase)Session["CurrentEvent"];
				if(mCurrentEvent != null)
				{
					if(mCurrentEvent.IsNull)
						mCurrentEvent = null;
				}

				mCurrentUserNameImageList = (UserNameImageList)Session["CurrentUserNameImageList"];
				if(mCurrentUserNameImageList != null)
				{
					if(mCurrentEvent.IsNull)
						mCurrentUserNameImageList = null;
				}
				if(mCurrentUserNameImageList == null)
				{
					mCurrentUserNameImageList = new UserNameImageList(mCurrentUser.UniqueID); 
					mUserNameImageListBO.Load(mCurrentUserNameImageList);
					Session["CurrentUserNameImageList"] = mCurrentUserNameImageList;
				}

				mHoldingsInfoBO = (HoldingsInfoBO)Session["HoldingsInfoBO"];
				if(mHoldingsInfoBO == null)
				{
					mHoldingsInfoBO = new HoldingsInfoBO(); 
					Session["HoldingsInfoBO"] = mHoldingsInfoBO;
				}
			}
			else
				mCurrentUser = null;
		}

		mIsInit = true;
	}
	
	protected UserBase FindUserInPool(UInt64 uniqueID)
	{
		return (UserBase)Session["USER_" + uniqueID.ToString()];
	}

	protected void AddUserToPool(UserBase userBase)
	{
		Session["USER_" + userBase.UniqueID.ToString()] = userBase;
	}

	protected UserBase GetUserBase(UInt64 uniqueID)
	{
		UserBase retUserBase = FindUserInPool(uniqueID);
		if(retUserBase == null)
		{
			retUserBase = new UserBase(uniqueID);
			mUserBaseBO.Load(retUserBase);
			AddUserToPool(retUserBase);
		}

		return retUserBase;
	}

	protected ItemBase FindItemInPool(UInt64 uniqueID)
	{
		return (ItemBase)Session["ITEM_" + uniqueID.ToString()];
	}

	protected void AddItemToPool(ItemBase itemBase)
	{
		Session["ITEM_" + itemBase.UniqueID.ToString()] = itemBase;
	}

	protected ItemBase GetItemBase(UInt64 uniqueID)
	{
		ItemBase retItemBase = FindItemInPool(uniqueID);
		if(retItemBase == null)
		{
			retItemBase = new ItemBase(uniqueID);
			mItemBaseBO.Load(retItemBase);
			AddItemToPool(retItemBase);
		}

		return retItemBase;
	}

	protected void UpdateHoldings(UInt64 uniqueID)
	{
	}

	protected bool IsPermitted(EHoldingPermissions holdingPermission)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentUser == null)
			return false;

		if(holdingPermission == EHoldingPermissions.eController)
		{
			if(mCurrentEvent.Admin.UniqueID != mCurrentUser.UniqueID)
				return false;
		}

		return true;
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string ValidateEmailRegex(string email)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentUser == null)
			return "User is not Loaded";

		if(email.Length == 0)
		{
			return "Please enter an email address";
		}

		if(!mEmailRegex.IsMatch(email.Trim()))
		{
			return email + " is not a valid email address";
		}
		
		if(email == mCurrentUser.Email)
			return "Sending an invitation to yourself???";

		EInvitationStatus invitationStatus = mEventsInvitationsBO.GetInvitationStatus(mCurrentEvent.UniqueID, email);

		if(invitationStatus != EInvitationStatus.eInvitationNull)
		{
			if((invitationStatus == EInvitationStatus.eInvitationPending) ||
				(invitationStatus == EInvitationStatus.eInvitationRejected))
			{
				return "Invitation to " + email + " was already sent!";

			}
			else 
			{
				return "Invitation to " + email + " was already accepted!";
			}
		}

		return email;
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string GetUserFullName()
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentUser == null)
			return "User is not Loaded";

		return mCurrentUser.FirstName + " " + mCurrentUser.LastName;
	}

	protected string EventFriendHTMLStr(UInt64 uniqueID, string fullName)
	{
		return "<div class=\"myFriendsItems\" id=\"eventFriend_" +uniqueID.ToString() + "\" onclick=\"EventFriendClicked('" + uniqueID.ToString() + "','" + fullName + "');\"" +
				"onmouseover=\"this.style.background='#B0E0E6'\" onmouseout=\"EventFriendMouseOut('" + uniqueID.ToString() + "');\"" +
				"><span>&nbsp;"+ fullName + "</span></div>";
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string RemoveFriendFromEvent(string uniqueID)
	{
		if(!mIsInit)
			InitMembers();

		if(!IsPermitted(EHoldingPermissions.eController))
			return "User does not have permission";

		if(mCurrentEvent == null)
			return "Event is not Loaded";

		UInt64 uID = UInt64.Parse(uniqueID);
		HoldingsInfo holdingsInfo = null;
		foreach(HoldingsInfo tmpHoldingsInfo in mCurrentEvent.HoldingsInfo)
		{
			if(tmpHoldingsInfo.HoldingUser.UniqueID == uID)
			{
				holdingsInfo = tmpHoldingsInfo;
				break;
			}
		}

		if(holdingsInfo == null)
		{
			return "Friend not found in this event";
		}

		mCurrentEvent.HoldingsInfo.Remove(holdingsInfo);

		try
		{
			mHoldingsInfoBO.Delete(holdingsInfo);
		}
		catch
		{
			return "Failed to remove friend from event";
		}

		return "success";
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string AddFriendToEvent(string uniqueID)
	{
		if(!mIsInit)
			InitMembers();

		if(!IsPermitted(EHoldingPermissions.eController))
			return "User does not have permission";

		if(mCurrentEvent == null)
			return "Event is not Loaded";

		if(mCurrentUser == null)
			return "User is not Loaded";

		UserBase friendUserBase = GetUserBase(UInt64.Parse(uniqueID));

		foreach(HoldingsInfo tmpHoldingsInfo in mCurrentEvent.HoldingsInfo)
		{
			if(tmpHoldingsInfo.HoldingUser.UniqueID == friendUserBase.UniqueID)
				return friendUserBase.FirstName + " " + friendUserBase.LastName + " is alread in this event";
		}

		HoldingsInfo holdingsInfo	= new HoldingsInfo();
		holdingsInfo.HoldingUser	= friendUserBase;
		holdingsInfo.EventOwner		= mCurrentEvent;
		holdingsInfo.UserPermissions.Add(new UserPermission(holdingsInfo.UniqueID, friendUserBase, EHoldingPermissions.eParticipator));

		mHoldingsInfoBO.Save(holdingsInfo);

		mCurrentEvent.HoldingsInfo.Add(holdingsInfo);

		return EventFriendHTMLStr(friendUserBase.UniqueID, friendUserBase.FirstName + " " + friendUserBase.LastName);
	}

	public string PendingEmailHTMLStr(string email)
	{
		return "<div class=\"pendingEmailInviteItems\" id=\"pending_" +email + "\" ><span>&nbsp;"+ email + "</span></div>";
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string CreateEmailInvite(string email, string subject, string body)
	{
		if(!mIsInit)
			InitMembers();

		if(!IsPermitted(EHoldingPermissions.eController))
			return "User does not have permission";

		if(mCurrentUser == null)
			return "User is not Loaded";

		string retValidate = ValidateEmailRegex(email);
		if(retValidate != email)
			return retValidate;

		body = body.Replace("www.myeasypotluck.com", "<a href=\"http://www.myeasypotluck.com/\">www.myeasypotluck.com</a>").Replace("\n", "<br/>");
		EmailSender.SendEmail(EmailSender.EEmailAccount.eEmailInvitation, email, subject, body);
		
		mEventsInvitationsBO.CreateNewInvitation(mCurrentEvent.UniqueID, email);

		return PendingEmailHTMLStr(email);
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string GetPendingEmailsString()
	{
		if(!mIsInit)
			InitMembers();

		if(!IsPermitted(EHoldingPermissions.eController))
			return "User does not have permission";

		if(mCurrentUser == null)
			return "User is not Loaded";

		string htmlStr = "";
		List <string> pendingEmails = mEventsInvitationsBO.GetPendingEmailsInvitations(mCurrentEvent.UniqueID);

		foreach(string email in pendingEmails)
		{
			htmlStr += PendingEmailHTMLStr(email);
		}

		return htmlStr;
	}

	protected string MyFriendHTMLStr(UInt64 uniqueID, string fullName)
	{
		return "<div class=\"myFriendsItems\" id=\"myfriend_" +uniqueID.ToString() + "\" onclick=\"myFriendClicked('" + uniqueID.ToString() + "');\"" +
				"onmouseover=\"this.style.background='#B0E0E6'\" onmouseout=\"myFriendMouseOut('" + uniqueID.ToString() + "');\"" +
				"><span>&nbsp;"+ fullName + "</span></div>";
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string GetFriendsString()
	{
		if(!mIsInit)
			InitMembers();

		if(!IsPermitted(EHoldingPermissions.eController))
			return "User does not have permission";

		if(mCurrentUser == null)
			return "User is not Loaded";

		string htmlStr = "";
		List<UInt64> connectionUniqueIDList = mUsersConnectionBO.GetConnections(mCurrentUser.UniqueID);

		foreach(UInt64 friendUniqueID in connectionUniqueIDList)
		{
			UserBase tempUser = GetUserBase(friendUniqueID);

			htmlStr += MyFriendHTMLStr(tempUser.UniqueID, tempUser.FirstName + " " + tempUser.LastName);
		}

		return htmlStr;
	}

	
	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string SaveEventDetails(
		string topic,
		string description,
		string startDate,
		string startTime,
		string finishDate,
		string finishTime,
		string location,
		string valueNeeded)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentEvent == null)
			return "Event is not Loaded";

		mCurrentEvent.ResourceDescription.Topic = topic;
		mCurrentEvent.ResourceDescription.Summary = description;//.Replace("\n", "<br/>");
		mResourceDescriptionBO.Save(mCurrentEvent.ResourceDescription);

		mCurrentEvent.EventTimeInfo.BecomeActive = CommonStaticFunctions.ParseDateTime(startDate, startTime); 
		mCurrentEvent.EventTimeInfo.BecomeInactive = CommonStaticFunctions.ParseDateTime(finishDate, finishTime); 
		mEventTimeInfoBO.Save(mCurrentEvent.EventTimeInfo);

		mCurrentEvent.EventLocation.Address1 = location;
		mObjectLocationBO.Save(mCurrentEvent.EventLocation);

		int value = int.Parse(valueNeeded);
		mCurrentEvent.Value = value;

		mEventBaseBO.Save(mCurrentEvent);

		return "Event details was saved successfully";
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string SaveItemEvent(
		string uniqueID,
		string itemName,
		int itemValue,
		string itemIcon)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentEvent == null)
			return "Event is not Loaded";

		foreach(ItemBase itemBase in mCurrentEvent.ItemChildren)
		{
			if(itemBase.UniqueID.ToString() == uniqueID)
			{
				if(itemBase.Admin.UniqueID != mCurrentUser.UniqueID)
				{
					throw new System.ArgumentException("User is not autorized to save item", "itemName");
				}

				itemBase.Name = itemName;
				itemBase.Value = itemValue;
				itemBase.ImageLocation = itemIcon;
				mItemBaseBO.Save(itemBase);
				
				AddItemToPool(itemBase);

				return "Item was saved successfully";
			}
		}

		return "Failed to save item";
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string DeleteItemEvent(
		string uniqueID,
		string itemName)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentEvent == null)
			return "Event is not Loaded";

		foreach(ItemBase itemBase in mCurrentEvent.ItemChildren)
		{
			if(itemBase.UniqueID.ToString() == uniqueID)
			{
				if(itemBase.Admin.UniqueID != mCurrentUser.UniqueID)
				{
					throw new System.ArgumentException("User is not autorized to delete item", "itemName");
				}

				if(itemBase.Name != itemName)
				{
					throw new System.ArgumentException("Item is invalid", "itemName");
				}

				mCurrentEvent.ItemChildren.Remove(itemBase);

				try
				{
					mItemBaseBO.Delete(itemBase);
				}
				catch
				{
					throw new System.ArgumentException("Delete item failed", "itemName");
				}

				return "Item was saved successfully";
			}
		}

		return "Failed to save item";
	}

	
	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string AddNewItemTypeEvent(
		string itemName,
		string iconLocation,
        string value)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentEvent == null)
			return "Event is not Loaded";

		bool saveDicList = true;

		foreach(NameImage imageInfo in mCurrentUserNameImageList.Items)
		{
			if((imageInfo.Name.ToLowerInvariant() == itemName.ToLowerInvariant()) &&
				(imageInfo.ImageLocation == iconLocation))
			{
				saveDicList = false;
			}
		}

        NameImage selectedItem = new NameImage(itemName, iconLocation, int.Parse(value));
		selectedItem.IsDefault = false;

		if(saveDicList)
		{
			mCurrentUserNameImageList.Items.Add(selectedItem);
			mUserNameImageListBO.Save(mCurrentUserNameImageList);
		}

		return GetNameImageString(selectedItem);
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string AddItemEvent(
		string itemName,
		string iconLocation,
		int itemValue)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentEvent == null)
			return "Event is not Loaded";

		ItemBase newItemBase = new ItemBase(0, mCurrentEvent, mCurrentUser, new NameImage(itemName, iconLocation));
		newItemBase.Value = itemValue;
		mItemBaseBO.Save(newItemBase);
		
		AddItemToPool(newItemBase);

		mCurrentEvent.ItemChildren.Add(newItemBase);

		HoldingsInfo newDefaultHolding	= new HoldingsInfo();
		newDefaultHolding.ItemOwner		= newItemBase;
		mHoldingsInfoBO.Save(newDefaultHolding);
		newItemBase.HoldingsInfo.Add(newDefaultHolding);

		return GetItemBaseHTMLString(newItemBase);
	}
	
	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string RemoveItemEvent(
		string itemName,
		string iconLocation)
	{
		if(!mIsInit)
			InitMembers();

		foreach(NameImage imageInfo in mCurrentUserNameImageList.Items)
		{
			if((imageInfo.Name.ToLowerInvariant() == itemName.ToLowerInvariant()) &&
				(imageInfo.ImageLocation == iconLocation))
			{
				mCurrentUserNameImageList.Items.Remove(imageInfo);
				mUserNameImageListBO.Save(mCurrentUserNameImageList);
				return "Item removed successfully";
			}
		}

		return "Failed to remove item";
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string PopulateIconPopup()
	{
		string iconListHTMLStr = "";

		if(!mIsInit)
			InitMembers();

		foreach(NameImage imageInfo in DefaultIconsList.Instance.DefaultIcons)
		{
			string largeIcon = imageInfo.ImageLocation.Replace("Icons/", "Icons128/").Replace("_24", "_128");
			iconListHTMLStr += "<img alt=\"" + imageInfo.Name + "\" src=\"" + imageInfo.ImageLocation  + "\" class=\"iconPopup\" " +
				"onclick=\"updateChooseIcon('" + largeIcon + "', '" + imageInfo.ImageLocation + "');\" onmouseover=\"this.style.background='#B0E0E6'\" onmouseout=\"this.style.background=''\"/>";
		}

		return iconListHTMLStr;
	}

	protected string GetNameImageString(NameImage imageInfo)
	{
		string removeStr = "";
		if(!imageInfo.IsDefault)
			removeStr = "<img class=\"fr\" alt=\"Remove\" src=\"Icons/DeleteX.png\" onMouseOver=\"this.src='Icons/DeleteXh.png'\" onMouseOut=\"this.src='Icons/DeleteX.png'\"" + 
				"width=\"24\" height=\"24\" onclick=\"removeItemName('" + imageInfo.Name + "','" + imageInfo.ImageLocation  +"');\">";

		/*return "<div class=\"scrollItemsDiv\" id=\"__" +imageInfo.Name+imageInfo.ImageLocation + "__\" onclick=\"newItemClicked('__" +imageInfo.Name+imageInfo.ImageLocation + "__');\"" + 
				"onmouseover=\"this.style.background='#B0E0E6'\" onmouseout=\"this.style.background=''\"" +
				"><input type=\"checkbox\" class=\"nmCBoxS\" name=\"nmCBox\" value=\"" +imageInfo.Name+"(#)"+imageInfo.ImageLocation +"(#)" + imageInfo.Value.ToString() + "\" /><img alt=\"" + imageInfo.Name + "\" src=\"" + imageInfo.ImageLocation  + "\" width=\"24\" height=\"24\" />" +
				"&nbsp;<img alt=\" \" class=\"smallStar\" src=\"Icons/sStars"+imageInfo.Value.ToString()+".png\" /><span>&nbsp;"+ imageInfo.Name + removeStr + "</span></div>";*/
		
		return "<div class=\"scrollItemsDiv\" id=\"__" +imageInfo.Name+imageInfo.ImageLocation + "__\" onclick=\"newItemClicked('__" +imageInfo.Name+imageInfo.ImageLocation + "__');\"" + 
				"onmouseover=\"this.style.background='#B0E0E6'\" onmouseout=\"this.style.background=''\">" +
				"<input type=\"checkbox\" class=\"nmCBoxS\" name=\"nmCBox\" value=\"" +imageInfo.Name+"(#)"+imageInfo.ImageLocation +"(#)" + imageInfo.Value.ToString() + "\" />" +
				"<img alt=\"\" src=\"Images/global/chkF.png\" class=\"nmChkTF\" />" +
				"<img alt=\"" + imageInfo.Name + "\" src=\"" + imageInfo.ImageLocation  + "\" width=\"24\" height=\"24\" />" +
				"&nbsp;<img alt=\" \" class=\"smallStar\" src=\"Icons/sStars"+imageInfo.Value.ToString()+".png\" /><span>&nbsp;"+ imageInfo.Name + removeStr + "</span></div>";

	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string GetNewItemPopupString()
	{
		string newItemsStr = "";

		if(!mIsInit)
			InitMembers();

		if(mCurrentEvent == null)
			return "Event is not Loaded";

        bool newItemsListLoaded = (bool)Session["NewItemsListLoaded"];

        if (newItemsListLoaded)
            return "";

        Session["NewItemsListLoaded"] = true;

		foreach(NameImage imageInfo in mCurrentUserNameImageList.Items)
		{
			newItemsStr += GetNameImageString(imageInfo);
		}

		return newItemsStr;
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string GetHoldingColor(string itemUniqueID)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentUser == null)
			return "User is not Loaded";

		ItemBase itemBase = GetItemBase(UInt64.Parse(itemUniqueID));

		foreach(HoldingsInfo holdingsInfo in itemBase.HoldingsInfo)
		{
			if(!holdingsInfo.IsLoaded())
				mHoldingsInfoBO.Load(holdingsInfo);

			if(holdingsInfo.HoldingUser.UniqueID == mCurrentUser.UniqueID)
			{
				return "#0000E6";
			}
		}

		return "#000000";
	}

	protected string GetItemBaseHTMLString(ItemBase itemBase)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentUser == null)
			return "User is not Loaded";

		bool userHoldingIt = false;
		string nameColor = "000000";
        string holdingColor = "008000";

		string retHTMLString = "";

		string uniqueIDStr	= itemBase.UniqueID.ToString();
		string iconLoc		= itemBase.ImageLocation;
		string name			= itemBase.Name;
		string shortName	= (name.Length > 25) ? name.Substring(0,25) : name;

		int holdingUsers = 0;
		foreach(HoldingsInfo holdingsInfo in itemBase.HoldingsInfo)
		{
			if(!holdingsInfo.IsLoaded())
				mHoldingsInfoBO.Load(holdingsInfo);

			if(holdingsInfo.HoldingUser.UniqueID != 0)
			{
				holdingUsers++;
				if(holdingsInfo.HoldingUser.UniqueID == mCurrentUser.UniqueID)
					userHoldingIt = true;
			}
		}
		string holdingsText = holdingUsers.ToString() + "/" + itemBase.HoldingsInfo.Count.ToString();
		
		if(userHoldingIt)
			nameColor = "0000E6";

		retHTMLString += "<div class=\"scrollItemsDiv\" id=\"" +uniqueIDStr + "\" onclick=\"ItemClicked('" + name + "', '" + iconLoc +"', '" + uniqueIDStr + "', '" + itemBase.Value.ToString() +"');\"" + 
				"onmouseover=\"this.style.background='#B0E0E6'\" onmouseout=\"ItemInEventMouseOut('" + uniqueIDStr + "');\"" +
				"><img alt=\"" + name + "\" src=\"" + iconLoc  + "\" width=\"24\" height=\"24\" />";

		retHTMLString += "&nbsp;<img alt=\" \" class=\"smallStar\" src=\"Icons/sStars"+itemBase.Value.ToString()+".png\" />";

		if(holdingUsers < itemBase.HoldingsInfo.Count)
			holdingColor = "E60000";

		retHTMLString += "<span id=\"IName_"+uniqueIDStr+"\" style=\"color:#"+nameColor+";\" >&nbsp;"+ name + "</span><span id=\"IHoldings_"+uniqueIDStr+"\" style=\"color:#"+holdingColor+";\" class=\"scrollItemHoldingsText\">"+holdingsText+"</span></div>";

		return retHTMLString;
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string GetScrollListString()
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentEvent == null)
            return "Error: Please reload (F5) this page";

        if (mCurrentUser == null)
            return "Error: Please reload (F5) this page";

		string retHTMLString = "";

		foreach(ItemBase itemBase in mCurrentEvent.ItemChildren)
		{
			retHTMLString += GetItemBaseHTMLString(GetItemBase(itemBase.UniqueID));
		}

		return retHTMLString;
	}

	protected string GetItemHoldingHTMLStr(HoldingsInfo holdingsInfo)
	{
		string fullName = "Still Needed";

		if(holdingsInfo.HoldingUser.UniqueID != 0)
		{
			if(!holdingsInfo.HoldingUser.IsLoaded())
				holdingsInfo.HoldingUser = GetUserBase(holdingsInfo.HoldingUser.UniqueID);

            if (mCurrentUser.UniqueID == holdingsInfo.HoldingUser.UniqueID)
                fullName = "Me";
            else
			    fullName = holdingsInfo.HoldingUser.FirstName + " " + holdingsInfo.HoldingUser.LastName;
		}

		return "<div class=\"myItemHoldings\" id=\"itemHoldings_" +holdingsInfo.UniqueID.ToString() + "\" onclick=\"ItemHoldingsClicked('" + holdingsInfo.UniqueID.ToString() + "','" + fullName + "');\"" +
				"onmouseover=\"this.style.background='#B0E0E6'\" onmouseout=\"ItemHoldingsMouseOut('" + holdingsInfo.UniqueID.ToString() + "');\"" +
				"><span>&nbsp;"+ fullName + "</span></div>";
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string ItemHoldingsStatus(string itemUniqueID, string holdingsUniqueID)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentEvent == null)
			return "Event is not Loaded";

		if(mCurrentUser == null)
			return "User is not Loaded";

		// Force Reload
		ItemBase itemBase = new ItemBase(UInt64.Parse(itemUniqueID));
		mItemBaseBO.Load(itemBase );
		AddItemToPool(itemBase );

		if(itemBase == null)
			return "Could not find Item";

		UInt64 holdingUID = UInt64.Parse(holdingsUniqueID);

		foreach(HoldingsInfo holdingsInfo in itemBase.HoldingsInfo)
		{
			if(holdingsInfo.UniqueID == holdingUID)
			{
				if(!holdingsInfo.IsLoaded())
					mHoldingsInfoBO.Load(holdingsInfo);
				
				if(holdingsInfo.HoldingUser.UniqueID == 0)
					return "Free";
				else if(holdingsInfo.HoldingUser.UniqueID == mCurrentUser.UniqueID)
					return "Owner";
				else
					return "Taken";
			}
		}

		return "Item not found";
	}

	

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string GetItemHoldings(string uniqueID)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentEvent == null)
			return "Event is not Loaded";

		String retStr = "";
		//ItemBase itemBase = GetItemBase(UInt64.Parse(uniqueID));

		// Force Reload
		ItemBase itemBase = new ItemBase(UInt64.Parse(uniqueID));
		mItemBaseBO.Load(itemBase );
		AddItemToPool(itemBase );

		if(itemBase == null)
			return "Could not find Item";

		foreach(HoldingsInfo holdingsInfo in itemBase.HoldingsInfo)
		{
			if(!holdingsInfo.IsLoaded())
				mHoldingsInfoBO.Load(holdingsInfo);

			retStr += GetItemHoldingHTMLStr(holdingsInfo);
		}

		return retStr;
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string AddEmptyItemHolding(string uniqueID)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentEvent == null)
			return "Event is not Loaded";

		// Force Reload
		ItemBase itemBase = new ItemBase(UInt64.Parse(uniqueID));
		mItemBaseBO.Load(itemBase );

		if(itemBase == null)
			return "Could not find Item";

		HoldingsInfo newDefaultHolding	= new HoldingsInfo();
		newDefaultHolding.ItemOwner		= itemBase;
		mHoldingsInfoBO.Save(newDefaultHolding);
		itemBase.HoldingsInfo.Add(newDefaultHolding);

		AddItemToPool(itemBase);

		return "";
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string RemoveItemHolding(string itemBaseUniqueID, string holdingsUniqueID)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentEvent == null)
			return "Event is not Loaded";

				// Force Reload
		ItemBase itemBase = new ItemBase(UInt64.Parse(itemBaseUniqueID));
		mItemBaseBO.Load(itemBase);

		if(itemBase == null)
			return "Could not find Item";
		
		UInt64 uID = UInt64.Parse(holdingsUniqueID);
		foreach(HoldingsInfo holdingsInfo in itemBase.HoldingsInfo)
		{
			if(!holdingsInfo.IsLoaded())
				mHoldingsInfoBO.Load(holdingsInfo);

			if(uID == holdingsInfo.UniqueID)
			{
				mHoldingsInfoBO.Delete(holdingsInfo);
				itemBase.HoldingsInfo.Remove(holdingsInfo);
				break;
			}
		}

		AddItemToPool(itemBase);

		return "";
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string GetUserHoldingsValue()
	{
		int userHoldingsValue = 0;

		if(!mIsInit)
			InitMembers();

		if(mCurrentEvent == null)
			return "reload";

		if(mCurrentUser == null)
			return "reload";

		foreach(ItemBase itemBase in mCurrentEvent.ItemChildren)
		{
			mItemBaseBO.Load(itemBase);

			foreach(HoldingsInfo holdingsInfo in itemBase.HoldingsInfo)
			{
				if(!holdingsInfo.IsLoaded())
					mHoldingsInfoBO.Load(holdingsInfo);

				if(holdingsInfo.HoldingUser.UniqueID == mCurrentUser.UniqueID)
				{
					userHoldingsValue += itemBase.Value;
				}
			}
		}

		return userHoldingsValue.ToString();
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string UnholdItemHolding(string itemBaseUniqueID, string holdingsUniqueID)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentEvent == null)
			return "Event is not Loaded";

		if(mCurrentUser == null)
			return "User is not Loaded";

		ItemBase itemBase = GetItemBase(UInt64.Parse(itemBaseUniqueID));

		if(itemBase == null)
			return "Could not find Item";
		
		UInt64 uID = UInt64.Parse(holdingsUniqueID);
		foreach(HoldingsInfo holdingsInfo in itemBase.HoldingsInfo)
		{
			if(uID == holdingsInfo.UniqueID)
			{
				mHoldingsInfoBO.Load(holdingsInfo);
				holdingsInfo.HoldingUser = new UserBase();
				holdingsInfo.HoldingUser.UniqueID = 0;

				mHoldingsInfoBO.Save(holdingsInfo);
				break;
			}
		}

		return "";
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string HoldItemHolding(string itemBaseUniqueID, string holdingsUniqueID)
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentEvent == null)
			return "Event is not Loaded";

		if(mCurrentUser == null)
			return "User is not Loaded";

		ItemBase itemBase = GetItemBase(UInt64.Parse(itemBaseUniqueID));

		if(itemBase == null)
			return "Could not find Item";
		
		UInt64 uID = UInt64.Parse(holdingsUniqueID);
		foreach(HoldingsInfo holdingsInfo in itemBase.HoldingsInfo)
		{
			if(uID == holdingsInfo.UniqueID)
			{
				mHoldingsInfoBO.Load(holdingsInfo);
				holdingsInfo.HoldingUser = mCurrentUser;
				mHoldingsInfoBO.Save(holdingsInfo);
				break;
			}
		}

		return "";
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string GetEventTotalValueNeeded()
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentEvent == null)
			return "Event is not Loaded";

		return mCurrentEvent.Value.ToString();
	}
	

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string GetEventFriendsString()
	{
		if(!mIsInit)
			InitMembers();

		if(mCurrentEvent == null)
			return "Event is not Loaded";

		string retHTMLString = "";

		foreach(HoldingsInfo holdingsInfo in mCurrentEvent.HoldingsInfo)
		{
			if(!holdingsInfo.IsLoaded())
			{
				mHoldingsInfoBO.Load(holdingsInfo);
			}

			if(!holdingsInfo.HoldingUser.IsLoaded())
			{
				holdingsInfo.HoldingUser = GetUserBase(holdingsInfo.HoldingUser.UniqueID);
			}

			retHTMLString += EventFriendHTMLStr(holdingsInfo.HoldingUser.UniqueID, holdingsInfo.HoldingUser.FirstName + " " + holdingsInfo.HoldingUser.LastName);
		}

		return retHTMLString;
	}
}

