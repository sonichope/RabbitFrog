using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class OptionCanvas : MonoBehaviour
{
    [SerializeField]
    GameObject TitlePanel;

    [SerializeField]
    Effect_Sketch effect_Sketch;

    [SerializeField]
    Text textContants;

    private string TargetScene; //移動するScene name 変数

    void Start()
    {
        TitlePanel.SetActive(false);
        gameObject.GetComponent<GraphicRaycaster>().enabled = true;
    }

    //Title button
    public void TitleButton()
    {   
        TargetScene = "TitleScene";
        TitlePanel.SetActive(true);
        textContants.text = "タイトルに戻りますか？";
    }

    //gameReturn button
    public void ReturnButton()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    //game Retire button
    public void RetireButton()
    {
        TargetScene = SceneManager.GetActiveScene().name;
        TitlePanel.SetActive(true);
        textContants.text = "ゲームをリタイアしますか？";
    }

    //=========================================
    //確認メッセージ関連
    public void confirm_NO()
    {
        TitlePanel.SetActive(false);
    }

    public void confirm_Yes()
    {
        gameObject.GetComponent<GraphicRaycaster>().enabled = false; //重複クリック防除
        StartCoroutine(effect_Sketch.NextScene(TargetScene));
        Time.timeScale = 1;
    }
    //=========================================

    //PauseUIをマウスで押すと
    public void PauseUI_set()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
