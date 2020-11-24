
namespace Ghost
{
	public enum AiClass : uint
	{
		CLASS_DEFAULT = 0,
		CLASS_ENEMY_TOWER = 1,
		CLASS_PLAYER_TOWER = 2
	}

	public enum UnitGroup : int
	{
		GROUP_PLAYER = 0,
		GROUP_ENEMY = 1
	}

	public enum UnitControl : int
	{
		CONTROL_NONE = 0,
		CONTROL_SUMMON = 1,
		CONTROL_ATTACK = 2,
		CONTROL_MOVE = 3,
		CONTROL_WAIT = 4
	}
}