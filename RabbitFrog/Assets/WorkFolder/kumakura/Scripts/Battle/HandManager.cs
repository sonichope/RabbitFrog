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
        // ここの処理ごり押しだから近いうちになんとかしたい
        Debug.Log(DeckManager.deckObjects[myHandNumber].cardPoolObject.myCardType);
        switch (DeckManager.deckObjects[myHandNumber].cardPoolObject.myCardType)
        {
            case CardPoolObject.CardType.infantry:
                Instantiate(createCharacterList[0], summonPos, Quaternion.identity);
                break;

            case CardPoolObject.CardType.infantryPlatoon:
                Instantiate(createCharacterList[1], summonPos, Quaternion.identity);
                break;

            case CardPoolObject.CardType.cavalry:
                Instantiate(createCharacterList[2], summonPos, Quaternion.identity);
                break;

            case CardPoolObject.CardType.knight:
                Instantiate(createCharacterList[3], summonPos, Quaternion.identity);
                break;

            case CardPoolObject.CardType.samurai:
                Instantiate(createCharacterList[4], summonPos, Quaternion.identity);
                break;

            case CardPoolObject.CardType.archeryCorps:
                Instantiate(createCharacterList[5], summonPos, Quaternion.identity);
                break;

            case CardPoolObject.CardType.ninja:
                Instantiate(createCharacterList[6], summonPos, Quaternion.identity);
                break;

            case CardPoolObject.CardType.cavalryGeneral:
                Instantiate(createCharacterList[7], summonPos, Quaternion.identity);
                break;

            case CardPoolObject.CardType.heavyKnight:
                Instantiate(createCharacterList[8], summonPos, Quaternion.identity);
                break;

            case CardPoolObject.CardType.monster:
                Instantiate(createCharacterList[9], summonPos, Quaternion.identity);
                break;

            case CardPoolObject.CardType.necromancer:
                Instantiate(createCharacterList[10], summonPos, Quaternion.identity);
                break;

            case CardPoolObject.CardType.ghost:
                Instantiate(createCharacterList[11], summonPos, Quaternion.identity);
                break;

            case CardPoolObject.CardType.thunderGod:
                Instantiate(createCharacterList[12], summonPos, Quaternion.identity);
                break;

        }
    }
}
