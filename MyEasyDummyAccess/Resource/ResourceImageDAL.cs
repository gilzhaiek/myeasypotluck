using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.Resource;
using MyEasy.Common;
using MyEasyIDAL.Resource;
using MyEasyObjects.User;
using System.IO;

namespace MyEasyDAL.Resource
{
	public class ResourceImageDAL : MySerialize, ResourceImageIDAL
	{
		public void Load(ResourceImage resourceImage, UInt64 uniqueID)
		{
			Load(resourceImage, uniqueID, "ResourceImage");
		}

		public bool IsLatest(ResourceImage resourceImage)
		{
			ResourceImage upToDateResourceImage = new ResourceImage();

			Load(upToDateResourceImage, resourceImage.UniqueID);

			return (upToDateResourceImage.LastDALChange == resourceImage.LastDALChange);
		}

		// Exceptions:
		//	System.ArgumentException:
		//		resourceImage is null when saving ResourceImage
		public void	Save(ResourceImage resourceImage)
		{
			if(resourceImage.IsNull)
			{
				throw new System.ArgumentException("resourceImage is null when saving ResourceImage", "resourceImage");
			}

			ResourceImage upToDateResourceImage = new ResourceImage();
			try
			{
				Load(upToDateResourceImage, resourceImage.UniqueID);
			}
			catch
			{
				// No need to compare
				Save(resourceImage, resourceImage.UniqueID, "ResourceImage");
				return;
			}

			if(resourceImage.CompareTo(upToDateResourceImage) != 0)
				Save(resourceImage, resourceImage.UniqueID, "ResourceImage");
		}

		// Exceptions:
		//	System.ArgumentException:
		//		objectToRead is null
		//		objectToRead is not a ResourceImage
		//		Read failed
		protected override void Read(object objectToRead, BinaryReader binaryReader)
		{
			try
			{
				if (objectToRead == null)
					throw new ArgumentException("objectToRead is null", "objectToRead");

				ResourceImage resourceImage = objectToRead as ResourceImage;

				if (resourceImage == null)
					throw new ArgumentException("objectToRead is not a ResourceImage", "objectToRead");

				byte header = binaryReader.ReadByte();

				if (header == 1)
				{
					resourceImage.UniqueID = 0;
					return;
				}

				resourceImage.UniqueID = binaryReader.ReadUInt64();

				resourceImage.LastDALChange = binaryReader.ReadInt64();

				if((resourceImage.LastDALChange == 0) || (resourceImage.UniqueID == 0))
					throw new System.ArgumentException("resourceImage did not load correctly", "resourceImage");
				
				resourceImage.ImageOwner	= new UserBase(binaryReader.ReadUInt64());

				resourceImage.ResourceBase	= new ResourceBase(binaryReader.ReadUInt64());

				resourceImage.ImageLocation	= binaryReader.ReadString();

				resourceImage.EntryDate		= new DateTime(binaryReader.ReadInt64());			 
			}
			catch
			{
				throw new ArgumentException("Read failed", "objectToRead");
			}
		}

		// Exceptions:
		//	System.ArgumentException:
		//		objectToWrite is null
		//		objectToWrite is not a ResourceImage
		//		resourceImage is not loaded
		protected override void Write(object objectToWrite, BinaryWriter binaryWriter)
		{
			try
			{
				if (objectToWrite == null)
					throw new ArgumentException("objectToWrite to not null", "objectToWrite");

				ResourceImage resourceImage = objectToWrite as ResourceImage;

				if (resourceImage == null)
					throw new ArgumentException("objectToWrite is not a ResourceImage", "objectToWrite");

				byte header = (byte)(resourceImage.IsNull? 1 : 0);

				binaryWriter.Write(header);
				if (header == 1)
				{
					return;
				}

				/*if(!resourceImage.IsLoaded())
					throw new ArgumentException("resourceImage is not loaded", "objectToWrite");*/

				resourceImage.LastDALChange = DateTime.Now.Ticks;

				binaryWriter.Write(resourceImage.UniqueID);
				
				binaryWriter.Write(resourceImage.LastDALChange);

				binaryWriter.Write(resourceImage.ImageOwner.UniqueID);

				binaryWriter.Write(resourceImage.ResourceBase.UniqueID);

				binaryWriter.Write(resourceImage.ImageLocation);

				if(resourceImage.EntryDate != null)
					binaryWriter.Write(resourceImage.EntryDate.Value.Ticks);
				else
					binaryWriter.Write(0);
			}
			catch
			{
				throw new ArgumentException("Write failed", "objectToRead");
			}
		}
	}
}
