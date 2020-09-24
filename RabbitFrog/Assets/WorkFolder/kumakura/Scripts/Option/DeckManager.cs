using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public DeckObject[] getDeckObjects = new DeckObject[8];
    public static DeckObject[] deckObjects = new DeckObject[8];

    void Start()
    {
        //for (int i = 0; i < deckObjects.Length; i++)
        //{
        //    DeckData.deckObjects[i] = getDeckObjects[i];
        //}
        //GetDeckObject();
        //if (DeckData.deckSetFlag)
        //{
        //    Debug.Log("Dataに入れてみるね");
        //    for (int i = 0; i < deckObjects.Length; i++)
        //    {
        //        DeckData.deckObjects[i] = getDeckObjects[i];
        //    }
        //    DeckData.deckSetFlag = false;
        //}

        for (int i = 0; i < deckObjects.Length; i++)
        {
            DeckData.Instance.deckObjects[i] = getDeckObjects[i];
            deckObjects[i] = getDeckObjects[i];
            //deckObjects[i] = DeckData.deckObjects[i];
        }

        //if (DeckData.Instance.deckSetFlag)
        //{
        //    for (int i = 0; i < deckObjects.Length; i++)
        //    {
        //        DeckData.Instance.deckObjects[i] = getDeckObjects[i];
        //        deckObjects[i] = getDeckObjects[i];
        //        //deckObjects[i] = DeckData.deckObjects[i];
        //    }
        //    DeckData.Instance.deckSetFlag = false;
        //}
        //else
        //{
        //    for (int i = 0; i < deckObjects.Length; i++)
        //    {
        //        deckObjects[i] = DeckData.Instance.deckObjects[i];
        //        Debug.Log("参照　" + deckObjects[i]);
        //    }
        //    Debug.Log("参照完了");
        //}
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Setしてみるね");
            SetDeckObject();
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            for (int i = 0; i < deckObjects.Length; i++)
            {
                Debug.Log(deckObjects[i].cardPoolObject);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < deckObjects.Length; i++)
            {
                Debug.Log(DeckData.Instance.deckObjects[i]);
            }
        }
    }

    public static void SetDeckObject()
    {
        for (int i = 0; i < deckObjects.Length; i++)
        {
            if (deckObjects[i] == null) { return; }
            DeckData.Instance.deckObjects[i] = deckObjects[i];
            Debug.Log(DeckData.Instance.deckObjects[i]);
            Debug.Log(DeckData.Instance.deckObjects[i].cardPoolObject.character.characterName);
            Debug.Log(deckObjects[i].iconImage.sprite);
        }
        Debug.Log("Set出来たよ");
    }

    public static void GetDeckObject()
    {
        for (int i = 0; i < deckObjects.Length; i++)
        {
            if (DeckData.Instance.deckObjects[i] == null) { Debug.Log("Get出来ませんでした"); return; }
            deckObjects[i] = DeckData.Instance.deckObjects[i];
            deckObjects[i].iconImage.sprite = DeckData.Instance.deckObjects[i].iconImage.sprite;
            Debug.Log(deckObjects[i].cardPoolObject.character.characterName);
        }
        Debug.Log("Get出来たよ");
    }
}
