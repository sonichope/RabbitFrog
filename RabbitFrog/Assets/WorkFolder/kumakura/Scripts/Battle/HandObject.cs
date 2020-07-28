using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < DeckManager.deckObjects.Length; i++)
            {
                if (DeckManager.deckObjects[i] == null) continue;
                Debug.Log(DeckManager.deckObjects[i].cardPoolObject.myCardType);
            }
        }
    }

    public void OnBeginDrag(PointerEventData pointerEventData)
    {

    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        
    }

    public void OnEndDrag(PointerEventData pointerEventData)
    {

    }

    /// <summary>
    /// キャラクターの召喚
    /// </summary>
    public void CharacterSummon()
    {

    }

    /// <summary>
    /// Dragしたキャラクターの複製
    /// </summary>
    public void CreateCharacterObject()
    {

    }
}
