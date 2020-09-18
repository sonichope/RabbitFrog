using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class OptionController : MonoBehaviour
{
    [SerializeField] private Canvas organizationCanvas;
    [SerializeField] private Canvas stageSelectCanvas;

    void Start()
    {
        organizationCanvas.enabled = false;
        stageSelectCanvas.enabled = false;
    }

    /// <summary>
    /// 編成画面ボタンを押した時
    /// </summary>
    public void OnOpenOrganization()
    {
        stageSelectCanvas.rootCanvas.enabled = false;
        organizationCanvas.rootCanvas.enabled = !organizationCanvas.rootCanvas.enabled;
    }

    /// <summary>
    /// ステージ選択画面を押した時
    /// </summary>
    public void OnOpenStageSelect()
    {
        organizationCanvas.rootCanvas.enabled = false;
        stageSelectCanvas.rootCanvas.enabled = !stageSelectCanvas.rootCanvas.enabled;
    }

    


}
