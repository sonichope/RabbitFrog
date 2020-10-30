using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoDeckSet : MonoBehaviour
{
    [SerializeField] private Image[] deckImage = new Image[8];
    [SerializeField] private DeckObject[] deckObjects = new DeckObject[8];
    [SerializeField, Header("自動セットしたいカード")] private CardPoolObject[] cardPoolObjects = new CardPoolObject[8];

    public void AutoSetDeck()
    {
        for(int i = 0; i < deckObjects.Length; i++)
        {
            deckObjects[i].cardPoolObject = cardPoolObjects[i];
            deckImage[i].sprite = deckObjects[i].cardPoolObject.character.image;
            //2020/10/25 bug修正　イゴンヒ
            deckObjects[i].GetComponent<DeckObject>().nowSprite = deckImage[i].sprite;
        }
    }
}
