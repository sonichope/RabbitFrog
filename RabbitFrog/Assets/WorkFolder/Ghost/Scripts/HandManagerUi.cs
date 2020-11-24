using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ghost
{
	public class HandManagerUi : MonoBehaviour
	{
		[SerializeField] private Transform handUiParent = null;
		private List<HandUi> handUiList = new List<HandUi>();
		private HandManager handManager;

		private void Start()
		{
			handUiList.Clear();
			for (int i = 0, max = handUiParent.childCount; i < max; i++)
			{
				Transform child = handUiParent.GetChild(i);
				HandUi handUi = child.GetComponent<HandUi>();
				if( !handUi) continue;
				handUiList.Add( handUi);
			}
		}

		public void UpdateHandUi( int[] deck)
		{
			for (int i = 0, max = handUiList.Count; i < max; i++)
			{
				if (i >= deck.Length)
				{
					handUiList[i].SetUnitData( null);					
				}
				else
				{
					handUiList[i].SetUnitData( GameSetting.GetUnitData(deck[i]));
				}
			}
		}
	}   
}