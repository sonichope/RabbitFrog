﻿using System.Collections;
using System.Collections.Generic;
using Ghost;
using UnityEngine;
using UnityEngine.UI;


public class StageSelectControl : MonoBehaviour
{
    [SerializeField, Header("MainCameraにアタッチ")]
    Effect_Sketch effect_Sketch;

    [SerializeField] private Canvas confirmCanvas;
    [SerializeField] private Image[] StagePanel;　//BattleFirst, BattleSecond , BattleThird ,BattleBossにアタッチ

    public static string NextScene = null;

    private void Awake()
    {
        
    }

    private void Start()
    {
        //SaveDataを呼び込んてステージに移動可能かをUIで表示
       for(int i = 0; i < StagePanel.Length; i++)
        {
            if(SaveData.StageClear[i] == true)
            {
                StagePanel[i].color = new Color(1, 1, 1, 1);
            }
            else
            {
                StagePanel[i].color = new Color(0.7f, 0.7f, 0.7f, 0.3f);
            }
            
        }
    }

    public void OnBattleFirst()
    {
        if ( !GameSetting.GetStageData(0)) return;
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
        if ( !GameSetting.GetStageData(1)) return;
        //if (DeckCheck()) GameSceneManager.LoadBattleSecondScene();
        if (DeckCheck() && !effect_Sketch.Scene_changing && SaveData.StageClear[1])
        {
            NextScene = "BattleSecond";
            confirmCanvas.rootCanvas.enabled = !confirmCanvas.rootCanvas.enabled;
        }
    }

    public void OnBattleThird()
    {
        if ( !GameSetting.GetStageData(2)) return;
        //if (DeckCheck()) GameSceneManager.LoadBattleThirdScene();
        if (DeckCheck() && !effect_Sketch.Scene_changing && SaveData.StageClear[2])
        {
            NextScene = "BattleThird";
            confirmCanvas.rootCanvas.enabled = !confirmCanvas.rootCanvas.enabled;
        }
    }

    public void OnBattleBoss()
    {
        if ( !GameSetting.GetStageData(3)) return;
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
