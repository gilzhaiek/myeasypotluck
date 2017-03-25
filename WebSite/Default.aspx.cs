using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using MyEasyBO;
using MyEasyObjects.User;
using MyEasy.Common;

public partial class Login : System.Web.UI.Page
{
	#region Members

	Regex	mWordNumberRegex	= new Regex(@"^[a-zA-Z]+[0-9a-zA-Z_]*$");
	Regex	mEmailRegex			= new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

	LoginManagerBO	mLoginManagerBO;
	UserBase		mCurrentUser;

	#endregion

	private void CreateCurrentUser()
	{
		mCurrentUser = new UserBase();
		Session["CurrentUser"] = mCurrentUser;
		Session.Timeout = 1439;
	}

    protected void Page_Load(object sender, EventArgs e)
    {
		mLoginManagerBO = new LoginManagerBO();
		mCurrentUser = (UserBase)Session["CurrentUser"];

		if(mCurrentUser == null)
		{
			CreateCurrentUser();
		}
		else if(!mCurrentUser.IsNull)
		{
			Response.Redirect("EventBrief.aspx");
			//InvalidMessage = "Hello " + mCurrentUser.FirstName + " " + mCurrentUser.LastName + " From " + mCurrentUser.Location.Country.GetStringValue();
		}
		else 
		{
			CreateCurrentUser();
		}
    }
}