using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ghost
{
	public class SelectStart : MonoBehaviour
	{
		
		private void Awake()
		{
			GameSetting.RegisterStageSerializeDataAsync();
		}

		private void Update()
		{
			if (GameSetting.FinishStageRegisterData())
			{
				
			}
		}
	}
}