using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyDAL.Resource;
using MyEasyObjects.Resource;
using MyEasyObjects.User;

namespace MyEasyBO.ResourceBO
{
    public class ResourceImageBO
    {
        #region Members

        ResourceImageDAL mResourceImageDAL = new ResourceImageDAL();

        #endregion

        public void ClearValues(ResourceImage resourceImage)
        {
            resourceImage.UniqueID = 0;

            resourceImage.ImageOwner = new UserBase();

            resourceImage.ResourceBase = new ResourceBase();

            resourceImage.ImageLocation = "";

            resourceImage.EntryDate = null;
        }

        public void Save(ResourceImage resourceImage)
        {
            mResourceImageDAL.Save(resourceImage);
        }

        // Exceptions:
        //	System.ArgumentException:
        //		resourceImage is null when loading ResourceImage
        //		Load Failed
        public void Load(ResourceImage resourceImage)
        {
            try
            {
                if (resourceImage.IsNull)
                {
                    throw new System.ArgumentException("resourceImage is null when loading ResourceImage", "resourceImage");
                }

                Load(resourceImage, resourceImage.UniqueID);
            }
            catch
            {
                throw new System.ArgumentException("Load Failed", "resourceImage");
            }
        }

        // Exceptions:
        //	System.ArgumentException:
        //		Load Failed
        public void Load(ResourceImage resourceImage, UInt64 uniqueID)
        {
            try
            {
                mResourceImageDAL.Load(resourceImage, uniqueID);
            }
            catch
            {
                throw new System.ArgumentException("Load Failed", "resourceImage");
            }
        }
    }
}
