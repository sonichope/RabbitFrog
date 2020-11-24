using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ghost
{
	public class DefaultActionController : ActionController
	{
		public override void InitActionState()
		{
			states.Add(0, new WaitActionState( this));
			states.Add(1, new SummonActionState( this));
			states.Add(2, new AttackActionState( this));
			states.Add(3, new MoveActionState( this));
			states.Add(4, new DeathActionState(this));

			ChangeState( 0, UnitControlInfo.NullParam);
		}

		public override void ProcessDamage(UnitGameObject unitGameObject)
		{
			UnitInfo info = unitObject.GetUnitInfo();
			info.hp -= unitGameObject.unitObject.GetUnitInfo().power;
			if (info.hp <= 0)
			{
				ChangeState(4, UnitControlInfo.NullParam);
				return;
			}
			//ChangeState( 0, UnitControlInfo.NullParam);
		}

		public class WaitActionState : ActionState
		{
			
			public WaitActionState(ActionController actionController) : base(actionController)
			{
			}
			public override void Start(UnitControlInfo unitControlInfo)
			{
				//	アニメーションの再生など
			}

			public override void Control(UnitControlInfo unitControlInfo)
			{
				switch (unitControlInfo.controlId)
				{
					case UnitControl.CONTROL_MOVE:
						controller.ChangeState( 3, unitControlInfo);
						return;
					case UnitControl.CONTROL_ATTACK:
						controller.ChangeState( 2, unitControlInfo);
						return;
					case UnitControl.CONTROL_SUMMON:
						controller.ChangeState( 1, unitControlInfo);
						return;
				}
			}

			public override void Update()
			{
				//	移動などの処理
			}

			public override void Exit()
			{
				
			}
		}
		
		public class SummonActionState : ActionState
		{
			
			public SummonActionState(ActionController actionController) : base(actionController)
			{
			}
			public override void Start( UnitControlInfo unitControlInfo)
			{
				//	アニメーションの再生など
				UnitSerializeData deckUnit = GameSetting.GetUnitData(unitControlInfo.param);
				UnitInfo unitInfo = new UnitInfo(deckUnit.unitData);
				UnitObjectBase unitObjectBase = controller.unitObject;
				UnitGameObject unitGameObject = unitObjectBase.stage.CreateUnit(unitInfo, unitObjectBase.objGroup);
				Transform unitTransform = unitObjectBase.unitGameObject.transform;
				if (unitObjectBase.objGroup == UnitGroup.GROUP_PLAYER)
				{
					unitGameObject.transform.position = unitTransform.position + unitTransform.right * -1;
				}else if (unitObjectBase.objGroup == UnitGroup.GROUP_ENEMY)
				{
					unitGameObject.transform.position = unitTransform.position + unitTransform.right;
				}
			}

			public override void Control(UnitControlInfo unitControlInfo)
			{
				switch (unitControlInfo.controlId)
				{
					case UnitControl.CONTROL_MOVE:
						controller.ChangeState( 3, unitControlInfo);
						return;
					case UnitControl.CONTROL_ATTACK:
						controller.ChangeState( 2, unitControlInfo);
						return;
					case UnitControl.CONTROL_SUMMON:
						controller.ChangeState( 1, unitControlInfo);
						return;
				}
			}

			public override void Update()
			{
				//	移動などの処理
			}

			public override void Exit()
			{
				
			}
		}

		public class AttackActionState : ActionState
		{
			private UnitGameObject target;
			private float attackTimer = 0;
			public AttackActionState(ActionController actionController) : base(actionController)
			{
			}

			public override void Start(UnitControlInfo unitControlInfo)
			{
				target = controller.unitObject.stage.GetUnitObject(unitControlInfo.param);
				if( target == null) return;
				target.GiveDamage( controller.unitObject.unitGameObject.objectId);
			}

			public override void Control(UnitControlInfo unitControlInfo)
			{
				switch (unitControlInfo.controlId)
				{
					case UnitControl.CONTROL_MOVE:
						controller.ChangeState( 3, unitControlInfo);
						return;
					case UnitControl.CONTROL_ATTACK:
						controller.ChangeState( 2, unitControlInfo);
						return;
					case UnitControl.CONTROL_SUMMON:
						controller.ChangeState( 1, unitControlInfo);
						return;
				}
			}

			public override void Update()
			{
				if (target == null)
				{
					controller.ChangeState( 0, UnitControlInfo.NullParam);
					return;
				}
				float interval = controller.unitObject.GetUnitInfo().attackInterval;
				attackTimer += Time.deltaTime;
				if (attackTimer >= interval)
				{
					attackTimer -= interval;
					UnitControlInfo info = new UnitControlInfo();
					info.controlId = UnitControl.CONTROL_ATTACK;
					info.param = target.objectId;
					controller.ChangeState( 2, info);
				}
			}

			public override void Exit()
			{
				
			}
		}
		
		public class MoveActionState : ActionState
		{
			private Transform targetTransform;
			private Transform unitTransform;
			
			public MoveActionState(ActionController actionController) : base(actionController)
			{
			}

			public override void Start(UnitControlInfo unitControlInfo)
			{
				unitTransform = controller.unitObject.unitGameObject.transform;
				UnitGameObject target = controller.unitObject.stage.GetUnitObject(unitControlInfo.param);
				targetTransform = target.transform;
			}

			public override void Control(UnitControlInfo unitControlInfo)
			{
				switch (unitControlInfo.controlId)
				{
					case UnitControl.CONTROL_MOVE:
						controller.ChangeState( 3, unitControlInfo);
						return;
					case UnitControl.CONTROL_ATTACK:
						controller.ChangeState( 2, unitControlInfo);
						return;
					case UnitControl.CONTROL_SUMMON:
						controller.ChangeState( 1, unitControlInfo);
						return;
				}
			}

			public override void Update()
			{
				float moveSpeed = controller.unitObject.GetUnitInfo().moveSpeed;
				if (targetTransform == null)
				{
					controller.ChangeState( 0, UnitControlInfo.NullParam);
					return;
				}
				Vector3 targetPos = targetTransform.position;
				Vector3 unitPos = unitTransform.position;
				Vector3 direction = (targetPos - unitPos).normalized;
				Vector3 movePos = unitPos + direction * (moveSpeed * Time.deltaTime);
				unitTransform.position = movePos;
			}

			public override void Exit()
			{
				
			}
		}
		
		public class DeathActionState : ActionState
		{
			private static float time = 1;
			private float timer = 0;
			public DeathActionState(ActionController actionController) : base(actionController)
			{
			}

			public override void Start(UnitControlInfo unitControlInfo)
			{
				//	死亡タイムラインの再生
			}

			public override void Control(UnitControlInfo unitControlInfo)
			{
				
			}

			public override void Update()
			{
				timer += Time.deltaTime;
				if( timer < time) return;
				controller.unitObject.alive = false;
			}

			public override void Exit()
			{
				
			}
		}
	}
}