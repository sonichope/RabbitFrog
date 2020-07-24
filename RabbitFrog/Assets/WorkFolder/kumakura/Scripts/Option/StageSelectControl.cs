using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageSelectControl : MonoBehaviour
{
    public void OnBattleFirst()
    {
        GameSceneManager.LoadBattleFirstScene();
    }

    public void OnBattleSecond()
    {
        GameSceneManager.LoadBattleSecondScene();
    }

    public void OnBattleThird()
    {
        GameSceneManager.LoadBattleThirdScene();
    }

    public void OnBattleBoss()
    {
        GameSceneManager.LoadBattleBossScene();
    }
}
