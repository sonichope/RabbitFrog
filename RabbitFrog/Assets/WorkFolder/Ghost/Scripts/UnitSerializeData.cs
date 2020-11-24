using UnityEngine;

namespace Ghost
{
	[CreateAssetMenu(menuName = "Data/UnitData", fileName = "Unit_id")]
	public class UnitSerializeData : ScriptableObject
	{
		public UnitData unitData;

		/// <summary>
		/// これは使うか分からない
		/// データを外部で作るとしたらこれを使ってスクリプタブルオブジェクトを作ることが出来る
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public static UnitSerializeData CreateUnitSerializeData(ref UnitData data)
		{ 
			UnitSerializeData serializeData = CreateInstance<UnitSerializeData>();
			serializeData.unitData.Set( ref data);
			return serializeData;
		}
	}
}
