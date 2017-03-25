using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.Resource;

namespace MyEasyIDAL.Resource
{
	public interface ResourceDescriptionIDAL
	{
		void Load(ResourceDescription resourceDescription, UInt64 uniqueID);

		bool IsLatest(ResourceDescription resourceDescription);

		void Save(ResourceDescription resourceDescription);
	}
}
