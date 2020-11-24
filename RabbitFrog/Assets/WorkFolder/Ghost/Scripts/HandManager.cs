using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Ghost
{
	public class HandManager : MonoBehaviour
	{
		private int[] deck;
		private int[] nextDeck;
		public int nextDeckIdx;
		private HandManagerUi handManagerUi;

		public void SetUpDeck(int[] setDeck)
		{
			deck = new int[setDeck.Length];
			nextDeck = new int[setDeck.Length];
			for (int i = 0; i < setDeck.Length; i++)
			{
				deck[i] = setDeck[i];
			}
		}

		public void InitDeckIdx()
		{
			DeckShuffle( deck);
			if(!handManagerUi) return;
			handManagerUi.UpdateHandUi( deck);
		}
		
		private void DeckShuffle( int[] shuffleDeck)
		{
			int shuffleVal = 0;
			while (shuffleVal <= 30)
			{
				int randomVal1 = Random.Range(0, shuffleDeck.Length);
				int randomVal2 = Random.Range(0, shuffleDeck.Length);
            
				var temp = shuffleDeck[randomVal1];
				shuffleDeck[randomVal1] = shuffleDeck[randomVal2];
				shuffleDeck[randomVal2] = temp;
				shuffleVal++;
			}
		}
		
	}
}

