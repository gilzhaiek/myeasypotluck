using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MyEasyBO;
using MyEasyObjects.User;
using System.Web.Script.Services;
using System.Text.RegularExpressions;
using MyEasy.Common;
using MyEasyBO.UserBO;
using MyEasyBO.Object;
using System.Text;

/// <summary>
/// Summary description for LoginWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
[ScriptService]
public class LoginWebService : System.Web.Services.WebService
{
	#region Members
	
	Regex	mEmailRegex			= new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

	UserBase mCurrentUser = null;

	#endregion

	public LoginWebService()
	{
	}

	private void CreateCurrentUser()
	{
		mCurrentUser = new UserBase();
		Session["CurrentUser"] = mCurrentUser;
		Session.Timeout = 240;
	}
	
	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string LoginUser(string email, string password)
    {
		if((email == string.Empty) && (password == string.Empty))
		{
			return "Email and Password missing";
		}

		if(email == string.Empty)
		{
			return "Email box is empty";
		}
		
		if(!mEmailRegex.IsMatch(email))
		{
			return "Not a valid email string";
		}

		if(password == string.Empty)
		{
			return "Password box is empty";
		}
		
		LoginManagerBO loginManagerBO = new LoginManagerBO();
		if(!loginManagerBO.EmailExists(email))
		{
			return "Password or Email dont match";
		}

		UserBase currentUser = new UserBase();
		if(loginManagerBO.GetUser(currentUser, email, password) == false)
		{
			return "Password or Email dont match";
		}
		
		Session["CurrentUser"] = currentUser;

		return "success";
    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string SendEmailReminder(string email)
    {
        if (email == string.Empty)
        {
            return "Email box is empty";
        }

        if (!mEmailRegex.IsMatch(email))
        {
            return "Not a valid email string";
        }

        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < 6; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        string newPassword = builder.ToString().ToUpper();

        string subject = "MyEasyPotluck password reset";
        string body = "A new password has been assigned to your login name in www.myeasypotluck.com\nPlease sign-in with your email and use the following password:\n" + newPassword + "\n\nThank You\nMyEasyPotluck\n";

        body = body.Replace("www.myeasypotluck.com", "<a href=\"http://www.myeasypotluck.com/\">www.myeasypotluck.com</a>").Replace("\n", "<br/>");

        try
        {
            EmailSender.SendEmail(EmailSender.EEmailAccount.eEmailReminder, email, subject, body);
            LoginManagerBO loginManagerBO = new LoginManagerBO();
            loginManagerBO.UpdatePassword(email, newPassword);
        }
        catch
        {
            return "Failed to send email";
        }
        
        return "success";
    }
    

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string GetCountryOptions()
	{
		string retStr = "";
		for(int i = 1; i < (int)ECountry.eCountrySize; i++)
		{
			retStr += "<option value=\"ECountry_" + i.ToString() + "\" >" + StringValueClass.GetStringValue((ECountry)i) + "</option>";
		}	

		return retStr;
	}

	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string CreateUser(string email, string password, string fullName, string gender, string country)
	{
		LoginManagerBO	loginManagerBO = new LoginManagerBO();

		CreateCurrentUser();

		ECountry	eCountry	= (ECountry)Int32.Parse(country.Substring(("ECountry_").Length));
		EGender		eGender		= (EGender)Int32.Parse(gender.Substring(("EGender_").Length));
		string		firstName;
		string		lastName = "";

		string[] fullNameSplit = fullName.Split(' ');
		firstName = fullNameSplit[0];
		
		for(int i = 1; i < fullNameSplit.Length; i++)
		{
			if(i > 1)
				lastName += " " + fullNameSplit[i];
			else
				lastName += fullNameSplit[i];
		}

		
		if(loginManagerBO.EmailExists(email))
		{
			return email + " already taken";
		}

		// Create User
		loginManagerBO.CreateUser(mCurrentUser, password, email, firstName, lastName, eGender, eCountry);
        //loginManagerBO.CreateSampleEvent(mCurrentUser);

		Session["CurrentUser"] = mCurrentUser;
		
		return "success";
	}

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string GetUserProfile()
	{
		string retProfile = "";

		mCurrentUser	= (UserBase)Session["CurrentUser"];
		
		if(mCurrentUser == null)
            return "Please Reload Page";


        if (!mCurrentUser.Location.IsLoaded())
        {
            ObjectLocationBO objectLocationBO = new ObjectLocationBO();
            objectLocationBO.Load(mCurrentUser.Location);
        }

		retProfile += mCurrentUser.Email + "(#)";
		retProfile += mCurrentUser.FirstName + "(#)";
		retProfile += mCurrentUser.LastName+ "(#)";
		retProfile += "EGender_" + ((int)mCurrentUser.Gender).ToString() + "(#)";
		retProfile += "ECountry_" + ((int)mCurrentUser.Location.Country).ToString() + "(#)";

		return retProfile;
	}

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string UpdateUser(string email, string password, string firstName, string lastName, string gender, string country)
    {   
		mCurrentUser	= (UserBase)Session["CurrentUser"];
		
		if(mCurrentUser == null)
            return "Please Reload Page";

        UserBaseBO userBaseBO = new UserBaseBO();
       
        ECountry eCountry = (ECountry)Int32.Parse(country.Substring(("ECountry_").Length));
        EGender eGender = (EGender)Int32.Parse(gender.Substring(("EGender_").Length));

        mCurrentUser.Email = email;
        mCurrentUser.FirstName = firstName;
        mCurrentUser.LastName = lastName;
        mCurrentUser.Gender = eGender;

        if (!mCurrentUser.Location.IsLoaded())
        {
            ObjectLocationBO objectLocationBO = new ObjectLocationBO();
            objectLocationBO.Load(mCurrentUser.Location);
        }

        mCurrentUser.Location.Country = eCountry;

        userBaseBO.Save(mCurrentUser);

        LoginManagerBO loginManagerBO = new LoginManagerBO();
		if(password.Length < 6)
			loginManagerBO.UpdateUserLoginInfo(mCurrentUser.UniqueID, email);
		else
			loginManagerBO.UpdateUserLoginInfo(mCurrentUser.UniqueID, email, password);

        Session["CurrentUser"] = mCurrentUser;

        return "Success";
    }


	[WebMethod(EnableSession=true)]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string SendSupportEmail(string fromEmail, string subject, string body)
	{
		string userUID = "0";

		mCurrentUser	= (UserBase)Session["CurrentUser"];
		
		if(mCurrentUser != null)
			userUID = mCurrentUser.UniqueID.ToString();
			
		EmailSender.SendEmail(EmailSender.EEmailAccount.eEmailSupport, fromEmail + " : " + userUID, subject, body);
		
		return "Email was sent";
	}
}

