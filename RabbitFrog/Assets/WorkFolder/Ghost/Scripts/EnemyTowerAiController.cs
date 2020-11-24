using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ghost
{
	public class EnemyTowerAiController : AiController
	{
		private HandManager handManager;
		
		public override AiController CreateInstance()
		{
			return new EnemyTowerAiController();
		}

		public override UnitControlInfo AiUpdate()
		{
			UnitGameObject[] unitGameObjects = unitGameObject.unitObject.stage.GetUnitGameObjects(UnitGroup.GROUP_PLAYER);
			if (unitGameObjects == null || unitGameObjects.Length == 0)
			{
				UnitControlInfo unitControlInfo = new UnitControlInfo();
				unitControlInfo.controlId = UnitControl.CONTROL_WAIT;
				return unitControlInfo;
			}
			
			UnitInfo info = unitGameObject.unitObject.GetUnitInfo();
			float val = info.GetChargeVal();
			UnitSerializeData data = info.GetUnitData();
			val += data.unitData.rechargeSpeed * Time.deltaTime;
			int[] deck = info.GetDeck();
			int idx = Random.Range(0, deck.Length);
			UnitSerializeData deckUnit = GameSetting.GetUnitData(deck[idx]);
			if (deckUnit.unitData.cost <= val)
			{
				UnitControlInfo controlInfo = new UnitControlInfo();
				controlInfo.controlId = UnitControl.CONTROL_SUMMON;
				controlInfo.param = deck[idx];
				info.SetChargeVal( val - deckUnit.unitData.cost);
				return controlInfo;
			}
			info.SetChargeVal( val);
			val = info.GetChargeVal();
			return new UnitControlInfo();
		}
	}
}