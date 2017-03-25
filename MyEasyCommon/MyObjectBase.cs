using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace MyEasy.Common
{
    public abstract class MyObjectBase : INullable, IComparable
    {
        #region Members

        protected UInt64 mUniqueID = 0;

        protected Int64 mLastDALChange = 0;

        protected bool mIsLoaded = false;

        protected string mDelim = new string((new char[] { ';' }));

        #endregion

        #region Constructor

        public MyObjectBase()
        {
        }

        public MyObjectBase(UInt64 uniqueID)
        {
            mUniqueID = uniqueID;
        }

        #endregion

        #region Properties

        public virtual UInt64 UniqueID
        {
            get { return mUniqueID; }
            set
            {
                LastDALChange = 0;
                mUniqueID = value;
            }
        }

        public virtual Int64 LastDALChange
        {
            get { return mLastDALChange; }
            set { mLastDALChange = value; }
        }

        public virtual bool IsNull
        {
            get { return (UniqueID == 0); }
            protected set { }
        }

        public virtual bool IsLoaded()
        {
            return (LastDALChange != 0);
        }

        public abstract int CompareTo(object objectToCompare);

        #endregion
    }
}
