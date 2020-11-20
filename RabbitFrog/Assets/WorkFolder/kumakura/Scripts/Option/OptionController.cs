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

    [SerializeField] private OrganizationMask organizationMask;
    [SerializeField] private Organization organization;
    [SerializeField] private StageSelectMask stageSelectMask;
    [SerializeField] private StageSelect stageSelect;

    GraphicRaycaster organization_raycaster;
    GraphicRaycaster stageSelect_raycaster;
    

    void Start()
    {
        organizationCanvas.enabled = false;
        stageSelectCanvas.enabled = false;
        //confirmCanvas.enabled = false;

        organization_raycaster = organizationCanvas.GetComponent<GraphicRaycaster>();
        stageSelect_raycaster = stageSelectCanvas.GetComponent<GraphicRaycaster>();
    }

    /// <summary>
    /// 編成画面ボタンを押した時
    /// </summary>
    public void OnOpenOrganization()
    {
        stageSelectCanvas.rootCanvas.enabled = false;
        //confirmCanvas.rootCanvas.enabled = false;
        organizationCanvas.rootCanvas.enabled = !organizationCanvas.rootCanvas.enabled;
        
        stageSelect_raycaster.enabled = false;
        stageSelect.Close();

        //イゴンヒ（201104）==============
        organizationCanvas.rootCanvas.enabled = true;
        //organization_raycaster.enabled = !organization_raycaster.enabled;
        organization_raycaster.enabled = true;
        
        stageSelectMask.image.fillAmount = 0;
        stageSelectMask.start_anime = false;
        
        organizationMask.Run_animation();
        organization.Open();
        //================================
    }

    /// <summary>
    /// ステージ選択画面を押した時
    /// </summary>
    public void OnOpenStageSelect()
    {
        organizationCanvas.rootCanvas.enabled = false;
        organization.Close();
        organization_raycaster.enabled = false;
        //confirmCanvas.rootCanvas.enabled = false;
        //stageSelectCanvas.rootCanvas.enabled = !stageSelectCanvas.rootCanvas.enabled;

        //イゴンヒ（201104）==============
        stageSelectCanvas.rootCanvas.enabled = true;
        stageSelect_raycaster.enabled = true;
        //stageSelect_raycaster.enabled = !stageSelect_raycaster.enabled;
        
        organizationMask.image.fillAmount = 0;
        organizationMask.start_anime = false;
        
        stageSelectMask.Run_animation();
        stageSelect.Open();
        //================================

    }



    //public void OnOpenConfirm()
    //{
    //    stageSelectCanvas.rootCanvas.enabled = false;
    //    organizationCanvas.rootCanvas.enabled = false;
    //    confirmCanvas.rootCanvas.enabled = !confirmCanvas.rootCanvas.enabled;
    //}

}
