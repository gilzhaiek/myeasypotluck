using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyEasyBO.UserBO;
using MyEasyObjects.User;

public partial class About : System.Web.UI.Page
{
	#region Members

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

	protected void Page_Load(object sender, EventArgs e)
	{
		mCurrentUser	= (UserBase)Session["CurrentUser"];

		if(mCurrentUser != null)
		{
			if(!mCurrentUser.IsNull)
			{
				lblName.Text = "Hello " + mCurrentUser.FirstName + " " + mCurrentUser.LastName;
			}
			else
			{
				lnkbtnlogout.Text = "";
			}
		}
		else
		{
			lnkbtnlogout.Text = "";
		}
	}
}
