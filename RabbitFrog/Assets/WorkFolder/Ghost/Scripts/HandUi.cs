using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace Ghost
{
	public class HandUi : MonoBehaviour
	{
		[SerializeField] private Text costText = null;
		[SerializeField] private Image unitIcon = null;

		private UnitSerializeData unitData;
		private AsyncOperationHandle iconHandle;

		public void SetUnitData(UnitSerializeData data)
		{
			if (iconHandle.IsValid())
			{
				Addressables.Release( iconHandle);
			}
			costText.text = data.unitData.cost.ToString();
			AsyncOperationHandle<Sprite> spriteHandle = Addressables.LoadAssetAsync<Sprite>(data.unitData.imageName);
			spriteHandle.Completed += handle => { unitIcon.sprite = handle.Result; };
			iconHandle = spriteHandle;
		}
	}
}