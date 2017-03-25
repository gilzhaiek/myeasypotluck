using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.Resource;
using MyEasy.Common;
using MyEasyIDAL.Resource;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace MyEasyDAL.Resource
{
	public class ResourceDescriptionDAL : MyObjectBaseDAL, ResourceDescriptionIDAL
	{
		public bool IsLatest(ResourceDescription resourceDescription)
		{
			ResourceDescription upToDateResourceDescription = new ResourceDescription();

			Load(upToDateResourceDescription, resourceDescription.OwnerUniqueID);

			return (upToDateResourceDescription.LastDALChange == resourceDescription.LastDALChange);
		}

		// Exceptions:
		//	System.ArgumentException:
		//		resourceDescription is null when saving ResourceDescription
		public void	Save(ResourceDescription resourceDescription)
		{
			if(resourceDescription.IsNull)
			{
				throw new System.ArgumentException("resourceDescription is null when saving ResourceDescription", "resourceDescription");
			}

			if(ResourceDescriptionExists(resourceDescription.UniqueID))
			{
				ResourceDescription upToDateItemBase = new ResourceDescription();

				try
				{
					Load(upToDateItemBase, resourceDescription.UniqueID);
				}
				catch
				{
					SaveInternal(resourceDescription);
					return;
				}

				if(resourceDescription.CompareTo(upToDateItemBase) != 0)
					UpdateInternal(resourceDescription);
			}
			else
				SaveInternal(resourceDescription);
		}
		// Exceptions:
		//	System.ArgumentException:
		public void	Delete(ResourceDescription resourceDescription)
		{
			if(resourceDescription.IsNull)
			{
				throw new System.ArgumentException("resourceDescription is null when removing ResourceDescription", "resourceDescription");
			}

			if(ResourceDescriptionExists(resourceDescription.UniqueID))
			{
				DeleteInternal(resourceDescription);
			}
			else
				throw new System.ArgumentException("resourceDescription does not exists while removing ResourceDescription", "resourceDescription");
		}


		public bool ResourceDescriptionExists(UInt64 uniqueID)
		{
			SqlDataReader	sqlReader = null;
			SqlCommand		sqlCommand = null;

            try
            {
                bool rValue;
                sqlCommand = new SqlCommand("select * from ResourceDescription where OwnerUniqueID = @1", mSqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
                sqlParameter.Value = uniqueID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlReader = sqlCommand.ExecuteReader();
                rValue = sqlReader.Read();

                return rValue;
            }
            catch (Exception exception)
            {                
                throw exception;
            }
            finally
            {
                sqlReader.Close();
                mSqlConnection.Close();
            }
		}

		public void Load(ResourceDescription resourceDescription, UInt64 ownerUniqueID)
		{
			SqlDataReader	sqlReader = null;
			SqlCommand		sqlCommand = null;

			try
			{
				sqlCommand = new SqlCommand("select * from ResourceDescription where OwnerUniqueID = @1", mSqlConnection);
				SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
				sqlParameter.Value = ownerUniqueID;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlReader = sqlCommand.ExecuteReader();
				if(!sqlReader.Read())
				{
					throw new System.ArgumentException("resourceDescription with OwnerUniqueID=" + ownerUniqueID.ToString() + " was not found", "ownerUniqueID");
				}
				
				resourceDescription.OwnerUniqueID	= ownerUniqueID;
				resourceDescription.LastDALChange	= Convert.ToInt64(sqlReader["LastDALChange"].ToString());
				resourceDescription.Topic			= sqlReader["Topic"].ToString();
				resourceDescription.Summary			= sqlReader["Summary"].ToString();
				resourceDescription.Link			= sqlReader["Link"].ToString();

				if(sqlReader.Read())
				{
					throw new ArgumentException("Multiple OwnerUniqueID=" + ownerUniqueID.ToString() + " were found in ResourceDescription", "ownerUniqueID");
				}
			}
			catch (Exception exception)
			{
				throw exception;
			}
			finally
			{
				sqlReader.Close();
                mSqlConnection.Close();
			}
		}

		protected void UpdateInternal(ResourceDescription resourceDescription)
		{
            try
            {
                resourceDescription.LastDALChange = DateTime.Now.Ticks;

                SqlCommand sqlCommand = new SqlCommand("Update ResourceDescription set " +
                    "LastDALChange='" + resourceDescription.LastDALChange.ToString() + "'," +
                    "Topic=@Topic," +
                    "Summary=@Summary," +
                    "Link='" + resourceDescription.Link + "' " +
                    "Where OwnerUniqueID='" + resourceDescription.OwnerUniqueID.ToString() + "'");

                SqlParameter sqlParameter = new SqlParameter("@Topic", SqlDbType.NVarChar);
                sqlParameter.Value = resourceDescription.Topic;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@Summary", SqlDbType.NVarChar);
                sqlParameter.Value = resourceDescription.Summary;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection = mSqlConnection;

                int lineInserted = sqlCommand.ExecuteNonQuery();

                if (lineInserted != 1)
                {
                    throw new System.ArgumentException("Update Into ResourceDescription Where OwnerUniqueID=" + resourceDescription.UniqueID.ToString() + " failed", "OwnerUniqueID");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                mSqlConnection.Close();
            }
		}

		protected void DeleteInternal(ResourceDescription resourceDescription)
		{
            try
            {
                resourceDescription.LastDALChange = DateTime.Now.Ticks;

                SqlCommand sqlCommand = new SqlCommand("delete from ResourceDescription where " +
                            "OwnerUniqueID = '" + resourceDescription.OwnerUniqueID.ToString() + "';");

                sqlCommand.Connection = mSqlConnection;

                int lineRemoved = sqlCommand.ExecuteNonQuery();

                if (lineRemoved != 1)
                {
                    throw new System.ArgumentException("Delete from ResourceDescription Where OwnerUniqueID=" + resourceDescription.OwnerUniqueID.ToString() + " failed", "OwnerUniqueID");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                mSqlConnection.Close();
            }
		}

		protected void SaveInternal(ResourceDescription resourceDescription)
		{
            try
            {
                resourceDescription.LastDALChange = DateTime.Now.Ticks;

                SqlCommand sqlCommand = new SqlCommand("Insert Into ResourceDescription" +
                    " (OwnerUniqueID, LastDALChange, Topic, Summary, Link) values ('" +
                    resourceDescription.OwnerUniqueID.ToString() + "', '" +
                    resourceDescription.LastDALChange.ToString() + "', " +
                    "@Topic, @Summary, '" +
                    resourceDescription.Link + "');");

                SqlParameter sqlParameter = new SqlParameter("@Topic", SqlDbType.NVarChar);
                sqlParameter.Value = resourceDescription.Topic;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@Summary", SqlDbType.NVarChar);
                sqlParameter.Value = resourceDescription.Summary;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection = mSqlConnection;

                int lineInserted = sqlCommand.ExecuteNonQuery();

                if (lineInserted != 1)
                {
                    throw new System.ArgumentException("Insert Into ResourceDescription UniqueID=" + resourceDescription.OwnerUniqueID + " failed", "resourceDescription");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                mSqlConnection.Close();
            }
		}
	}
}
