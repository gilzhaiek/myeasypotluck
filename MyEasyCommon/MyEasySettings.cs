using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace MyEasy.Common
{
    public class MyEasySettings
    {
        #region Members

        //static private CultureInfo		mCultureInfo = new CultureInfo("he-IL");//("en-US");
        static private CultureInfo mCultureInfo = new CultureInfo("en-US");

        #endregion


        static public string DBLocation { get { return "../BinaryDB/"; } }

        static public EResourcePriority DefaultResourcePriority { get { return EResourcePriority.eNormal; } }

        static public CultureInfo DateTimeCulture { get { return mCultureInfo; } }
    }
}
