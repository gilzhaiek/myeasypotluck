using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyDAL.Resource;
using MyEasyObjects.Resource;
using MyEasyObjects.User;

namespace MyEasyBO.ResourceBO
{
	public class ResourceNoteBO
	{
		#region Members

		ResourceNoteDAL mResourceNoteDAL = new ResourceNoteDAL();

		#endregion

		public void ClearValues(ResourceNote resourceNote)
		{
			resourceNote.UniqueID		= 0;

			resourceNote.NoteWriter		= new UserBase();

			resourceNote.ResourceBase	= new ResourceBase();

			resourceNote.Note			= "";

			resourceNote.EntryDate		= null;
		}

		public void Save(ResourceNote resourceNote)
		{
			mResourceNoteDAL.Save(resourceNote);
		}

		// Exceptions:
		//	System.ArgumentException:
		//		resourceNote is null when loading ResourceNote
		//		Load Failed
		public void Load(ResourceNote resourceNote)
		{
			try
			{
				if(resourceNote.IsNull)
				{
					throw new System.ArgumentException("resourceNote is null when loading ResourceNote", "resourceNote");
				}				

				Load(resourceNote, resourceNote.UniqueID);
			}
			catch
			{
				throw new System.ArgumentException("Load Failed", "resourceNote");
			}
		}

		// Exceptions:
		//	System.ArgumentException:
		//		Load Failed
		public void Load(ResourceNote resourceNote, UInt64 uniqueID)
		{
			try
			{
				mResourceNoteDAL.Load(resourceNote, uniqueID);
			}
			catch
			{
				throw new System.ArgumentException("Load Failed", "resourceNote");
			}
		}
	}
}
