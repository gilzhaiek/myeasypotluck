using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyDAL.Resource;
using MyEasyObjects.Resource;
using MyEasyBO.UserBO;
using MyEasyObjects.User;
using MyEasy.Common;
using MyEasyObjects.Object;
using MyEasyBO.Object;

namespace MyEasyBO.ResourceBO
{
    public class ResourceBaseBO
    {
        #region Function

        public void ClearValues(ResourceBase resourceBase)
        {
            //resourceBase.UniqueID = 0;
            resourceBase.Admin = new UserBase();
            resourceBase.ResourceDescription = new ResourceDescription();
            resourceBase.ResourcePriority = MyEasySettings.DefaultResourcePriority;
            resourceBase.HoldingsInfo.Clear();
            resourceBase.Scalable = false;
            resourceBase.CurrentUserHoldingPermissions = EHoldingPermissions.eHoldingPermissionsNull;
        }

        #endregion
    }
}
