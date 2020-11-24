using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Ghost
{
	[System.Serializable]
	public struct SaveData
	{
		public Dictionary<int, bool> cleaStageMap;
		public int lastStageId;
		public int leaderUnitId;
		public int[] selectUnits;

		public void Init()
		{
			cleaStageMap = new Dictionary<int, bool>();
			lastStageId = 0;
			leaderUnitId = 0;
			selectUnits = new int[8] {0, 0, 0, 0, 0, 0, 0, 0};
		}

		public UnitData GetUnitData()
		{
			UnitSerializeData data = GameSetting.GetUnitData(leaderUnitId);
			return data.unitData;
		}

		public bool IsClearStage(int id)
		{
			return cleaStageMap[id];
		}

		public bool IsValue()
		{
			return cleaStageMap != null;
		}
	}

	[System.Serializable]
	public struct StageData
	{
		public int id;
		
		//	固定で出現する敵ユニットのデータ
		public uint uniqueStageUnitDataNum;
		public StagePlayerData stagePlayerData;
		public UniqueStageUnitData[] uniqueStageUnitData;
	}

	[System.Serializable]
	public struct StagePlayerData
	{
		public float x;
		public float y;
	}

	[System.Serializable]
	public struct UniqueStageUnitData
	{
		public int unitId;
		public float x;
		public float y;
		public int deckId;

		public UnitData GetUnitData()
		{
			return GameSetting.GetUnitData(unitId).unitData;
		}

		public DeckData GetDeckData()
		{
			return GameSetting.GetDeckData(deckId).deckData;
		}
	}

	[System.Serializable]
	public struct UnitData
	{
		public int id;
		public string name;
		public string imageName;
		public AiClass aiClass;
		public int hp;
		public int power;
		public float moveSpeed;
		public int summonVol;
		public int cost;
		public float attackRange;
		public float attackInterval;
		public float rechargeSpeed;
		

		public void Set(ref UnitData data)
		{
			id = data.id;
			name = data.name;
			imageName = data.imageName;
			aiClass = data.aiClass;
			hp = data.hp;
			power = data.power;
			moveSpeed = data.moveSpeed;
			summonVol = data.summonVol;
			cost = data.cost;
			attackRange = data.attackRange;
			attackInterval = data.attackInterval;
			rechargeSpeed = data.rechargeSpeed;
		}
	}

	[System.Serializable]
	public struct DeckData
	{
		public int id;
		public int[] deckId;

		public DeckData(DeckData data)
		{
			id = 0;
			deckId = new int[data.deckId.Length];
			for (int i = 0; i < deckId.Length; i++)
			{
				deckId[i] = data.deckId[i];
			}
		}

		public int[] ToArray()
		{
			int[] val = new int[deckId.Length];
			for (int i = 0; i < deckId.Length; i++)
			{
				val[i] = deckId[i];
			}

			return val;
		}

		public static DeckData NullData()
		{
			DeckData deck = new DeckData();
			deck.id = -1;
			return deck;
		}
	}

	public class UnitInfo
	{
		public int unitDataId;
		public int hp;
		public int power;
		public float moveSpeed;
		public int summonVol;
		public float attackRange;
		public float attackInterval;

		public UnitInfo(UnitData data)
		{
			unitDataId = data.id;
			hp = data.hp;
			power = data.power;
			moveSpeed = data.moveSpeed;
			summonVol = data.summonVol;
			attackRange = data.attackRange;
			attackInterval = data.attackInterval;
		}

		public UnitSerializeData GetUnitData()
		{
			return GameSetting.GetUnitData(unitDataId);
		}

		public virtual float GetChargeVal() { return 0; }
		public virtual void SetChargeVal( float val) { }

		public virtual int[] GetDeck()
		{
			return null;
		}
	}

	public class UnitTowerInfo : UnitInfo
	{
		public int[] deck;
		public float chargeVal;

		public UnitTowerInfo(UnitData data, DeckData deckData) : base(data)
		{
			deck = deckData.ToArray();
			chargeVal = 0;
		}
		
		public UnitTowerInfo(UnitData data, int[] deckData) : base(data)
		{
			deck = new int[deckData.Length];
			for (int i = 0; i < deckData.Length; i++)
			{
				deck[i] = deckData[i];
			}
		}

		public override float GetChargeVal()
		{
			return chargeVal;
		}

		public override void SetChargeVal( float val)
		{
			chargeVal = val;
		}

		public override int[] GetDeck()
		{
			return deck;
		}
	}

	public struct UnitControlInfo
	{
		public UnitControl controlId;
		public int param;

		public static UnitControlInfo NullParam
		{
			get
			{
				UnitControlInfo info = new UnitControlInfo();
				info.controlId = UnitControl.CONTROL_NONE;
				info.param = 0;
				return info;
			}
		}
	}
}
