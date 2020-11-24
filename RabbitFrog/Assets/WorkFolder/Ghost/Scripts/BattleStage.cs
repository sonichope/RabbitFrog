using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Ghost
{
	public class BattleStage : MonoBehaviour
	{
		[SerializeField] private UnitGameObject unitGamePrefab = null;
		[NonSerialized] public Dictionary<int, UnitGameObject> unitObjects = new Dictionary<int, UnitGameObject>();
		private int lastObjectId;
		private Queue<int> idQueue = new Queue<int>();
		private bool finishStageSetup = false;

		private void Awake()
		{
			lastObjectId = 0;
		}

		private void Start()
		{
			GameSetting.RegisterUnitSerializeDataAsync();
			GameSetting.RegisterDeckSerializeDataAsync();
			GameSetting.RegisterStageSerializeDataAsync();
			AiFactory.RegisterAiController();
		}

		public void Update()
		{
			if (GameSetting.FinishDeckRegisterData() && GameSetting.FinishRegisterData() && GameSetting.FinishStageRegisterData())
			{
				if (!finishStageSetup)
				{
					finishStageSetup = true;
					StageSetUp();
				}
			}
		}

		public void StageSetUp()
		{
			SaveData saveData = UserDataControl.SaveData;
			StageSerializeData data = GameSetting.GetStageData(saveData.lastStageId);
			StageData stageData = data.stageData;
			// プレイヤーのタワー作成
			StagePlayerData playerData = stageData.stagePlayerData;
			UnitTowerInfo towerInfo = new UnitTowerInfo( saveData.GetUnitData(), saveData.selectUnits);
			UnitGameObject playerGameObject = CreatePlayerTower(towerInfo, UnitGroup.GROUP_PLAYER);
			Vector3 playerPos = new Vector3( playerData.x, playerData.y, 0);
			playerGameObject.transform.SetPositionAndRotation( playerPos, Quaternion.identity);

			// 敵タワーの作成
			for (int i = 0; i < stageData.uniqueStageUnitData.Length; i++)
			{
				UniqueStageUnitData uniqueUnitData = stageData.uniqueStageUnitData[i];
				towerInfo = new UnitTowerInfo( uniqueUnitData.GetUnitData(), uniqueUnitData.GetDeckData());
				UnitGameObject unitGameObject = CreateEnemyTower(towerInfo, UnitGroup.GROUP_ENEMY);
				Vector3 pos = new Vector3( uniqueUnitData.x, uniqueUnitData.y, 0);
				unitGameObject.transform.SetPositionAndRotation( pos, Quaternion.identity);
			}
		}

		public UnitGameObject CreateUnit( UnitInfo unitInfo, UnitGroup group)
		{
			UnitGameObject unitGameObject = Instantiate(unitGamePrefab);
			UnitObject unitObject = new UnitObject();
			unitObject.stage = this;
			unitObject.objGroup = group;
			unitObject.SetUnitInfo( unitInfo);
			unitGameObject.objectId = GetObjectId();
			unitGameObject.SetUnitBase(unitObject);
			unitGameObject.SetGroup( group);
			unitObject.SetActionController( new DefaultActionController());
			UnitSerializeData unitSerializeData = GameSetting.GetUnitData(unitInfo.unitDataId);
			unitGameObject.unitObject.aiController = AiFactory.CreateAiController(unitSerializeData.unitData.aiClass);
			unitGameObject.unitObject.aiController.Setup( unitGameObject);
			unitObjects.Add(unitGameObject.objectId, unitGameObject);
			return unitGameObject;
		}

		public UnitGameObject CreatePlayerTower(UnitTowerInfo unitInfo, UnitGroup group)
		{
			UnitGameObject unitGameObject = Instantiate(unitGamePrefab);
			TowerObject towerObject = new TowerObject();
			towerObject.stage = this;
			towerObject.objGroup = group;
			towerObject.SetUnitInfo( unitInfo);
			unitGameObject.objectId = GetObjectId();
			unitGameObject.SetUnitBase( towerObject);
			unitGameObject.SetGroup( group);
			towerObject.SetActionController( new DefaultActionController());
			unitGameObject.unitObject.aiController = AiFactory.CreateAiController(AiClass.CLASS_PLAYER_TOWER);
			unitGameObject.unitObject.aiController.Setup( unitGameObject);
			unitObjects.Add(unitGameObject.objectId, unitGameObject);
			return unitGameObject;
		}

		public UnitGameObject CreateEnemyTower(UnitTowerInfo unitInfo, UnitGroup group)
		{
			UnitGameObject unitGameObject = Instantiate(unitGamePrefab);
			TowerObject towerObject = new TowerObject();
			towerObject.stage = this;
			towerObject.objGroup = group;
			towerObject.SetUnitInfo( unitInfo);
			unitGameObject.objectId = GetObjectId();
			unitGameObject.SetUnitBase(towerObject);
			unitGameObject.SetGroup( group);
			towerObject.SetActionController(new DefaultActionController()); // 変更出来るようにする
			unitGameObject.unitObject.aiController = AiFactory.CreateAiController(AiClass.CLASS_ENEMY_TOWER);
			unitGameObject.unitObject.aiController.Setup( unitGameObject);
			unitObjects.Add(unitGameObject.objectId, unitGameObject);
			return unitGameObject;
		}

		public UnitGameObject[] GetUnitGameObjects(UnitGroup searchGroup)
		{
			List<UnitGameObject> unitGameObjects = new List<UnitGameObject>();
			foreach (UnitGameObject unit in unitObjects.Values)
			{
				if( unit.unitObject.objGroup != searchGroup) continue;
				unitGameObjects.Add( unit);
			}
			return unitGameObjects.ToArray();
		}

		public UnitGameObject GetUnitObject(int id)
		{
			if (!unitObjects.ContainsKey(id)) return null;
			return unitObjects[id];
		}

		private int GetObjectId()
		{
			if (idQueue.Count > 0) return idQueue.Dequeue();
			int id = lastObjectId;
			lastObjectId++;
			return id;
		}

		public void RemoveUnitObject(int objectId)
		{
			Destroy(unitObjects[objectId].gameObject);
			unitObjects.Remove(objectId);
			idQueue.Enqueue( objectId);
			
		}
	}
}