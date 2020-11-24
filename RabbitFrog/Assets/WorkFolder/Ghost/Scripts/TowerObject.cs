using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ghost
{
	public class TowerObject : UnitObjectBase
	{
		public UnitTowerInfo unitTowerInfo;
		
		public void SetUnitInfo(UnitTowerInfo info)
		{
			unitTowerInfo = info;
		}
		
		public override UnitInfo GetUnitInfo()
		{
			return unitTowerInfo;
		}
	}
}