using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionController : MonoBehaviour
{
    [SerializeField] private Canvas organizationCanvas;
    [SerializeField] private Canvas stageSelectCanvas;



    void Start()
    {
        organizationCanvas.enabled = false;
        stageSelectCanvas.enabled = false;
    }

    void Update()
    {
        // 条件は後々変更する
        // PCからタブレットでも動くように条件式を書き換える
        if (Input.GetMouseButtonDown(0))
        {
            // 遷移するシーンはBattleシーン完成後に変更すること
            //SceneManager.LoadScene("BattleFirst");
        }
    }

    /// <summary>
    /// 編成画面ボタンを押した時
    /// </summary>
    public void OnOpenOrganization()
    {
        // もうひとつが既にtrueならfalseにする処理
        if (stageSelectCanvas.enabled)
        {
            stageSelectCanvas.rootCanvas.enabled = false;
        }
        organizationCanvas.enabled = !organizationCanvas.enabled;
    }

    /// <summary>
    /// ステージ選択画面を押した時
    /// </summary>
    public void OnOpenStageSelect()
    {
        // もうひとつが既にtrueならfalseにする処理
        if (organizationCanvas.enabled)
        {
            organizationCanvas.enabled = false;
        }
        stageSelectCanvas.rootCanvas.enabled = !stageSelectCanvas.enabled;
    }
}
