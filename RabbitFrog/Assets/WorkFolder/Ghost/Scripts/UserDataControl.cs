using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ghost
{
	public class UserDataControl
	{
		private static SaveData _saveData;
		public static SaveData SaveData
		{
			get
			{
				if( _saveData.IsValue()) return _saveData;
				 return InitSaveData();
			}
		}

		public static SaveData InitSaveData()
		{
			_saveData = new SaveData();
			_saveData.Init();
			return _saveData;
		}
	}
}