using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Ghost
{
	public class UnitGameObject : MonoBehaviour
	{
		public int objectId;
		public UnitObjectBase unitObject = null;
		private AsyncOperationHandle handle;
		private void Update()
		{
			unitObject?.Update();
		}

		public void SetUnitBase(UnitObjectBase unitObjectBase)
		{
			unitObject = unitObjectBase;
			unitObject.unitGameObject = this;
			AsyncOperationHandle< Sprite> spriteHandle = Addressables.LoadAssetAsync<Sprite>(unitObject.GetUnitInfo().GetUnitData().unitData.imageName);
			spriteHandle.Completed += operationHandle =>
			{
				SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
				spriteRenderer.sprite = operationHandle.Result;
			};
			handle = spriteHandle;
		}

		public void SetGroup(UnitGroup unitGroup)
		{
			if( unitObject == null) return;
			unitObject.SetGroup( unitGroup);
			if (unitGroup == UnitGroup.GROUP_ENEMY)
			{
				Vector3 scale = Vector3.one;
				scale.x *= -1;
				transform.localScale = scale;
			}else if (unitGroup == UnitGroup.GROUP_PLAYER)
			{
				transform.localScale = Vector3.one;
			}
		}

		public void GiveDamage(int objectId)
		{
			unitObject?.GiveDamage( objectId);
		}
	}
}