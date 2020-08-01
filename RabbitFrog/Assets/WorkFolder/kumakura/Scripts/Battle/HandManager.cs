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
        if (battleController.SummonGageVal - 3.0f <= 0) { return; }
        // 後々コストに応じて召喚
        battleController.SummonGageVal -= 3.0f;

        Debug.Log(DeckManager.deckObjects[myHandNumber].cardPoolObject.myCardType);

        Instantiate(createCharacterList[(int)DeckManager.deckObjects[myHandNumber].cardPoolObject.myCardType], summonPos, Quaternion.identity);

        
    }
}
