using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyDAL.Resource;
using MyEasyObjects.Resource;

namespace MyEasyBO.ResourceBO
{
	public class ResourceDescriptionBO
	{
		#region Members

		ResourceDescriptionDAL mResourceDescriptionDAL = new ResourceDescriptionDAL();

		#endregion

		public void ClearValues(ResourceDescription resourceDescription)
		{
			resourceDescription.UniqueID = 0;

			resourceDescription.Topic = "";

			resourceDescription.Summary = "";

			resourceDescription.Notes.Clear();

			resourceDescription.Images.Clear();

			resourceDescription.Link = "";
		}

		public void Save(ResourceDescription resourceDescription)
		{
			mResourceDescriptionDAL.Save(resourceDescription);
		}

		public void Delete(ResourceDescription resourceDescription)
		{
            if (!resourceDescription.IsLoaded())
                Load(resourceDescription);

			mResourceDescriptionDAL.Delete(resourceDescription);
		}
		
		// Exceptions:
		//	System.ArgumentException:
		//		resourceDescription is null when loading ResourceDescription
		//		Load Failed
		public void Load(ResourceDescription resourceDescription)
		{
			try
			{
				if(resourceDescription.IsNull)
				{
					throw new System.ArgumentException("resourceDescription is null when loading ResourceDescription", "resourceDescription");
				}				

				LoadInternal(resourceDescription);
			}
			catch
			{
				throw new System.ArgumentException("Load Failed", "resourceDescription");
			}
		}

		// Exceptions:
		//	System.ArgumentException:
		//		Load Failed
		protected void LoadInternal(ResourceDescription resourceDescription)
		{
			try
			{
                resourceDescription.Notes.Clear();
                resourceDescription.Images.Clear();
                mResourceDescriptionDAL.Load(resourceDescription, resourceDescription.UniqueID);
			}
			catch
			{
				throw new System.ArgumentException("Load Failed", "resourceDescription");
			}
		}
	}
}
