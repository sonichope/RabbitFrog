using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ghost
{
	public class UnitObject : UnitObjectBase
	{
		public UnitInfo unitInfo;

		public void SetUnitInfo(UnitInfo info)
		{
			unitInfo = info;
		}

		public void Update()
		{
			
		}

		public virtual int[] GetDeck()
		{
			return null;
		}
		
		public override UnitInfo GetUnitInfo()
		{
			return unitInfo;
		}
	}
}