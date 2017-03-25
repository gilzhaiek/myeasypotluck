using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.Event;

namespace MyEasyIDAL.Event
{
	public interface EventBaseIDAL
	{
		void Load(EventBase eventBase, UInt64 uniqueID);

		bool IsLatest(EventBase eventBase, bool checkRelations);

		void Save(EventBase eventBase);

		List<UInt64> GetChildrenUniqueIDs(UInt64 eventParentUniqueID);
	}
}
