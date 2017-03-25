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
	public class ResourceNoteDAL : MySerialize, ResourceNoteIDAL
	{
		public void Load(ResourceNote resourceNote, UInt64 uniqueID)
		{
			Load(resourceNote, uniqueID, "ResourceNote");
		}

		public bool IsLatest(ResourceNote resourceNote)
		{
			ResourceNote upToDateResourceNote = new ResourceNote();

			Load(upToDateResourceNote, resourceNote.UniqueID);

			return (upToDateResourceNote.LastDALChange == resourceNote.LastDALChange);
		}

		// Exceptions:
		//	System.ArgumentException:
		//		resourceNote is null when saving ResourceNote
		public void	Save(ResourceNote resourceNote)
		{
			if(resourceNote.IsNull)
			{
				throw new System.ArgumentException("resourceNote is null when saving ResourceNote", "resourceNote");
			}

			ResourceNote upToDateResourceNote = new ResourceNote();
			try
			{
				Load(upToDateResourceNote, resourceNote.UniqueID);
			}
			catch
			{
				// No need to compare
				Save(resourceNote, resourceNote.UniqueID, "ResourceNote");
				return;
			}

			if(resourceNote.CompareTo(upToDateResourceNote) != 0)
				Save(resourceNote, resourceNote.UniqueID, "ResourceNote");
		}

		// Exceptions:
		//	System.ArgumentException:
		//		objectToRead is null
		//		objectToRead is not a ResourceNote
		//		Read failed
		protected override void Read(object objectToRead, BinaryReader binaryReader)
		{
			try
			{
				if (objectToRead == null)
					throw new ArgumentException("objectToRead is null", "objectToRead");

				ResourceNote resourceNote = objectToRead as ResourceNote;

				if (resourceNote == null)
					throw new ArgumentException("objectToRead is not a ResourceNote", "objectToRead");

				byte header = binaryReader.ReadByte();

				if (header == 1)
				{
					resourceNote.UniqueID = 0;
					return;
				}

				resourceNote.UniqueID = binaryReader.ReadUInt64();

				resourceNote.LastDALChange = binaryReader.ReadInt64();

				if((resourceNote.LastDALChange == 0) || (resourceNote.UniqueID == 0))
					throw new System.ArgumentException("resourceNote did not load correctly", "resourceNote");

				resourceNote.NoteWriter		= new UserBase(binaryReader.ReadUInt64());

				resourceNote.ResourceBase	= new ResourceBase(binaryReader.ReadUInt64());

				resourceNote.Note			= binaryReader.ReadString();

				resourceNote.EntryDate		= new DateTime(binaryReader.ReadInt64());
			}
			catch
			{
				throw new ArgumentException("Read failed", "objectToRead");
			}
		}

		// Exceptions:
		//	System.ArgumentException:
		//		objectToWrite is null
		//		objectToWrite is not a ResourceNote
		//		resourceNote is not loaded
		protected override void Write(object objectToWrite, BinaryWriter binaryWriter)
		{
			try
			{
				if (objectToWrite == null)
					throw new ArgumentException("objectToWrite to not null", "objectToWrite");

				ResourceNote resourceNote = objectToWrite as ResourceNote;

				if (resourceNote == null)
					throw new ArgumentException("objectToWrite is not a ResourceNote", "objectToWrite");

				byte header = (byte)(resourceNote.IsNull? 1 : 0);

				binaryWriter.Write(header);
				if (header == 1)
				{
					return;
				}

				/*if(!resourceNote.IsLoaded())
					throw new ArgumentException("resourceNote is not loaded", "objectToWrite");*/

				resourceNote.LastDALChange = DateTime.Now.Ticks;

				binaryWriter.Write(resourceNote.UniqueID);
				
				binaryWriter.Write(resourceNote.LastDALChange);
		
				binaryWriter.Write(resourceNote.NoteWriter.UniqueID);

				binaryWriter.Write(resourceNote.ResourceBase.UniqueID);

				binaryWriter.Write(resourceNote.Note);

				if(resourceNote.EntryDate != null)
					binaryWriter.Write(resourceNote.EntryDate.Value.Ticks);
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
