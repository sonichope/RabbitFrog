using System;
using System.Collections;
using System.Collections.Generic;
using Ghost;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ghost
{
	public class SetupStart : MonoBehaviour
	{
		[SerializeField] private GameStart gameStart = null;

		private void Update()
		{
			if (!gameStart.IsFinishData()) return;
			SceneManager.LoadSceneAsync("Title");
		}
	}
}

