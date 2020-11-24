using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ghost
{
	public class StageSelectControl : MonoBehaviour
	{
		[SerializeField, Header("MainCameraにアタッチ")] 
        Effect_Sketch effect_Sketch;

        [SerializeField] private Canvas confirmCanvas;
        [SerializeField] private Image[] StagePanel;　//BattleFirst, BattleSecond , BattleThird ,BattleBossにアタッチ

        public static string NextScene = null;
        public int nextStageId = 0;
        
        private void Start()
        {
            //SaveDataを呼び込んてステージに移動可能かをUIで表示
            for(int i = 0; i < StagePanel.Length; i++)
            {
                if(UserDataControl.SaveData.IsClearStage(i))
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
            const int id = 0;
            if ( !GameSetting.GetStageData(id)) return;
            //if (DeckCheck()) GameSceneManager.LdadBattleFirstScene();
            if (DeckCheck() && !effect_Sketch.Scene_changing && UserDataControl.SaveData.IsClearStage(id))
            {
                //StartCoroutine(effect_Sketch.NextScene("BattleFirst"));
                NextScene = "Battle";
                nextStageId = id;
                confirmCanvas.rootCanvas.enabled = !confirmCanvas.rootCanvas.enabled;
            }
        }

        public void OnBattleSecond()
        {
            if ( !GameSetting.GetStageData(1)) return;
            //if (DeckCheck()) GameSceneManager.LoadBattleSecondScene();
            if (DeckCheck() && !effect_Sketch.Scene_changing && UserDataControl.SaveData.IsClearStage(1))
            {
                NextScene = "BattleSecond";
                confirmCanvas.rootCanvas.enabled = !confirmCanvas.rootCanvas.enabled;
            }
        }

        public void OnBattleThird()
        {
            if ( !GameSetting.GetStageData(2)) return;
            //if (DeckCheck()) GameSceneManager.LoadBattleThirdScene();
            if (DeckCheck() && !effect_Sketch.Scene_changing && UserDataControl.SaveData.IsClearStage(2))
            {
                NextScene = "BattleThird";
                confirmCanvas.rootCanvas.enabled = !confirmCanvas.rootCanvas.enabled;
            }
        }

        public void OnBattleBoss()
        {
            if ( !GameSetting.GetStageData(3)) return;
            //if (DeckCheck()) GameSceneManager.LoadBattleBossScene();
            if (DeckCheck() && !effect_Sketch.Scene_changing && UserDataControl.SaveData.IsClearStage(3))
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
}