using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ghost
{
	public class TitleController : MonoBehaviour
	{
		[SerializeField, Header("MainCameraにアタッチ")]
		Effect_Sketch effect_Sketch = null;

		[SerializeField] private string nextSceneName = "";

		void Update()
		{
			// 条件は後々変更する
			// PCからタブレットでも動くように条件式を書き換える
			if (Input.GetMouseButtonDown(0) && !effect_Sketch.Scene_changing)
			{
				effect_Sketch.Scene_changing = true;
				StartCoroutine(effect_Sketch.NextScene(nextSceneName));
           
				//StartCoroutine(nextScene());
				//GameSceneManager.LoadScenarioScene();
			}
		}
	}
}