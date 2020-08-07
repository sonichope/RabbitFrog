using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandManager : MonoBehaviour
{
    public GameObject[] createCharacterList = new GameObject[13];
    [SerializeField] private GameObject[] handObjects = new GameObject[4];
    [SerializeField] private GameObject nextHand;
    [SerializeField] private BattleController battleController;
    [SerializeField] private float minRandomPos_x;
    [SerializeField] private float maxRandomPos_x;
    [SerializeField] private float minRandomPos_y;
    [SerializeField] private float maxRandomPos_y;

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
        var cost = DeckManager.deckObjects[myHandNumber].cardPoolObject.character.cost;
        var myCardType = DeckManager.deckObjects[myHandNumber].cardPoolObject.character.myCardType;

        if (battleController.SummonGageVal - cost < 0) { return; }
        battleController.SummonGageVal -= cost;

        int summonVal = DeckManager.deckObjects[myHandNumber].cardPoolObject.character.summonVol; 
        for(int i = 0; i < summonVal; i++)
        {
            if (summonVal > 1)
            {
                float randomPos_x = Random.Range(minRandomPos_x, maxRandomPos_x);
                float randomPos_y = Random.Range(minRandomPos_y, maxRandomPos_y);
                summonPos.x = summonPos.x + randomPos_x;
                summonPos.y = summonPos.y + randomPos_y;
            }
            Instantiate(createCharacterList[(int)myCardType], summonPos, Quaternion.identity);
        }

        
    }
}
