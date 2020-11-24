using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ghost
{
	[CreateAssetMenu(menuName = "Data/StageData", fileName = "Stage_id")]
	public class StageSerializeData : ScriptableObject
	{
		public StageData stageData;
	}
}