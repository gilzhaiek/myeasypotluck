using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyDAL.User;

namespace MyEasyBO.UserBO
{
    public class UsersConnectionBO
    {
        #region Members

        UsersConnectionDAL mUsersConnectionDAL = new UsersConnectionDAL();

        #endregion

        public void ResetAllConnections(string user1UniqueID, List<string> user2UniqueIDs)
        {
            mUsersConnectionDAL.ResetAllConnections(user1UniqueID, user2UniqueIDs);
        }

        public bool ConnectionExists(UInt64 user1UniqueID, UInt64 user2UniqueID)
        {
            if (mUsersConnectionDAL.ConnectionExists(user1UniqueID, user2UniqueID))
                return true;
            else if (mUsersConnectionDAL.ConnectionExists(user2UniqueID, user1UniqueID))
                return true;

            return false;
        }

        public void AddConnection(UInt64 user1UniqueID, UInt64 user2UniqueID)
        {
            if (ConnectionExists(user1UniqueID, user2UniqueID))
                return;

            mUsersConnectionDAL.AddConnection(user1UniqueID, user2UniqueID);
        }

        public void RemoveConnection(UInt64 user1UniqueID, UInt64 user2UniqueID)
        {
            if (mUsersConnectionDAL.ConnectionExists(user1UniqueID, user2UniqueID))
                mUsersConnectionDAL.RemoveConnection(user1UniqueID, user2UniqueID);

            if (mUsersConnectionDAL.ConnectionExists(user2UniqueID, user1UniqueID))
                mUsersConnectionDAL.RemoveConnection(user2UniqueID, user1UniqueID);
        }

        public List<UInt64> GetConnections(UInt64 userUniqueID)
        {
            return mUsersConnectionDAL.GetConnections(userUniqueID);
        }

        public void CloseSqlConnection()
        {
            mUsersConnectionDAL.CloseSqlConnection();
        }
    }
}
