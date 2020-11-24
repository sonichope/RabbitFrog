using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ghost
{
	public abstract class AiController
	{
		public UnitGameObject unitGameObject;

		public virtual void Setup(UnitGameObject obj)
		{
			unitGameObject = obj;
		}
		public abstract AiController CreateInstance();
		public abstract UnitControlInfo AiUpdate();
	}
}