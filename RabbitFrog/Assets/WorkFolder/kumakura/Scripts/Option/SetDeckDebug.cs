using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDeckDebug : MonoBehaviour
{
    [SerializeField] private Image[] deckImage = new Image[8];
    [SerializeField] private DeckObject[] deckObjects = new DeckObject[8];
    [SerializeField,Header("自動セットしたいカード")] private CardPoolObject[] cardPoolObjects = new CardPoolObject[8];


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                for(int i = 0; i < 8; i++)
                {
                    deckObjects[i].cardPoolObject = cardPoolObjects[i];
                    deckImage[i].sprite = deckObjects[i].cardPoolObject.character.image;
                }
            }
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                if (deckObjects[0].cardPoolObject == null) { return; }
                GameSceneManager.LoadBattleFirstScene();
            }
        }
    }
}
