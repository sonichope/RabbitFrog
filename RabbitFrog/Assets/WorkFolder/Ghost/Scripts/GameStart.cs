using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ghost
{
	public class GameStart : MonoBehaviour
	{
		private void Awake()
		{
			GameSetting.RegisterUnitSerializeDataAsync();
			GameSetting.RegisterDeckSerializeDataAsync();
			UserDataControl.InitSaveData();
		}

		public bool IsFinishData()
		{
			return GameSetting.FinishRegisterData() && GameSetting.FinishRegisterData();
		}
	}
}
