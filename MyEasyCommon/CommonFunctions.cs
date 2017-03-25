using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyEasy.Common
{
	public class MyComboBoxItem
	{
		private string	mName;
		private int		mValue;

		public	MyComboBoxItem(int value, string name)
		{
			mName = name;
			mValue = value;
		}

		public int		Value
		{
			get {return mValue;}
		}

		public override string ToString()
		{
			return mName;
		}
	}

	public class MultipleLineListBoxItem
	{

	}

	public static class CommonStaticFunctions
	{
		public static Random mGlobalRandom = new Random();

		public static UInt64 NextUInt64() 
		{ 
			var buffer = new byte[sizeof(UInt64)]; 
			mGlobalRandom.NextBytes(buffer); 
			return BitConverter.ToUInt64(buffer, 0); 
		} 

		/*public static string DateTimeToDateString(DateTime dateTime)
		{
			string retDate = dateTime.Day.ToString() + "-";

			switch (dateTime.Month)
			{
				case 1 : retDate += "Jan" ; break;
				case 2 : retDate += "Feb" ; break;
				case 3 : retDate += "Mar" ; break;
				case 4 : retDate += "Apr" ; break;
				case 5 : retDate += "May" ; break;
				case 6 : retDate += "Jun" ; break;
				case 7 : retDate += "Jul" ; break;
				case 8 : retDate += "Aug" ; break;
				case 9 : retDate += "Sep" ; break;
				case 10 : retDate += "Oct" ; break;
				case 11 : retDate += "Nov" ; break;
				case 12 : retDate += "Dec" ; break;
			}
			retDate = retDate + "-" + dateTime.Year.ToString();

			return retDate;
		}*/

		public static string DateTimeToTimeString(DateTime dateTime)
		{
			string retDate = dateTime.Day.ToString() + "-";

			switch (dateTime.Month)
			{
				case 1 : retDate += "Jan" ; break;
				case 2 : retDate += "Feb" ; break;
				case 3 : retDate += "Mar" ; break;
				case 4 : retDate += "Apr" ; break;
				case 5 : retDate += "May" ; break;
				case 6 : retDate += "Jun" ; break;
				case 7 : retDate += "Jul" ; break;
				case 8 : retDate += "Aug" ; break;
				case 9 : retDate += "Sep" ; break;
				case 10 : retDate += "Oct" ; break;
				case 11 : retDate += "Nov" ; break;
				case 12 : retDate += "Dec" ; break;
			}
			retDate = retDate + "-" + dateTime.Year.ToString();

			return retDate;
		}


		public static DateTime ParseDateTime(string dateBox, string timeBox)
		{
			bool pmFlag = false;
			//public DateTime(int year, int month, int day, int hour, int minute, int second);
			int year	= 1;
			int month	= 1;
			int day		= 1;
			int	hour	= 0;
			int	minute	= 0;

			if(timeBox != String.Empty)
			{
				string[] timeBoxSplt = timeBox.Split(':');
				if(timeBoxSplt.Count() == 2)
				{
					string minStr = timeBoxSplt[1];
					pmFlag = minStr.Contains("PM");
					
					minute = int.Parse(minStr.Substring(0,2));
					hour	= int.Parse(timeBoxSplt[0]);
					
					if(pmFlag)
						hour += 12;

					if(hour > 23)
					{
						hour = 23;
						minute = 59;
					}
				}
			}

			if(dateBox != String.Empty)
			{
				string[] dateBoxSplt = dateBox.Split('-');
				if(dateBoxSplt.Count() == 3)
				{
					year	= int.Parse(dateBoxSplt[2]);
					switch (dateBoxSplt[1])
					{
						case "Jan" : month = 1; break;
						case "Feb" : month = 2; break;
						case "Mar" : month = 3; break;
						case "Apr" : month = 4; break;
						case "May" : month = 5; break;
						case "Jun" : month = 6; break;
						case "Jul" : month = 7; break;
						case "Aug" : month = 8; break;
						case "Sep" : month = 9; break;
						case "Oct" : month = 10; break;
						case "Nov" : month = 11; break;
						case "Dec" : month = 12; break;
					}

					day		= int.Parse(dateBoxSplt[0]);
				}
			}


			DateTime dateTime = new DateTime(year, month, day, hour, minute, 0);

			return dateTime;
		}
	}
}
