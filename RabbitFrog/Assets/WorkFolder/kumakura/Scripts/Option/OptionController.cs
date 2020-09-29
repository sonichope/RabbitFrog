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
    [SerializeField] private Canvas confirmCanvas;
    [SerializeField] private PreviewManager preMana;
    

    void Start()
    {
        organizationCanvas.enabled = false;
        stageSelectCanvas.enabled = false;
        //confirmCanvas.enabled = false;
    }

    /// <summary>
    /// 編成画面ボタンを押した時
    /// </summary>
    public void OnOpenOrganization()
    {
        stageSelectCanvas.rootCanvas.enabled = false;
        //confirmCanvas.rootCanvas.enabled = false;
        organizationCanvas.rootCanvas.enabled = !organizationCanvas.rootCanvas.enabled;
    }

    /// <summary>
    /// ステージ選択画面を押した時
    /// </summary>
    public void OnOpenStageSelect()
    {
        organizationCanvas.rootCanvas.enabled = false;
        //confirmCanvas.rootCanvas.enabled = false;
        stageSelectCanvas.rootCanvas.enabled = !stageSelectCanvas.rootCanvas.enabled;
    }

    //public void OnOpenConfirm()
    //{
    //    stageSelectCanvas.rootCanvas.enabled = false;
    //    organizationCanvas.rootCanvas.enabled = false;
    //    confirmCanvas.rootCanvas.enabled = !confirmCanvas.rootCanvas.enabled;
    //}


}
