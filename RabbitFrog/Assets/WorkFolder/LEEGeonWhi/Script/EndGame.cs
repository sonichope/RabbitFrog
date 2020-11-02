using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    Canvas endGameCanvas;

    [SerializeField]
    Canvas confirmcanvas_battle;

    [SerializeField]
    Tower Rabbit_Tower;

    [SerializeField]
    EnemyTower Frog_Tower;

    [SerializeField]
    BattleController battleController;
    
    //==================================
      //Panel用イメージ
    [SerializeField]
    GameObject Fail;
    [SerializeField]
    GameObject TimeOut;
    [SerializeField]
    GameObject Clear;
    //==================================

    private bool is_Click;

    void Start()
    {
        is_Click = false;
        endGameCanvas.rootCanvas.enabled = false;
    }

    void Update()
    {
        //負けたら
        if (Rabbit_Tower.IsDeath && !is_Click)
        {
            endGameCanvas.rootCanvas.enabled = true;
            is_Click = true;
            Fail.SetActive(true);
        }

        //勝ったら
        if (Frog_Tower.IsDeath && !is_Click)
        {
            endGameCanvas.rootCanvas.enabled = true;
            is_Click = true;
            Clear.SetActive(true);
        }

        //TimeOut
        if (battleController.is_Time_out && !is_Click)
        {
            endGameCanvas.rootCanvas.enabled = true;
            is_Click = true;
            TimeOut.SetActive(true);
        }
    }

    //実行関数、EnventTrigger
    ///========================================================
    public void Fail_img()
    {
        confirmcanvas_battle.enabled = true;
        endGameCanvas.rootCanvas.enabled = false;
    }

    public void TImeOut_img()
    {
        confirmcanvas_battle.enabled = true;
        endGameCanvas.rootCanvas.enabled = false;
    }

    public void Clear_img()
    {
        confirmcanvas_battle.enabled = true;
        endGameCanvas.rootCanvas.enabled = false;
    }
    ///========================================================
}
