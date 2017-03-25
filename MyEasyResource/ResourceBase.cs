using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MyEasy.User;

namespace MyEasy.Resource
{
    public class ResourceBase : MyEasyBase
    {
        #region Members
        
        UserBase            mAdmin;
        
        #endregion

        #region Constructor

        public ResourceBase(UserBase pAdminUser)
        {
        }

        #endregion

        #region properties

        public UserBase Admin
        {
            get {return mAdmin;}
            set
            {
                if (mAdmin != value)
                {
                    mAdmin = value;
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("ResourceAdminChanged"));
                }
            }
        }

        #endregion
    }
}
