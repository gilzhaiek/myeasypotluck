using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;
using System.IO;

namespace MyEasy.Common
{
	public class UniqueIDManager : IBinarySerialize
	{
		#region Members

		private static UniqueIDManager mInstance;

		private bool	mIsNull;
		private	UInt64	mNextAvailableUniqueID;
		const string	mFileName = "UniqueIDManager.bin";

		#endregion

		#region Constructor

		public UniqueIDManager() {}

		public static UniqueIDManager Instance
		{
			get
			{
				if(mInstance == null)
				{
					mInstance = new UniqueIDManager();
					mInstance.Init();
				}

				return mInstance;
			}
		}

		#endregion

		#region Functions

		public void Init()
		{
			mIsNull = true;
			if(!File.Exists(mFileName))
			{
				mNextAvailableUniqueID = 1;
				Save();
			}
			else
			{
				Load();
			}
		}

		public bool	IsNull { get {return mIsNull;}}

		public UInt64 GetAUniqueID()
		{
			UInt64 retUniqueID; 
			lock(this)
			{
				retUniqueID = mNextAvailableUniqueID++;
				Save();
			}

			return retUniqueID;
		}

		#endregion

		#region IBinarySerialize Members

		protected void Save()
		{
			BinaryWriter binaryWriter = new BinaryWriter(File.Open(mFileName, FileMode.Create));
			Write(binaryWriter);
			binaryWriter.Close();
		}

		public void Write(BinaryWriter binaryWriter)
		{
			binaryWriter.Write(mNextAvailableUniqueID);
		}

		protected void Load()
		{
			BinaryReader binaryReader = new BinaryReader(File.Open(mFileName, FileMode.Open));
			Read(binaryReader);
			binaryReader.Close();
		}

		public void Read(BinaryReader binaryReader)
		{
			try
			{
				mNextAvailableUniqueID	= binaryReader.ReadUInt64();
			}
			catch
			{
				mIsNull = true;
				return;
			}

			mIsNull = false;
		}
		#endregion
	}
}
