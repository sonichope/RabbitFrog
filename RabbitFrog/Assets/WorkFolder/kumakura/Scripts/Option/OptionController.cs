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
    [SerializeField] private GameObject startPaper;

    //private makimonoAnim makimonoAnimation;
    Animation anim;

    [SerializeField] makimonoAnim _makimono;
    [SerializeField] makimono _makimonoFlag;

    void Start()
    {
        anim = startPaper.GetComponent<Animation>();
        organizationCanvas.enabled = false;
        stageSelectCanvas.enabled = false;
        //makimonoAnimation = GetComponent<makimonoAnim>();
        //confirmCanvas.enabled = false;
    }

    /// <summary>
    /// 編成画面ボタンを押した時
    /// </summary>
    public void OnOpenOrganization()
    {
        if (!_makimono.GetArmyFlag) { return; }
        stageSelectCanvas.rootCanvas.enabled = false;
        //confirmCanvas.rootCanvas.enabled = false;
        organizationCanvas.rootCanvas.enabled = !organizationCanvas.rootCanvas.enabled;
    }

    /// <summary>
    /// ステージ選択画面を押した時
    /// </summary>
    public void OnOpenStageSelect()
    {
        if (!_makimono.GetSelectFlag) { return; }
        organizationCanvas.rootCanvas.enabled = false;
        //confirmCanvas.rootCanvas.enabled = false;
        stageSelectCanvas.rootCanvas.enabled = !stageSelectCanvas.rootCanvas.enabled;
    }

    public void GetFlag()
    {
        if (_makimonoFlag.GetTestFlag)
        {
            OnOpenOrganization();
        }
        if (_makimonoFlag.GetMarkFlag)
        {
            OnOpenStageSelect();
        }
    }

    public void Enable()
    {
        stageSelectCanvas.rootCanvas.enabled = false;
        organizationCanvas.rootCanvas.enabled = false;
    }

    //public void OnOpenConfirm()
    //{
    //    stageSelectCanvas.rootCanvas.enabled = false;
    //    organizationCanvas.rootCanvas.enabled = false;
    //    confirmCanvas.rootCanvas.enabled = !confirmCanvas.rootCanvas.enabled;
    //}

}
