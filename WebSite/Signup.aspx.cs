using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyEasy.Common;
using MyEasyBO;
using System.Text.RegularExpressions;
using MyEasyObjects.User;
using System.Drawing;
using CodeBureau;

public partial class Signup : System.Web.UI.Page
{
	#region Members

	Regex	mWordNumberRegex	= new Regex(@"^[a-zA-Z]+[0-9a-zA-Z_]*$");
	Regex	mEmailRegex			= new Regex(@"^[A-Za-z0-9._-]+@[A-Za-z0-9.-]+\.[[A-Za-z0-9.-]+$");

	UserBase		mCurrentUser;

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

	private void CreateCurrentUser()
	{
		mCurrentUser = new UserBase();
		Session["CurrentUser"] = mCurrentUser;
		Session.Timeout = 240;
	}

    protected void Page_Load(object sender, EventArgs e)
    {
		if(!IsPostBack)
		{
			mCurrentUser = (UserBase)Session["CurrentUser"];

			if(mCurrentUser == null)
			{
				CreateCurrentUser();
			}
			else if(!mCurrentUser.IsNull)
			{
				Response.Redirect("EventBrief.aspx");
			}
			else 
			{
				CreateCurrentUser();
			}
		}
		else 
		{
			CreateCurrentUser();
		}
    }
}