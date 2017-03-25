using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.User;
using MyEasyObjects.Resource;
using MyEasy.Common;
using System.IO;
using System.Data.SqlTypes;
using System.ComponentModel;

namespace MyEasyObjects.Resource
{
    public class ResourceNote : MyObjectBase, INotifyPropertyChanged
    {
        #region Members

        UserBase mNoteWriter;

        ResourceBase mResourceBase;

        string mNote = "";

        DateTime? mEntryDate = null; Í

        #endregion

        #region constructor

        public ResourceNote()
        {
            mNoteWriter = new UserBase();
            mResourceBase = new ResourceBase();
        }

        public ResourceNote(UInt64 uniqueID)
            : base(uniqueID)
        {
            mNoteWriter = new UserBase();
            mResourceBase = new ResourceBase();
        }

        public ResourceNote(UInt64 uniqueID, UserBase noteWriter, string note, DateTime? entryDate)
            : base(uniqueID)
        {
            mNoteWriter = noteWriter;
            mResourceBase = new ResourceBase();
            mNote = note;
            mEntryDate = entryDate;
        }

        public ResourceNote(UInt64 uniqueID, UserBase noteWriter, string note, DateTime? entryDate, ResourceBase resourceBase)
            : base(uniqueID)
        {
            mNoteWriter = noteWriter;
            mResourceBase = resourceBase;
            mNote = note;
            mEntryDate = entryDate;
        }

        #endregion

        public UserBase NoteWriter
        {
            get { return mNoteWriter; }
            set { mNoteWriter = value; }
        }

        public ResourceBase ResourceBase
        {
            get { return mResourceBase; }
            set { mResourceBase = value; }
        }

        public string Note
        {
            get { return mNote; }
            set { mNote = value; }
        }

        public DateTime? EntryDate
        {
            get { return mEntryDate; }
            set { mEntryDate = value; }
        }

        #region String Conversion Members

        public override string ToString()
        {
            if (IsNull)// || (!IsLoaded()))
                throw new System.ArgumentException("ToString failed, this is null or not loaded", "this");
            else
            {
                string retStr = UniqueID.ToString();

                retStr += mDelim + NoteWriter.UniqueID.ToString();

                retStr += mDelim + ResourceBase.UniqueID.ToString();

                retStr += mDelim + Note;

                if (EntryDate != null)
                    retStr += mDelim + EntryDate.Value.Ticks.ToString();
                else
                    retStr += mDelim + "0";

                return retStr;
            }
        }

        public static ResourceNote Parse(SqlString sqlStr)
        {
            if (sqlStr.IsNull)
                return null;
            else
            {
                return Parse(Convert.ToString(sqlStr));
            }
        }

        public static ResourceNote Parse(string str)
        {
            int strCnt = 0;

            ResourceNote note = new ResourceNote();

            string[] strSplit = null;
            strSplit = str.Split(new char[] { ';' });

            strCnt = Parse(note, strSplit, strCnt);

            return note;
        }

        public static int Parse(ResourceNote note, string[] strSplit, int strCnt)
        {
            note.UniqueID = Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

            note.NoteWriter.UniqueID = Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

            note.ResourceBase.UniqueID = Convert.ToUInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt]); strCnt++;

            note.Note = strSplit[strCnt]; strCnt++;

            note.EntryDate = new DateTime(Convert.ToInt64(strSplit[strCnt] == null ? "0" : strSplit[strCnt])); strCnt++;

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

            ResourceNote resourceNote = other as ResourceNote;

            if (resourceNote == null)
                throw new System.ArgumentException("The argument to compare is not a resourceNote", "other");

            if (IsNull)// || (!IsLoaded()))
                throw new System.ArgumentException("Refering object (this) is null", "this");

            return this.ToString().CompareTo(resourceNote.ToString());
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
