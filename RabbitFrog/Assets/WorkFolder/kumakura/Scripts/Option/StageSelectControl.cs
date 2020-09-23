using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageSelectControl : MonoBehaviour
{
    [SerializeField, Header("MainCameraにアタッチ")]
    Effect_Sketch effect_Sketch;

    [SerializeField] private Canvas confirmCanvas;

    static public string NextScene;

    public void OnBattleFirst()
    {
        //if (DeckCheck()) GameSceneManager.LdadBattleFirstScene();
        if (DeckCheck() && !effect_Sketch.Scene_changing && SaveData.StageClear[0])
        {
            //StartCoroutine(effect_Sketch.NextScene("BattleFirst"));
            NextScene = "BattleFirst";
            confirmCanvas.rootCanvas.enabled = !confirmCanvas.rootCanvas.enabled;
        }
    }

    public void OnBattleSecond()
    {
        //if (DeckCheck()) GameSceneManager.LoadBattleSecondScene();
        if (DeckCheck() && !effect_Sketch.Scene_changing && SaveData.StageClear[1])
        {
            NextScene = "BattleSecond";
            confirmCanvas.rootCanvas.enabled = !confirmCanvas.rootCanvas.enabled;
        }
    }

    public void OnBattleThird()
    {
        //if (DeckCheck()) GameSceneManager.LoadBattleThirdScene();
        if (DeckCheck() && !effect_Sketch.Scene_changing && SaveData.StageClear[2])
        {
            NextScene = "BattleThird";
            confirmCanvas.rootCanvas.enabled = !confirmCanvas.rootCanvas.enabled;

        }
    }

    public void OnBattleBoss()
    {
        //if (DeckCheck()) GameSceneManager.LoadBattleBossScene();
        if (DeckCheck() && !effect_Sketch.Scene_changing && SaveData.StageClear[3])
        {
            NextScene = "BattleBoss";
            confirmCanvas.rootCanvas.enabled = !confirmCanvas.rootCanvas.enabled;
        }
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
