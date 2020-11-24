using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ghost
{
	public static class AiFactory
	{
		private static Dictionary<AiClass, AiController> aiMap = new Dictionary<AiClass, AiController>();

		public static void RegisterAiController()
		{
			aiMap.Add( AiClass.CLASS_DEFAULT, new DefaultAiController());
			aiMap.Add( AiClass.CLASS_ENEMY_TOWER, new EnemyTowerAiController());
			aiMap.Add( AiClass.CLASS_PLAYER_TOWER, new PlayerAiController());
		}

		public static AiController CreateAiController( AiClass aiClass)
		{
			return aiMap[aiClass].CreateInstance();
		}
	}
}