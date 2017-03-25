using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.Object;
using MyEasy.Common;
using MyEasyIDAL.Object;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace MyEasyDAL.Object
{
	public class ObjectLocationDAL :  MyObjectBaseDAL, ObjectLocationIDAL
	{
		#region Members
		#endregion

		public ObjectLocationDAL()
		{
		}

		public bool IsLatest(ObjectLocation objectLocation)
		{
			ObjectLocation upToDateObjectLocation = new ObjectLocation();

			Load(upToDateObjectLocation, objectLocation.UniqueID);

			return (upToDateObjectLocation.LastDALChange == objectLocation.LastDALChange);
		}


		public bool ObjectLocationExists(UInt64 uniqueID)
		{
            return ObjectBaseExists(uniqueID, "ObjectLocation", "UniqueID");
		}

		// Exceptions:
		//	System.ArgumentException:
		//		objectLocation is null when saving ObjectLocation
		public void	Save(ObjectLocation objectLocation)
		{
			if(objectLocation.IsNull)
			{
				SaveInternal(objectLocation);
			}
			else
			{
				ObjectLocation upToDateObjectLocation = new ObjectLocation();

				try
				{
					Load(upToDateObjectLocation, objectLocation.UniqueID);
				}
				catch
				{
					SaveInternal(objectLocation);
					return;
				}

				if(objectLocation.CompareTo(upToDateObjectLocation) != 0)
					UpdateInternal(objectLocation);
			}
		}

        public void Delete(ObjectLocation objectLocation)
        {
            if (objectLocation.IsNull)
            {
                throw new System.ArgumentException("resourceDescription is null when removing ObjectLocation", "objectLocation");
            }

            if (ObjectLocationExists(objectLocation.UniqueID))
            {
                DeleteInternal(objectLocation);
            }
            else
                throw new System.ArgumentException("resourceDescription does not exists while removing ObjectLocation", "objectLocation");
        }


		public void Load(ObjectLocation objectLocation, UInt64 uniqueID)
		{
			SqlDataReader	sqlReader = null;
			SqlCommand		sqlCommand = null;

			try
			{
				sqlCommand = new SqlCommand("select * from ObjectLocation where UniqueID = @1", mSqlConnection);
				SqlParameter sqlParameter = new SqlParameter("@1", SqlDbType.BigInt);
				sqlParameter.Value = uniqueID;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlReader = sqlCommand.ExecuteReader();
				if(!sqlReader.Read())
				{
					throw new System.ArgumentException("objectLocation with uniqueID=" + uniqueID.ToString() + " was not found", "uniqueID");
				}
				
				objectLocation.UniqueID			= uniqueID;
				objectLocation.LastDALChange	= Convert.ToInt64(sqlReader["LastDALChange"].ToString());

				objectLocation.Address1	= sqlReader["Address1"].ToString();
				objectLocation.Address2	= sqlReader["Address2"].ToString();
				objectLocation.Address3	= sqlReader["Address3"].ToString();
				objectLocation.City		= sqlReader["City"].ToString();
				objectLocation.State	= sqlReader["State"].ToString();
				objectLocation.Zip		= sqlReader["Zip"].ToString();
				objectLocation.Country	= (ECountry)Enum.Parse(typeof(ECountry), sqlReader["ECountry"].ToString());
				objectLocation.Latitude	= Convert.ToDecimal(sqlReader["Latitude"].ToString());
				objectLocation.Longitude= Convert.ToDecimal(sqlReader["Longitude"].ToString());

				if(sqlReader.Read())
				{
					throw new ArgumentException("Multiple UniqueID=" + uniqueID.ToString() + " were found in ObjectLocation", "uniqueID");
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

		protected void UpdateInternal(ObjectLocation objectLocation)
		{
            try
            {
                objectLocation.LastDALChange = DateTime.Now.Ticks;

                string address1 = objectLocation.Address1;

                SqlCommand sqlCommand = new SqlCommand("Update ObjectLocation set " +
                    "LastDALChange='" + objectLocation.LastDALChange.ToString() + "'," +
                    "Address1=@Address1," +
                    "Address2=@Address2," +
                    "Address3=@Address3," +
                    "City=@City," +
                    "State=@State," +
                    "Zip='" + objectLocation.Zip + "'," +
                    "ECountry='" + objectLocation.Country.ToString() + "'," +
                    "Latitude='" + objectLocation.Latitude.ToString() + "'," +
                    "Longitude='" + objectLocation.Longitude.ToString() + "' " +
                    "Where UniqueID='" + objectLocation.UniqueID.ToString() + "'");

                SqlParameter sqlParameter = new SqlParameter("@Address1", SqlDbType.NVarChar);
                sqlParameter.Value = objectLocation.Address1;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@Address2", SqlDbType.NVarChar);
                sqlParameter.Value = objectLocation.Address2;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@Address3", SqlDbType.NVarChar);
                sqlParameter.Value = objectLocation.Address3;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@City", SqlDbType.NVarChar);
                sqlParameter.Value = objectLocation.City;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@State", SqlDbType.NVarChar);
                sqlParameter.Value = objectLocation.State;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection = mSqlConnection;

                int lineInserted = sqlCommand.ExecuteNonQuery();

                if (lineInserted != 1)
                {
                    throw new System.ArgumentException("Update Into ObjectLocation Where UniqueID=" + objectLocation.UniqueID.ToString() + " failed", "UniqueID");
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

		protected void SaveInternal(ObjectLocation objectLocation)
		{
            try
            {
                objectLocation.LastDALChange = DateTime.Now.Ticks;

                SqlCommand sqlCommand = new SqlCommand("Insert Into ObjectLocation" +
                    " (LastDALChange, Address1, Address2, Address3, City, State, Zip, ECountry, Latitude, Longitude) values ('" +
                    objectLocation.LastDALChange.ToString() + "', @Address1, @Address2, @Address3, @City, @State, '" +
                    objectLocation.Zip + "', '" +
                    objectLocation.Country.ToString() + "', '" +
                    objectLocation.Latitude.ToString() + "', '" +
                    objectLocation.Longitude.ToString() + "');" +
                    "SELECT SCOPE_IDENTITY()");

                SqlParameter sqlParameter = new SqlParameter("@Address1", SqlDbType.NVarChar);
                sqlParameter.Value = objectLocation.Address1;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@Address2", SqlDbType.NVarChar);
                sqlParameter.Value = objectLocation.Address2;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@Address3", SqlDbType.NVarChar);
                sqlParameter.Value = objectLocation.Address3;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@City", SqlDbType.NVarChar);
                sqlParameter.Value = objectLocation.City;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("@State", SqlDbType.NVarChar);
                sqlParameter.Value = objectLocation.State;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.Connection = mSqlConnection;

                objectLocation.UniqueID = Convert.ToUInt64(sqlCommand.ExecuteScalar());
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

        protected void DeleteInternal(ObjectLocation objectLocation)
        {
            try
            {
                objectLocation.LastDALChange = DateTime.Now.Ticks;

                SqlCommand sqlCommand = new SqlCommand("delete from ObjectLocation where " +
                            "UniqueID = '" + objectLocation.UniqueID.ToString() + "';");

                sqlCommand.Connection = mSqlConnection;

                int lineRemoved = sqlCommand.ExecuteNonQuery();

                if (lineRemoved != 1)
                {
                    throw new System.ArgumentException("Delete from ObjectLocation Where UniqueID=" + objectLocation.UniqueID.ToString() + " failed", "UniqueID");
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
