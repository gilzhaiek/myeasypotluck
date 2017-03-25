using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyEasyBO;
using MyEasyBO.Event;
using MyEasyBO.UserBO;
using System.Text.RegularExpressions;
using MyEasyObjects.User;
using MyEasyObjects.Event;
using System.Globalization;
using MyEasyObjects.Item;
using MyEasyBO.Item;
using MyEasyBO.Object;
using MyEasyObjects.Object;
using MyEasy.Common;

public partial class EventDetails : System.Web.UI.Page
{
	#region Members

	LoginManagerBO			mLoginManagerBO;
	UserBase				mCurrentUser;
	EventBase				mCurrentEvent;
	EventBaseBO				mEventBaseBO;
	UserBaseBO				mUserBaseBO;
	ItemBaseBO				mItemBaseBO;
	UserNameImageListBO		mUserNameImageListBO;

	#endregion

	protected void Signout()
	{
		Session.Clear();
		Response.Redirect("default.aspx");
	}

	public void lnkbtnlogout_Click(object sender, EventArgs e)
	{
		Signout();
	}

	private void GoToBrief()
	{
		Response.Redirect("EventBrief.aspx");
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		mLoginManagerBO				= new LoginManagerBO();
		mEventBaseBO				= new EventBaseBO();
		mUserBaseBO					= new UserBaseBO();
		mItemBaseBO					= new ItemBaseBO();
		mUserNameImageListBO		= new UserNameImageListBO();

        Session["NewItemsListLoaded"] = false;

		mCurrentUser	= (UserBase)Session["CurrentUser"];

		if(mCurrentUser == null)
		{
			Signout();
		}
		else if(!mCurrentUser.IsNull)
		{
            mCurrentEvent = (EventBase)Session["CurrentEvent"];
			if(mCurrentEvent == null)
			{
				GoToBrief();
			}
			if(mCurrentEvent.IsNull)
			{
				GoToBrief();
			}

            if(mCurrentUser.UniqueID != mCurrentEvent.Admin.UniqueID)
                Response.Redirect("EventView.aspx");

            lblName.Text = "Hello " + mCurrentUser.FirstName + " " + mCurrentUser.LastName;

			PopulatePage();
		}
		else 
		{
			Signout();
		}
	}

	protected void btAddItemClick(object sender, EventArgs e)
	{
	}

	protected void PopulatePage()
	{
		txtboxTopicEnter.Text = mCurrentEvent.ResourceDescription.Topic;
		txtboxDescriptionEnter.Text = mCurrentEvent.ResourceDescription.Summary;

		inputRangeStartDate.Text = mCurrentEvent.EventTimeInfo.BecomeActive.Value.ToString("d-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
		inputRangeStartTime.Text = mCurrentEvent.EventTimeInfo.BecomeActive.Value.ToString("hh:mm tt", CultureInfo.CreateSpecificCulture("en-US"));

		inputRangeFinishDate.Text = mCurrentEvent.EventTimeInfo.BecomeInactive.Value.ToString("d-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
		inputRangeFinishTime.Text = mCurrentEvent.EventTimeInfo.BecomeInactive.Value.ToString("hh:mm tt", CultureInfo.CreateSpecificCulture("en-US"));

		txtboxLocation.Text = mCurrentEvent.EventLocation.Address1;

		//PopulateNewItemPopup();
	}
}
