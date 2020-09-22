using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    
    public void MoveTitle()
    {
        StartCoroutine(effect_Sketch.NextScene("TitleScene"));
        GetComponent<GraphicRaycaster>().enabled = false;
    }
    public void MoveOption()
    {
        StartCoroutine(effect_Sketch.NextScene("OptionScene"));
        GetComponent<GraphicRaycaster>().enabled = false;
    }
    public void NextStage()
    {
        StartCoroutine(effect_Sketch.NextScene("BattleSecond"));
        GetComponent<GraphicRaycaster>().enabled = false;
    }
}
