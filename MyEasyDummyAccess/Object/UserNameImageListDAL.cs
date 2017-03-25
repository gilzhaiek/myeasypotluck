using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasy.Common;
using MyEasyIDAL.Object;
using MyEasyObjects.Object;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace MyEasyDAL.Object
{
    public class UserNameImageListDAL : MyObjectBaseDAL, UserNameImageListIDAL
    {
        public void Save(UserNameImageList userNameImageList)
        {
            if (userNameImageList.IsNull)
            {
                throw new System.ArgumentException("userNameImageList is null", "userNameImageList");
            }
            else
            {
                UpdateInternal(userNameImageList);
            }
        }

        public void LoadToImageList(UserNameImageList userNameImageList, UInt64 uniqueID, int index)
        {
            SqlDataReader sqlReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("select * from UserNameImages where UserUniqueID = @1", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = uniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlReader = sqlCommand.ExecuteReader();

                userNameImageList.UniqueID = uniqueID;
                userNameImageList.LastDALChange = DateTime.Now.Ticks;
                while (sqlReader.Read())
                {
                    Int64 lastDALChange = Convert.ToInt64(sqlReader["LastDALChange"].ToString());
                    userNameImageList.LastDALChange = (lastDALChange < userNameImageList.LastDALChange) ? lastDALChange : userNameImageList.LastDALChange;
                    NameImage newNameImage = new NameImage(sqlReader["Name"].ToString(), sqlReader["ImageLocation"].ToString(), int.Parse(sqlReader["Value"].ToString()));
                    newNameImage.IsDefault = false;
                    userNameImageList.Items.Insert(index++, newNameImage);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                sqlReader.Close();
            }
        }

        protected void UpdateInternal(UserNameImageList userNameImageList)
        {
            try
            {
                UserNameImageList savedNameImageList = new UserNameImageList(userNameImageList.UniqueID);
                LoadToImageList(savedNameImageList, userNameImageList.UniqueID, savedNameImageList.Items.Count);

                userNameImageList.LastDALChange = DateTime.Now.Ticks;

                // Remove items that are not in the list
                foreach (NameImage savedNameImageItem in savedNameImageList.Items)
                {
                    bool removedItem = true;
                    foreach (NameImage nameImageItem in userNameImageList.Items)
                    {
                        if ((nameImageItem.Name == savedNameImageItem.Name) &&
                            (nameImageItem.ImageLocation == savedNameImageItem.ImageLocation))
                        {
                            removedItem = false;
                            break;
                        }
                    }

                    if (removedItem)
                    {
                        SqlCommand sqlCommand = new SqlCommand("delete from UserNameImages where " +
                            "Name=@Name and " +
                            "UserUniqueID= '" + userNameImageList.UniqueID.ToString() + "' and " +
                            "ImageLocation= '" + savedNameImageItem.ImageLocation + "';");

                        SqlParameter sqlParameter = new SqlParameter("@Name", SqlDbType.NVarChar);
                        sqlParameter.Value = savedNameImageItem.Name;
                        sqlCommand.Parameters.Add(sqlParameter);

                        sqlCommand.Connection = mSqlConnection;

                        int lineRemoved = sqlCommand.ExecuteNonQuery();

                        if (lineRemoved != 1)
                        {
                            throw new System.ArgumentException("delete from UserNameImages UserUniqueID=" + userNameImageList.UniqueID.ToString() + " failed", "userNameImageList.UniqueID");
                        }
                    }
                }

                // Add new Items
                foreach (NameImage nameImageItem in userNameImageList.Items)
                {
                    bool foundSaved = false;
                    foreach (NameImage savedNameImageItem in savedNameImageList.Items)
                    {
                        if ((nameImageItem.Name == savedNameImageItem.Name) &&
                            (nameImageItem.ImageLocation == savedNameImageItem.ImageLocation))
                        {
                            foundSaved = true;
                            break;
                        }
                    }

                    if (!foundSaved)
                    {
                        SqlCommand sqlCommand = new SqlCommand("Insert Into UserNameImages" +
                            " (UserUniqueID, LastDALChange, Name, ImageLocation, Value) values ('" +
                            userNameImageList.UniqueID.ToString() + "', '" +
                            userNameImageList.LastDALChange.ToString() + "', " +
                            "@Name, '" +
                            nameImageItem.ImageLocation + "', '" +
                            nameImageItem.Value.ToString() + "');");

                        SqlParameter sqlParameter = new SqlParameter("@Name", SqlDbType.NVarChar);
                        sqlParameter.Value = nameImageItem.Name;
                        sqlCommand.Parameters.Add(sqlParameter);

                        sqlCommand.Connection = mSqlConnection;

                        int lineInserted = sqlCommand.ExecuteNonQuery();

                        if (lineInserted != 1)
                        {
                            throw new System.ArgumentException("Insert Into UserNameImages UserUniqueID=" + userNameImageList.UniqueID.ToString() + " failed", "userNameImageList.UniqueID");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
