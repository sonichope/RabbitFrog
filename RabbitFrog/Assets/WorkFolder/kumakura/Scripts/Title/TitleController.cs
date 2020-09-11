using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleController : MonoBehaviour
{
    private bool Scene_changing = false;

    [SerializeField]
    Effect_Sketch effect_Sketch;

    void Start()
    {
        
    }

    void Update()
    {
        // 条件は後々変更する
        // PCからタブレットでも動くように条件式を書き換える
        if (Input.GetMouseButtonDown(0) && !Scene_changing)
        {
            StartCoroutine(effect_Sketch.fade_Out());
            StartCoroutine(nextScene());

            //GameSceneManager.LoadScenarioScene();
        }
    }

    IEnumerator nextScene()
    {
        Scene_changing = true;
        yield return StartCoroutine(effect_Sketch.fade_Out());
        GameSceneManager.LoadScenarioScene();
    }

}
