using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;
using System.IO;

namespace MyEasy.Common
{
	public abstract class MySerialize
	{
		#region IBinarySerialize Members

		protected string FileName(string suffix, UInt64 uniqueID) {return MyEasySettings.DBLocation + uniqueID.ToString() + "_" + suffix + ".bin";}

		public void Save(object objectToSave, UInt64 uniqueID, string suffix)
		{
			string fileName = FileName(suffix, uniqueID);
			BinaryWriter binaryWriter = new BinaryWriter(File.Open(fileName, FileMode.Create));
			Write(objectToSave, binaryWriter);
			binaryWriter.Close();
		}

		// Exceptions:
		//	System.InvalidOperationException:
		//		File does not exists
		public void Load(object objectToLoad, UInt64 uniqueID, string suffix)
		{
			string fileName = FileName(suffix, uniqueID);
			if(!File.Exists(fileName))
				throw new System.InvalidOperationException(fileName + " does not exists");

			BinaryReader binaryReader = new BinaryReader(File.Open(fileName, FileMode.Open));
			Read(objectToLoad, binaryReader);
			binaryReader.Close();			
		}

		protected abstract void Write(object objectToWrite, BinaryWriter binaryWriter);

		protected abstract void Read(object objectToRead, BinaryReader binaryReader); 

		#endregion
	}
}
