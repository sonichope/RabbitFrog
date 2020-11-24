using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ghost
{
	public class UnitObjectBase
	{
		public int id;
		public UnitGameObject unitGameObject;
		public BattleStage stage;
		public AiController aiController;
		public ActionController actionController;
		public UnitGroup objGroup;
		public bool alive = true;
		public UnitControlInfo lastInfo;
		
		public virtual void Update()
		{
			AiController ai = aiController;
			if( ai == null) return;
			UnitControlInfo nextControl = ai.AiUpdate();
			if (nextControl.controlId != UnitControl.CONTROL_NONE)
			{
				lastInfo = nextControl;
				actionController?.ControlUpdate( nextControl);
			}
			actionController?.ActionUpdate();
			
			if(alive) return;
			stage.RemoveUnitObject( unitGameObject.objectId);
		}

		public virtual DeckData GetDeck()
		{
			return DeckData.NullData();
		}

		public void SetGroup( UnitGroup unitGroup)
		{
			objGroup = unitGroup;
		}

		public void SetActionController(ActionController controller)
		{
			actionController = controller;
			actionController.unitObject = this;
			actionController.InitActionState();
		}

		public virtual UnitInfo GetUnitInfo()
		{
			return null;
		}

		public void GiveDamage(int objectId)
		{
			if( GetUnitInfo() == null) return;
			UnitGameObject attackerObject = stage.GetUnitObject(objectId);
			actionController?.ProcessDamage( attackerObject);
		}
	}
}