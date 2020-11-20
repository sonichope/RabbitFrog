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

    GraphicRaycaster organization_Canvas_raycaster;
    GraphicRaycaster stageSelect_Canvas_raycaster;

    Image organizationButton;
    Image stageSelectButton;

    [SerializeField]
    static public bool is_runing;


    void Start()
    {
        //organizationCanvas.enabled = false;
        //stageSelectCanvas.enabled = false;
        //confirmCanvas.enabled = false;

        organization_Canvas_raycaster = organizationCanvas.GetComponent<GraphicRaycaster>();
        stageSelect_Canvas_raycaster = stageSelectCanvas.GetComponent<GraphicRaycaster>();

        organizationButton = organization.GetComponent<Image>();
        stageSelectButton = stageSelect.GetComponent<Image>();

        is_runing = false;
    }

    /// <summary>
    /// 編成画面ボタンを押した時
    /// </summary>
    public void OnOpenOrganization()
    {
        if (is_runing == true) return;

        //=============================================
        //stageSelectCanvas.rootCanvas.enabled = false;
        //confirmCanvas.rootCanvas.enabled = false;
        //organizationCanvas.rootCanvas.enabled = !organizationCanvas.rootCanvas.enabled;

        //stageSelect_Canvas_raycaster.enabled = false;
        stageSelect.Close();

        //イゴンヒ（201104）==============
        //organizationCanvas.rootCanvas.enabled = true;
        organization_Canvas_raycaster.enabled = !organization_Canvas_raycaster.enabled;
        
        stageSelectMask.image.fillAmount = 0;

        //organizationMask.Open_animation();
      if (organizationMask.is_status == false && stageSelectMask.is_status == true)
            {

            }
            if (organizationMask.is_status == false)
            {
                StartCoroutine(organizationMask.Open());
                organization.Open();
            }

            else if (organizationMask.is_status == true)
            {
                StartCoroutine(organizationMask.Close());
                organization.Close();
            }
    
        //================================
    }

    /// <summary>
    /// ステージ選択画面を押した時
    /// </summary>
    public void OnOpenStageSelect()
    {
        if (is_runing == true) return;

        //organizationCanvas.rootCanvas.enabled = false;
        organization.Close();
        //organization_Canvas_raycaster.enabled = false;
        //confirmCanvas.rootCanvas.enabled = false;
        //stageSelectCanvas.rootCanvas.enabled = !stageSelectCanvas.rootCanvas.enabled;

        //イゴンヒ（201104）==============
        //stageSelectCanvas.rootCanvas.enabled = true;
        stageSelect_Canvas_raycaster.enabled = !stageSelect_Canvas_raycaster.enabled;
        
        organizationMask.image.fillAmount = 0;

        //  stageSelectMask.Open_animation();
        
            if (stageSelectMask.is_status == false && organizationMask.is_status == true)
            {

            }

            else if (stageSelectMask.is_status == false)
            {
                StartCoroutine(stageSelectMask.Open());
                stageSelect.Open();
            }
            else if (stageSelectMask.is_status == true)
            {
                StartCoroutine(stageSelectMask.Close());
                stageSelect.Close();
            }
        //================================

    }



    //public void OnOpenConfirm()
    //{
    //    stageSelectCanvas.rootCanvas.enabled = false;
    //    organizationCanvas.rootCanvas.enabled = false;
    //    confirmCanvas.rootCanvas.enabled = !confirmCanvas.rootCanvas.enabled;
    //}

}
