using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Ghost
{
	public static class GameSetting
	{
		private static Dictionary<int, UnitSerializeData> unitSerializeDataMap = new Dictionary<int, UnitSerializeData>();
		private static Dictionary<int, DeckSerializeData> deckSerializeDataMap = new Dictionary<int, DeckSerializeData>();
		private static Dictionary<int, StageSerializeData> stageSerializeDataMap = new Dictionary<int, StageSerializeData>();
		private static AsyncOperationHandle unitSerializeHandle;
		private static AsyncOperationHandle deckSerializeHandle;
		private static AsyncOperationHandle stageSerializeHandle;

		public static UnitSerializeData GetUnitData(int id)
		{
			return unitSerializeDataMap[id];
		}
		
		public static DeckSerializeData GetDeckData(int id)
		{
			return deckSerializeDataMap[id];
		}

		public static StageSerializeData GetStageData( int id)
		{
			return stageSerializeDataMap[id];
		}

		public static void RegisterUnitSerializeDataAsync()
		{
			if( unitSerializeHandle.IsValid()) return;
			unitSerializeHandle = Addressables.LoadAssetsAsync("Unit",
				(UnitSerializeData data) => { Debug.Log( "[Register Unit Data] : " + data); unitSerializeDataMap.Add(data.unitData.id, data); });
		}
		
		public static void RegisterDeckSerializeDataAsync()
		{
			if( deckSerializeHandle.IsValid()) return;
			;
			deckSerializeHandle = Addressables.LoadAssetsAsync("Deck",
				(DeckSerializeData data) => { Debug.Log( "[Register Deck Data] : " + data); deckSerializeDataMap.Add(data.deckData.id, data); });
		}

		public static void RegisterStageSerializeDataAsync()
		{
			if (stageSerializeHandle.IsValid()) return;
			stageSerializeHandle = Addressables.LoadAssetsAsync( "Stage", 
				(StageSerializeData data) => { Debug.Log( "[Register Stage Data] : " + data); stageSerializeDataMap.Add(data.stageData.id, data); });
		}

		public static bool FinishRegisterData()
		{
			return unitSerializeHandle.IsDone;
		}
		
		public static bool FinishDeckRegisterData()
		{
			return deckSerializeHandle.IsDone;
		}

		public static bool FinishStageRegisterData()
		{
			return stageSerializeHandle.IsDone;
		}
	}
}