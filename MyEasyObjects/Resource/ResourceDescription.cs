using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MyEasy.Common;
using System.IO;
using System.Data.SqlTypes;

namespace MyEasyObjects.Resource
{

    /// <summary>
    /// Name : Summary
    /// Images
    /// Links
    /// Notes
    /// </summary>
    public class ResourceDescription : MyObjectBase, INotifyPropertyChanged
    {
        #region members

        string mTopic = "";

        string mSummary = "";

        List<ResourceNote> mNotes = new List<ResourceNote>();

        List<ResourceImage> mImages = new List<ResourceImage>();

        string mLink = "";

        #endregion

        #region constructor

        public ResourceDescription()
        {
        }

        public ResourceDescription(UInt64 uniqueID)
            : base(uniqueID)
        {
        }

        public ResourceDescription(UInt64 uniqueID, string topic, string summary)
            : base(uniqueID)
        {
            mTopic = topic;
            mSummary = summary;
        }

        public ResourceDescription(UInt64 uniqueID, string topic, string summary, string link)
            : base(uniqueID)
        {
            mTopic = topic;
            mSummary = summary;
            mLink = link;
        }

        #endregion

        #region properties
        public UInt64 OwnerUniqueID
        {
            get { return UniqueID; }
            set { UniqueID = value; }
        }

        public string Topic
        {
            get { return mTopic; }
            set
            {
                if (mTopic != value)
                {
                    mTopic = value;
                    OnPropertyChanged("ResourceDescription.Topic.Changed");
                }
            }
        }

        public string Summary
        {
            get { return mSummary; }
            set
            {
                if (mSummary != value)
                {
                    mSummary = value;
                    OnPropertyChanged("ResourceDescription.Summary.Changed");
                }
            }
        }

        public List<ResourceNote> Notes { get { return mNotes; } }

        public List<ResourceImage> Images { get { return mImages; } }

        public string Link
        {
            get { return mLink; }
            set
            {
                if (mLink != value)
                {
                    mLink = value;
                    OnPropertyChanged("ResourceDescription.Link.Changed");
                }
            }
        }

        #endregion

        #region Functions

        public void ClearNotes()
        {
            Notes.Clear();
            OnPropertyChanged("ResourceDescription.Notes.Changed");
        }

        public void AddNote(ResourceNote resourceNote)
        {
            Notes.Add(resourceNote);
            OnPropertyChanged("ResourceDescription.Notes.Changed");
        }

        public void RemoveNote(ResourceNote resourceNote)
        {
            if (!Notes.Contains(resourceNote))
                throw new System.ArgumentException("Notes do not contain the requested resourceNote", "resourceNote");

            Notes.Remove(resourceNote);

            OnPropertyChanged("ResourceDescription.Notes.Changed");

            if (!Notes.Contains(resourceNote))
                throw new System.ArgumentException("resourceNote could not be removed from Notes", "resourceNote");
        }

        public void ClearImages()
        {
            Images.Clear();
            OnPropertyChanged("ResourceDescription.Images.Changed");
        }

        public void AddImage(ResourceImage resourceImage)
        {
            Images.Add(resourceImage);
            OnPropertyChanged("ResourceDescription.Images.Changed");
        }

        public void RemoveImage(ResourceImage resourceImage)
        {
            if (!Images.Contains(resourceImage))
                throw new System.ArgumentException("Images do not contain the requested resourceImage", "resourceImage");

            Images.Remove(resourceImage);

            OnPropertyChanged("ResourceDescription.Images.Changed");

            if (!Images.Contains(resourceImage))
                throw new System.ArgumentException("resourceImage could not be removed from Images", "resourceImage");
        }

        #endregion

        #region String Conversion Members

        public override string ToString()
        {
            if (IsNull)// || (!IsLoaded()))
                throw new System.ArgumentException("ToString failed, this is null or not loaded", "this");
            else
            {
                string retStr = UniqueID.ToString();

                retStr += mDelim + Topic;

                retStr += mDelim + Summary;

                retStr += mDelim + Notes.Count.ToString();
                for (int i = 0; i < Notes.Count; i++)
                    retStr += mDelim + Notes[i].UniqueID.ToString();

                retStr += mDelim + Images.Count.ToString();
                for (int i = 0; i < Images.Count; i++)
                    retStr += mDelim + Images[i].UniqueID.ToString();

                retStr += mDelim + Link;

                return retStr;
            }
        }

        public static ResourceDescription Parse(SqlString sqlStr)
        {
            if (sqlStr.IsNull)
                return null;
            else
            {
                return Parse(Convert.ToString(sqlStr));
            }
        }

        public static ResourceDescription Parse(string str)
        {
            int strCnt = 0;
            ResourceDescription resourceDescription = new ResourceDescription();

            string[] strSplit = null;
            strSplit = str.Split(new char[] { ';' });

            strCnt = Parse(resourceDescription, strSplit, strCnt);

            return resourceDescription;
        }

        public static int Parse(ResourceDescription resourceDescription, string[] strSplit, int strCnt)
        {
            int count = 0;

            resourceDescription.UniqueID = Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

            resourceDescription.Topic = strSplit[strCnt]; strCnt++;

            resourceDescription.Summary = strSplit[strCnt]; strCnt++;

            count = Convert.ToInt32(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;
            for (int i = 0; i < count; i++)
            {
                if (strSplit[strCnt] == null)
                    break;
                resourceDescription.Notes.Add(new ResourceNote(Convert.ToUInt64(strSplit[strCnt]))); strCnt++;
            }

            count = Convert.ToInt32(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;
            for (int i = 0; i < count; i++)
            {
                if (strSplit[strCnt] == null)
                    break;
                resourceDescription.Images.Add(new ResourceImage(Convert.ToUInt64(strSplit[strCnt]))); strCnt++;
            }

            resourceDescription.Link = strSplit[strCnt]; strCnt++;

            return strCnt;
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

            ResourceDescription resourceDescription = other as ResourceDescription;

            if (resourceDescription == null)
                throw new System.ArgumentException("The argument to compare is not a resourceDescription", "other");

            if (IsNull)// || (!IsLoaded()))
                throw new System.ArgumentException("Refering object (this) is null", "this");

            return this.ToString().CompareTo(resourceDescription.ToString());
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
