using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyDAL.Object;
using MyEasyObjects.Object;
using MyEasy.Common;

namespace MyEasyBO.Object
{
    public class ObjectLocationBO
    {
        #region Members

        ObjectLocationDAL mObjectLocationDAL = new ObjectLocationDAL();

        #endregion

        public void ClearValues(ObjectLocation objectLocation)
        {
            objectLocation.UniqueID = 0;

            objectLocation.Address1 = "";
            objectLocation.Address2 = "";
            objectLocation.Address3 = "";
            objectLocation.City = "";
            objectLocation.State = "";
            objectLocation.Zip = "";
            objectLocation.Country = ECountry.eCountryNULL;
            objectLocation.Latitude = 0;
            objectLocation.Longitude = 0;
        }

        public void Delete(ObjectLocation objectLocation)
        {
            if (!objectLocation.IsLoaded())
                Load(objectLocation);

            mObjectLocationDAL.Delete(objectLocation);
        }

        public void Save(ObjectLocation objectLocation)
        {
            mObjectLocationDAL.Save(objectLocation);
        }

        // Exceptions:
        //	System.ArgumentException:
        //		objectLocation is null when loading ObjectLocation
        //		Load Failed
        public void Load(ObjectLocation objectLocation)
        {
            try
            {
                if (objectLocation.IsNull)
                {
                    throw new System.ArgumentException("objectLocation is null when loading ObjectLocation", "objectLocation");
                }

                LoadInternal(objectLocation);
            }
            catch
            {
                throw new System.ArgumentException("Load Failed", "objectLocation");
            }
        }

        // Exceptions:
        //	System.ArgumentException:
        //		Load Failed
        protected void LoadInternal(ObjectLocation objectLocation)
        {
            try
            {
                mObjectLocationDAL.Load(objectLocation, objectLocation.UniqueID);
            }
            catch
            {
                throw new System.ArgumentException("Load Failed", "objectLocation");
            }
        }
    }
}
