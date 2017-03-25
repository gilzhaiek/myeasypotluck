using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyEasyObjects.User;
using MyEasyBO;
using System.Text.RegularExpressions;
using MyEasy.Common;
using System.Collections;
using MyEasyBO.Event;
using MyEasyObjects.Event;
using AjaxControlToolkit;
using MyEasyBO.UserBO;
using System.Drawing;
using System.Globalization;

/*if(currentEvent.EventTimeInfo.BecomeActive.Value.Year != 1)
		fromTime	= currentEvent.EventTimeInfo.BecomeActive.Value.ToString("d-MMM-yyyy hh:mm tt", CultureInfo.CreateSpecificCulture("en-US"));*/


public partial class EventBrief : System.Web.UI.Page
{
	#region Members

	Regex	mEmailRegex			= new Regex(@"^[A-Za-z0-9._-]+@[A-Za-z0-9.-]+\.[[A-Za-z0-9.-]+$");

	LoginManagerBO	mLoginManagerBO;
	UserBase		mCurrentUser;
	EventBaseBO		mEventBaseBO;
	UserBaseBO		mUserBaseBO;

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

	protected void Page_Load(object sender, EventArgs e)
	{
		mLoginManagerBO = new LoginManagerBO();
		mEventBaseBO	= new EventBaseBO();
		mUserBaseBO		= new UserBaseBO();

		mCurrentUser	= (UserBase)Session["CurrentUser"];

		Session["CurrentEvent"] = null;

		if(mCurrentUser == null)
		{
			Signout();
		}
		else if(!mCurrentUser.IsNull)
		{
			lblName.Text = "Hello " + mCurrentUser.FirstName + " " + mCurrentUser.LastName;
			PopulatePage(IsPostBack);
		}
		else 
		{
			Signout();
		}
	}

	protected void PopulatePage(bool isPostBack)
	{
		if(calendarButtonExtenderTextBoxStart.SelectedDate == null)
		{
			calendarButtonExtenderTextBoxStart.SelectedDate = DateTime.Today;
			inputRangeStartDate.Text = calendarButtonExtenderTextBoxStart.SelectedDate.Value.ToString("d-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
		}
		if(calendarButtonExtenderTextBoxFinish.SelectedDate == null)
		{
			calendarButtonExtenderTextBoxFinish.SelectedDate = DateTime.Today;
			inputRangeFinishDate.Text = calendarButtonExtenderTextBoxFinish.SelectedDate.Value.ToString("d-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
		}
	}

	#region Properties

	protected string LogoutLink
	{
		get {return lnkbtnlogout.Text;}
		set {lnkbtnlogout.Text = value;}
	}

	#endregion
}
