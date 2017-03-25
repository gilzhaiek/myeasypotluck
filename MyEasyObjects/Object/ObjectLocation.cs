using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasy.Common;
using System.ComponentModel;
using System.Data.SqlTypes;

namespace MyEasyObjects.Object
{
    public class ObjectLocation : MyObjectBase, INotifyPropertyChanged
    {
        string mAddress1 = "";
        string mAddress2 = "";
        string mAddress3 = "";
        string mCity = "";
        string mState = "";
        string mZip = "";
        ECountry mCountry = ECountry.eCountryNULL;
        Coordinate mCoordinate = new Coordinate(0, 0);

        #region Constructor

        public ObjectLocation()
        {
            mCoordinate = new Coordinate(0, 0);
        }

        public ObjectLocation(UInt64 uniqueID)
            : base(uniqueID)
        {
            mCoordinate = new Coordinate(0, 0);
        }

        #endregion

        #region String Conversion Members

        public override string ToString()
        {
            if (IsNull)// || (!IsLoaded()))
                throw new System.ArgumentException("ToString failed, this is null or not loaded", "this");
            else
            {
                string delim = new string((new char[] { ';' }));
                return (
                    UniqueID.ToString() + delim +
                    Address1 + delim + Address2 + delim + Address3 + delim + City + delim + State + delim + Zip + delim + Country + delim +
                    Latitude.ToString() + delim + Longitude.ToString());
            }
        }

        public static ObjectLocation Parse(SqlString sqlStr)
        {
            if (sqlStr.IsNull)
                return null;
            else
            {
                return Parse(Convert.ToString(sqlStr));
            }
        }

        public static ObjectLocation Parse(string str)
        {
            int strCnt = 0;

            ObjectLocation objectLocation = null;

            string[] strSplit = null;
            strSplit = str.Split(new char[] { ';' });

            strCnt = Parse(objectLocation, strSplit, strCnt);

            return objectLocation;
        }

        public static int Parse(ObjectLocation objectLocation, string[] strSplit, int strCnt)
        {
            objectLocation.UniqueID = Convert.ToUInt64(strSplit[0] == null ? "0" : strSplit[strCnt++]);
            objectLocation.Address1 = strSplit[1] == null ? "" : strSplit[strCnt++];
            objectLocation.Address2 = strSplit[2] == null ? "" : strSplit[strCnt++];
            objectLocation.Address3 = strSplit[3] == null ? "" : strSplit[strCnt++];
            objectLocation.City = strSplit[4] == null ? "" : strSplit[strCnt++];
            objectLocation.State = strSplit[5] == null ? "" : strSplit[strCnt++];
            objectLocation.Zip = strSplit[6] == null ? "" : strSplit[strCnt++];
            objectLocation.Country = (ECountry)Convert.ToUInt32(strSplit[7] == null ? "" : strSplit[strCnt++]);
            objectLocation.Coordinate = new Coordinate(
                                                    Convert.ToDecimal(strSplit[8] == null ? "0" : strSplit[strCnt++]),
                                                    Convert.ToDecimal(strSplit[9] == null ? "0" : strSplit[strCnt++]));

            return strCnt;
        }

        #endregion

        #region Class Properties

        public string Address1
        {
            get { return (mAddress1); }
            set { mAddress1 = value; }
        }
        public string Address2
        {
            get { return (mAddress2); }
            set { mAddress2 = value; }
        }
        public string Address3
        {
            get { return (mAddress3); }
            set { mAddress3 = value; }
        }
        public string City
        {
            get { return (mCity); }
            set { mCity = value; }
        }
        public string State
        {
            get { return (mState); }
            set { mState = value; }
        }

        public string Zip
        {
            get { return (mZip); }
            set { mZip = value; }
        }

        public ECountry Country
        {
            get { return (mCountry); }
            set { mCountry = value; }
        }

        public Coordinate Coordinate
        {
            get { return mCoordinate; }
            set { mCoordinate = value; }
        }

        public decimal Latitude
        {
            get { return mCoordinate.Latitude; }
            set { mCoordinate.Latitude = value; }
        }

        public decimal Longitude
        {
            get { return mCoordinate.Longitude; }
            set { mCoordinate.Longitude = value; }
        }

        public string cityStateZipCountry()
        {
            return City + ", " + State + " " + Zip + " " + Country;
        }

        #endregion

        #region IComparable Members

        //Override the Equals method        
        public override bool Equals(object other)
        {
            return CompareTo(other) == 0;
        }

        //Override the GetHashCode method
        public override int GetHashCode()
        {
            if (IsNull)// || (!IsLoaded()))
                return 0;

            return this.ToString().GetHashCode();
        }

        // Exceptions:
        //	System.ArgumentException:
        //		Other object is null
        //		The argument to compare is not a UserBase
        //		Refering object (this) is null
        public override int CompareTo(object other)
        {
            if (other == null)
                throw new System.ArgumentException("Other object is null", "other");

            ObjectLocation objectLocation = other as ObjectLocation;

            if (objectLocation == null)
                throw new System.ArgumentException("The argument to compare is not a objectLocation", "other");

            if (IsNull)// || (!IsLoaded()))
                throw new System.ArgumentException("Refering object (this) is null", "this");

            return this.ToString().CompareTo(objectLocation.ToString());
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
