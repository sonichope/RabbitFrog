using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageSelectControl : MonoBehaviour
{

    public void OnBattleFirst()
    {
        if (DeckCheck()) GameSceneManager.LoadBattleFirstScene();
    }

    public void OnBattleSecond()
    {
        if (DeckCheck()) GameSceneManager.LoadBattleSecondScene();
    }

    public void OnBattleThird()
    {
        if (DeckCheck()) GameSceneManager.LoadBattleThirdScene();
    }

    public void OnBattleBoss()
    {
        if (DeckCheck()) GameSceneManager.LoadBattleBossScene();
    }

    /// <summary>
    /// デッキ編成に穴がないかチェック
    /// </summary>
    /// <returns></returns>
    public bool DeckCheck()
    {
        for (int i = 0; i < DeckManager.deckObjects.Length; i++)
        {
            // 一カ所でも編成していない場合はfalse
            if (DeckManager.deckObjects[i].cardPoolObject == null)
            {
                return false;
            }
        }
        return true;
    }


}
