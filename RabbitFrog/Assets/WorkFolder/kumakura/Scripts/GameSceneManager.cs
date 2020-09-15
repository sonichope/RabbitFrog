using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField, Header("MainCameraにアタッチ")]
    Effect_Sketch effect_Sketch;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public static void LoadScenarioScene()
    {
        SceneManager.LoadScene("ScenarioScene");
    }

    public static void LoadOptionScene()
    {
        SceneManager.LoadScene("OptionScene");
    }

    public static void LoadBattleFirstScene()
    {
        SceneManager.LoadScene("BattleFirst");
    }

    public static void LoadBattleSecondScene()
    {
        SceneManager.LoadScene("BattleSecond");
    }

    public static void LoadBattleThirdScene()
    {
        SceneManager.LoadScene("BattleThird");
    }

    public static void LoadClearScene()
    {
        SceneManager.LoadScene("ClearScene");
    }
    
    public static void LoadBattleBossScene()
    {
        
        SceneManager.LoadScene("BattleBoss");
    }

    //private IEnumerator NaxtScene(string SceneName)
    //{
    //    yield return StartCoroutine(effect_sketch.fade_Out());
    //    SceneManager.LoadScene(SceneName);
    //}
}
