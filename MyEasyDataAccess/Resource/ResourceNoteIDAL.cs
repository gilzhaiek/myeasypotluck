using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.Resource;

namespace MyEasyIDAL.Resource
{
	public interface ResourceNoteIDAL
	{
		void Load(ResourceNote resourceNote, UInt64 uniqueID);

		bool IsLatest(ResourceNote resourceNote);

		void Save(ResourceNote resourceNote);
	}
}
