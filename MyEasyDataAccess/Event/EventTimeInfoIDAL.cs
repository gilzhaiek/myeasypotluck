using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasyObjects.Resource;
using MyEasyObjects.Event;

namespace MyEasyIDAL.Event
{
	public interface EventTimeInfoIDAL
	{
		void Load(EventTimeInfo eventTimeInfo, UInt64 uniqueID);

		bool IsLatest(EventTimeInfo eventTimeInfo);

		void Save(EventTimeInfo eventTimeInfo);
	}
}