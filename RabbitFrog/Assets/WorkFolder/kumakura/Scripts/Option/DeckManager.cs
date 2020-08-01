using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public DeckObject[] getDeckObjects = new DeckObject[8];
    public static DeckObject[] deckObjects = new DeckObject[8];

    void Start()
    {
        for (int i = 0; i < deckObjects.Length; i++)
        {
            deckObjects[i] = getDeckObjects[i];
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < deckObjects.Length; i++)
            {
                if (deckObjects[i].cardPoolObject == null) { return; }
                Debug.Log(deckObjects[i].cardPoolObject.myCardType);
            }
        }
    }
}
