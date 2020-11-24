using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ghost
{
	public class DefaultAiController : AiController
	{
		public override AiController CreateInstance()
		{
			return new DefaultAiController();
		}

		public override UnitControlInfo AiUpdate()
		{
			//	近くの敵を探して移動又は攻撃を行う
			UnitGameObject[] units = null;
			if (unitGameObject.unitObject.objGroup == UnitGroup.GROUP_PLAYER)
			{
				units = unitGameObject.unitObject.stage.GetUnitGameObjects(UnitGroup.GROUP_ENEMY);
			}else if (unitGameObject.unitObject.objGroup == UnitGroup.GROUP_ENEMY)
			{
				units = unitGameObject.unitObject.stage.GetUnitGameObjects(UnitGroup.GROUP_PLAYER);
			}

			float minDistance = float.MaxValue;
			Vector3 unitPos = unitGameObject.transform.position;
			UnitGameObject target = null;
			if (units != null)
			{
				for (int i = 0; i < units.Length; i++)
				{
					UnitGameObject unit = units[i];
					Vector3 pos = unit.transform.position;
					float distance = Vector3.Distance(unitPos, pos);
					if( distance >= minDistance) continue;
					minDistance = distance;
					target = unit;
				}
			}

			if (target != null)
			{
				UnitControlInfo unitControlInfo = new UnitControlInfo();
				unitControlInfo.controlId = UnitControl.CONTROL_MOVE;
				unitControlInfo.param = target.objectId;
				if (minDistance < unitGameObject.unitObject.GetUnitInfo().attackRange)
				{
					unitControlInfo.controlId = UnitControl.CONTROL_ATTACK;
				}
				return unitControlInfo;
			}
			return UnitControlInfo.NullParam;
		}
	}
}

