using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyEasy.User
{
    class UserInfo : MyEasyBase
    {
        #region Members

        string mFirstName;

        string mLastName;

        #endregion

        public string FirstName
        { 
            get {return mFirstName;}
            set
            {
                if (mFirstName != value)
                {
                    mFirstName = value;
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("UserInfoFirstNameChange"));
                }
            }
        }

        public string LastName
        {
            get { return mLastName; }
            set
            {
                if (mLastName != value)
                {
                    mLastName = value;
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("UserInfoLastNameChange"));
                }
            }
        }


        public string LastName { get; set; }


    }
}
