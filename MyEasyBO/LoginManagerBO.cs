using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasy.Common;
using MyEasyDAL;
using MyEasyObjects.User;
using MyEasyObjects.Resource;
using MyEasyBO.UserBO;
using System.Data;
using MyEasyBO.Event;
using MyEasyObjects.Event;
using MyEasyObjects.Item;
using MyEasyObjects.Icons;
using MyEasyBO.Item;
using MyEasyObjects.Holding;
using MyEasyBO.HoldingBO;

namespace MyEasyBO
{
	public class LoginManagerBO
	{
		#region Members

		LoginManagerDAL		mAccessLayer	= new LoginManagerDAL();
		UserBaseBO			mUserBaseBO		= new UserBaseBO();
        /*EventBaseBO         mEventBaseBO    = new EventBaseBO();
        ItemBaseBO          mItemBaseBO     = new ItemBaseBO();
        HoldingsInfoBO      mHoldingsInfoBO = new HoldingsInfoBO();*/

		#endregion

		#region Constructor


		public LoginManagerBO() {}

		#endregion

		#region Functions

		public bool GetUser(UserBase retUserBase, string email, string password)
		{
			UInt64 userUniqueID = mAccessLayer.GetUserUniqueID(email, password);
			
			if(userUniqueID == 0) return false;

            retUserBase.UniqueID = userUniqueID;

			mUserBaseBO.Load(retUserBase);
			
			return true;
		}

        public bool CreateFBUser(UserBase retUserBase, string firstName, string lastName)
        {
            if (retUserBase.UniqueID == 0) return false;

            retUserBase.FBUser = true;
            retUserBase.FirstName = firstName;
            retUserBase.LastName = lastName;
            retUserBase.Location.Country = ECountry.eCountryNULL;
            retUserBase.Gender = EGender.eGenderNull;

            try
            {
                mUserBaseBO.Save(retUserBase);
            }
            catch (Exception)
            {
                retUserBase = null;
                return false;
            }

            return true;
        }

        public bool GetFBUser(UserBase retUserBase)
        {
            if (retUserBase.UniqueID == 0) return false;
            try
            {
                mUserBaseBO.Load(retUserBase);
                if (!retUserBase.FBUser)
                {
                    retUserBase = null;
                    return false;
                }
            }
            catch (Exception)
            {
                retUserBase = null;
                return false;
            }

            return true;
        }

        public bool UpdateUser(UserBase userBase)
        {
            if (userBase.UniqueID == 0) return false;
            try
            {
                mUserBaseBO.Save(userBase);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /*protected void AddNewItemToEvent(EventBase newEvent, UserBase userBase, string name, string iconName, int value)
        {
            ItemBase newItemBase = new ItemBase(0, newEvent, userBase, new NameImage(name, DefaultIconsList.DefaultIconPath + iconName));
            newItemBase.Value = value;
            mItemBaseBO.Save(newItemBase);
            newEvent.ItemChildren.Add(newItemBase);

            HoldingsInfo newDefaultHolding = new HoldingsInfo();
            newDefaultHolding.ItemOwner = newItemBase;
            mHoldingsInfoBO.Save(newDefaultHolding);
            newItemBase.HoldingsInfo.Add(newDefaultHolding);
        }

        public void CreateSampleEvent(UserBase userBase)
        {
            EventBase newEvent = new EventBase();
		    DateTime todayAndNow = DateTime.Now;

		    newEvent.Admin                          = userBase;
		    newEvent.ResourceDescription.Topic		= "Your First Potluck Event";
		    newEvent.ResourceDescription.Summary	= "Here you can enter description of the potluck party.\n" +
                                                        "You can invited your friends, and add items (Salads, pies) to the event.\n" +
                                                        "If you want that your friends will bring an equal value of things, you can set a value for your event.\n" +
                                                        "A Value means that your friends will have to bring a sum of the value you have asked for.\n" +
                                                        "For example, if you set your event to be a total number of 4 value stars, then your friends will have to bring an Apple juice and a Banana (both valued as 2) to complete their attendance.\n" +
                                                        "Enjoy - Just remember to save event whenever you make changes to this section";
		    newEvent.Value = 3;
		    newEvent.IsPublic = false;

		    newEvent.EventTimeInfo.BecomeActive		= todayAndNow;
		    newEvent.EventTimeInfo.BecomeInactive	=  todayAndNow.AddHours(3);
    		
		    mEventBaseBO.Save(newEvent);
            AddNewItemToEvent(newEvent, userBase, "Banana", "banana_24.png", 1);
            AddNewItemToEvent(newEvent, userBase, "Apple juice", "apple_juice_24.png", 2);
            AddNewItemToEvent(newEvent, userBase, "Cake", "cake_24.png", 3);
            AddNewItemToEvent(newEvent, userBase, "Cheese", "cheese_24.png", 2);
            AddNewItemToEvent(newEvent, userBase, "Club sandwich", "club_sandwich_24.png", 4);

		    userBase.Events.Add(newEvent);

		    mUserBaseBO.Save(userBase);
        }*/

		public void CreateUser(UserBase userBase,
			string password, string email, 
			string firstName, string lastName, EGender gender, ECountry country)
		{
			if(EmailExists(email))
			{
				throw new System.ArgumentException("Email Exists already", "email");
			}

			UserLoginInfo userLoginInfo = new UserLoginInfo(password, email, 0);

			AddUser(userLoginInfo);

			userBase.UniqueID			= userLoginInfo.UniqueID;
			userBase.FirstName			= firstName;
			userBase.LastName			= lastName;
			userBase.Email				= email;
			userBase.Gender				= gender;
			userBase.Location.Country	= country;
			//userInfo.Phone;
			//userInfo.Title;

			mUserBaseBO.Save(userBase);
		}

		protected void AddUser(UserLoginInfo userLoginInfo)
		{
			mAccessLayer.AddUser(userLoginInfo);
		}

		public bool LoginNameExists(string loginName)
		{
			return mAccessLayer.LoginNameExists(loginName);
		}

		public bool EmailExists(string email)
		{
			return mAccessLayer.EmailExists(email);
		}


        public void UpdateUserLoginInfo(UInt64 uniqueID, string email)
        {
            mAccessLayer.UpdateUserLoginInfo(uniqueID, email);
        }

        public void UpdateUserLoginInfo(UInt64 uniqueID, string email, string password)
        {
            mAccessLayer.UpdateUserLoginInfo(uniqueID, email, password);
        }

        public void UpdatePassword(string email, string password)
        {
            mAccessLayer.UpdatePassword(email, password);
        }


        public bool UserExists(UInt64 uniqueID)
        {
            if (uniqueID == 0) return false;

            return mUserBaseBO.UserExists(uniqueID);
        }

		#endregion
	}
}
