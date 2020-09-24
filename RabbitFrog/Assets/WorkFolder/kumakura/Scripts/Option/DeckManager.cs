using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public DeckObject[] getDeckObjects = new DeckObject[8];
    public static DeckObject[] deckObjects = new DeckObject[8];

    void Start()
    {
        GetDeckObject();
        for (int i = 0; i < deckObjects.Length; i++)
        {
            deckObjects[i] = getDeckObjects[i];
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetDeckObject();
        }
    }

    public static void SetDeckObject()
    {
        for (int i = 0; i < deckObjects.Length; i++)
        {
            if (deckObjects[i].cardPoolObject == null) { return; }
            DeckData.deckObjects[i] = deckObjects[i];
            Debug.Log(DeckData.deckObjects[i]);
            Debug.Log(DeckData.deckObjects[i].cardPoolObject.character.characterName);
            Debug.Log(deckObjects[i].iconImage.sprite);
        }
    }

    public static void GetDeckObject()
    {
        for (int i = 0; i < deckObjects.Length; i++)
        {
            if (DeckData.deckObjects[i] == null) { return; }
            Debug.Log("mnodihbneipthnbpiesnthoi");
            deckObjects[i] = DeckData.deckObjects[i];
            deckObjects[i].iconImage.sprite = DeckData.deckObjects[i].iconImage.sprite;
            Debug.Log(deckObjects[i].cardPoolObject.character.characterName);
        }
    }
}
