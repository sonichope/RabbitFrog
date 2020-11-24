using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ghost
{
	public abstract class ActionState
	{
		protected ActionController controller;

		public ActionState(ActionController actionController)
		{
			controller = actionController;
		}
		public abstract void Start(UnitControlInfo unitControlInfo);
		public abstract void Control(UnitControlInfo unitControlInfo);
		public abstract void Update();
		public abstract void Exit();
	}
	
	public abstract class ActionController
	{
		[NonSerialized] public UnitObjectBase unitObject;
		[NonSerialized] public Dictionary<int , ActionState> states = new Dictionary<int, ActionState>();
		[NonSerialized] public ActionState state;
		
		/// <summary>
		/// ステートの登録処理
		/// </summary>
		public abstract void InitActionState();

		public void ChangeState(int stateId, UnitControlInfo unitControlInfo)
		{
			if ( !states.ContainsKey(stateId)) return;
			
			state?.Exit();
			Debug.Log( unitObject.unitGameObject.objectId +  " : " + "last : " + state + " new : " + states[stateId]);
			state = states[stateId];
			state.Start( unitControlInfo);
		}

		public void ControlUpdate( UnitControlInfo controlId)
		{
			state.Control( controlId);
		}

		public void ActionUpdate()
		{
			state?.Update();
		}

		public virtual void ProcessDamage( UnitGameObject unitGameObject)
		{
			
		}
	}
}
