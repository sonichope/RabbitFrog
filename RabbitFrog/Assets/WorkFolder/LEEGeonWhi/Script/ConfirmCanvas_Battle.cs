using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfirmCanvas_Battle : MonoBehaviour
{
    [SerializeField]
    Canvas confirmcanvas_battle;

    [SerializeField]
    EnemyTower Frog_Tower;

    [SerializeField]
    Effect_Sketch effect_Sketch;

    void Start()
    {
        confirmcanvas_battle.rootCanvas.enabled = false;
    }

    void Update()
    {
        if(Frog_Tower.IsDeath)
        {
            confirmcanvas_battle.rootCanvas.enabled = true;
        }
    }

    //実行関数、EnventTrigger
    ///========================================================
    public void MoveTitle()
    {
        //StartCoroutine(effect_Sketch.NextScene("TitleScene"));
        StartCoroutine(effect_Sketch.NextScene(NextSceneName()));
        GetComponent<GraphicRaycaster>().enabled = false;
        SaveData.StageClear[0] = true;
    }
    public void MoveOption()
    {
        StartCoroutine(effect_Sketch.NextScene("OptionScene"));
        GetComponent<GraphicRaycaster>().enabled = false;
        SaveData.StageClear[0] = true;
    }
    public void NextStage()
    {
        StartCoroutine(effect_Sketch.NextScene("BattleSecond"));
        GetComponent<GraphicRaycaster>().enabled = false;
        SaveData.StageClear[0] = true;
    }

    ///========================================================
    /// <summary>
    /// 現在のSceneによって次のSceneのNameを決める。
    /// </summary>
    /// <returns></returns>
    string NextSceneName()
    {
        string name = SceneManager.GetActiveScene().name;

        switch (name)
        {
            case "BattleFirst":
                SaveData.StageClear[0] = true;
                return "BattleSecond";
            case "BattleSecond":
                SaveData.StageClear[1] = true;
                return "BattleThird";
            case "BattleThird":
                SaveData.StageClear[2] = true;
                return "BattleBoss";
            case "BattleBoss":
                SaveData.StageClear[3] = true;
                return "ClearScene";
            default:
                return null;
        }

    }

}
