using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.Object;
using MyEasyDAL.Object;
using MyEasyObjects.Icons;
using MyEasy.Common;

namespace MyEasyBO.Object
{
    public class UserNameImageListBO
    {
        #region Members

        UserNameImageListDAL mUserNameImageListDAL = new UserNameImageListDAL();

        #endregion

        public void ClearValues(UserNameImageList userNameImageList)
        {
            userNameImageList.UniqueID = 0;

            userNameImageList.Items.Clear();
        }

        public void SetDefaultList(UserNameImageList userNameImageList)
        {
            userNameImageList.Items.Clear();

            foreach (NameImage nameImageItem in DefaultIconsList.Instance.DefaultIcons)
            {
                nameImageItem.IsDefault = true;
                userNameImageList.Items.Add(nameImageItem);
            }
        }

        public void Save(UserNameImageList userNameImageList)
        {
            UserNameImageList userNameImageListNonDefault = new UserNameImageList(userNameImageList.UniqueID);

            foreach (NameImage nameImageItem in userNameImageList.Items)
            {
                bool foundDefault = false;
                foreach (NameImage defaultNameImageItem in DefaultIconsList.Instance.DefaultIcons)
                {
                    if ((nameImageItem.Name == defaultNameImageItem.Name) &&
                        (nameImageItem.ImageLocation == defaultNameImageItem.ImageLocation))
                    {
                        foundDefault = true;
                        break;
                    }
                }

                if (!foundDefault)
                    userNameImageListNonDefault.Items.Add(nameImageItem);
            }

            mUserNameImageListDAL.Save(userNameImageListNonDefault);
        }

        // Exceptions:
        //	System.ArgumentException:
        //		resourceBase is null when loading UserNameImageList
        //		Load Failed
        public void Load(UserNameImageList userNameImageList)
        {
            try
            {
                Load(userNameImageList, userNameImageList.UniqueID);
            }
            catch
            {
                throw new System.ArgumentException("Load Failed", "userNameImageList");
            }
        }

        // Exceptions:
        //	System.ArgumentException:
        //		Load Failed
        public void Load(UserNameImageList userNameImageList, UInt64 uniqueID)
        {
            SetDefaultList(userNameImageList);
            userNameImageList.Items.Sort();

            try
            {
                mUserNameImageListDAL.LoadToImageList(userNameImageList, uniqueID, 0);
            }
            catch
            {
                throw new System.ArgumentException("Load Failed", "userNameImageList");
            }
        }

        /*public bool IsLatest(UserNameImageList userNameImageList)
		{
			return mUserNameImageListDAL.IsLatest(userNameImageList);
		}*/

        public void GetLatest(UserNameImageList userNameImageList)
        {
            //if(!mUserNameImageListDAL.IsLatest(userNameImageList))
            Load(userNameImageList);
        }
    }
}
