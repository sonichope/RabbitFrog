using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ghost
{
	[CreateAssetMenu(menuName = "Data/DeckData", fileName = "Deck_id")]
	public class DeckSerializeData : ScriptableObject
	{
		public DeckData deckData;
	}
}