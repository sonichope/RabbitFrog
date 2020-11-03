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
        //if (!_makimono.GetArmyFlag) { return; }
        stageSelectCanvas.rootCanvas.enabled = false;
        //confirmCanvas.rootCanvas.enabled = false;
        organizationCanvas.rootCanvas.enabled = !organizationCanvas.rootCanvas.enabled;
    }

    /// <summary>
    /// ステージ選択画面を押した時
    /// </summary>
    public void OnOpenStageSelect()
    {
        //if (!_makimono.GetSelectFlag) { return; }
        organizationCanvas.rootCanvas.enabled = false;
        //confirmCanvas.rootCanvas.enabled = false;
        stageSelectCanvas.rootCanvas.enabled = !stageSelectCanvas.rootCanvas.enabled;
    }

    /// <summary>
    /// 他のスクリプトからこのFlagがtrueの時どちらかの関数を呼び出す
    /// </summary>
    public void GetFlag()
    {
        //Debug.Log(_makimonoFlag.test + " / " + _makimonoFlag.mark);
        if (_makimonoFlag.test)
        {
            Debug.Log("aaaaa");
            _makimonoFlag.test = !_makimonoFlag.test;
            //_makimonoFlag.mark = false;
            OnOpenOrganization();
        }
        else if (_makimonoFlag.mark)
        {
            Debug.Log("aaaaa");
            _makimonoFlag.test = !_makimonoFlag.test;
            //_makimonoFlag.test = false;
            OnOpenStageSelect();
        }
    }

    /// <summary>
    /// 巻物を閉じるアニメーション再生時にメニューUIを非表示にする
    /// </summary>
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
