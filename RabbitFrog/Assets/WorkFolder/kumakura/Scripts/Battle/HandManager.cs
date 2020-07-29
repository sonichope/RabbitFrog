using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandManager : MonoBehaviour
{
    public GameObject[] createCharacterList = new GameObject[13];
    [SerializeField] private GameObject[] handObjects = new GameObject[4];
    [SerializeField] private GameObject nextHand;


    void Start()
    {
        DeckShuffle();
        SetImage();
    }

    void Update()
    {
        
    }

    private void SetImage()
    {
        int count = 0;
        for (int i = 0; i < handObjects.Length; i++)
        {
            handObjects[count].GetComponent<Image>().sprite = DeckManager.deckObjects[count].iconImage.sprite;
            count++;
        }
        nextHand.GetComponent<Image>().sprite = DeckManager.deckObjects[count + 1].iconImage.sprite;
    }

    /// <summary>
    /// デッキのシャッフル機能
    /// </summary>
    private void DeckShuffle()
    {
        int shuffleVal = 0;
        while (shuffleVal <= 30)
        {
            int randomVal1 = Random.Range(0, DeckManager.deckObjects.Length);
            int randomVal2 = Random.Range(0, DeckManager.deckObjects.Length);
            //var temp = DeckManager.deckObjects[randomVal1].cardPoolObject.myCardType;
            //DeckManager.deckObjects[randomVal1].cardPoolObject.myCardType = DeckManager.deckObjects[randomVal2].cardPoolObject.myCardType;
            //DeckManager.deckObjects[randomVal2].cardPoolObject.myCardType = temp;
            
            var temp = DeckManager.deckObjects[randomVal1];
            DeckManager.deckObjects[randomVal1] = DeckManager.deckObjects[randomVal2];
            DeckManager.deckObjects[randomVal2] = temp;
            shuffleVal++;
        }
    }

    /// <summary>
    /// キャラクターの召喚
    /// </summary>
    /// <param name="summonPos">召喚場所</param>
    /// <param name="myHandNumber">手札番号</param>
    public void CharacterSummon(Vector3 summonPos, int myHandNumber)
    {
        switch (DeckManager.deckObjects[myHandNumber].cardPoolObject.myCardType)
        {
            case CardPoolObject.CardType.infantry:
                break;

            case CardPoolObject.CardType.infantryPlatoon:
                break;

            case CardPoolObject.CardType.cavalry:
                break;

            case CardPoolObject.CardType.knight:
                break;

            case CardPoolObject.CardType.samurai:
                break;

            case CardPoolObject.CardType.archeryCorps:
                break;

            case CardPoolObject.CardType.ninja:
                break;

            case CardPoolObject.CardType.cavalryGeneral:
                break;

            case CardPoolObject.CardType.heavyKnight:
                break;

            case CardPoolObject.CardType.monster:
                break;

            case CardPoolObject.CardType.necromancer:
                break;

            case CardPoolObject.CardType.ghost:
                break;

            case CardPoolObject.CardType.thunderGod:
                break;

        }
        Debug.Log(DeckManager.deckObjects[myHandNumber].cardPoolObject.myCardType);
        Instantiate(createCharacterList[0], summonPos, Quaternion.identity);
    }
}
