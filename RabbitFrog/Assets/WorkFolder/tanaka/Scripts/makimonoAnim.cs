using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class makimonoAnim : MonoBehaviour
{
    [SerializeField] GameObject startPepar;
    [SerializeField] GameObject endPepar;

    public new Animation animation;

    Animator anim;
    makimono _makimono;

    public bool armyFlag = false;
    public bool selectFlag = false;
    [SerializeField] private bool secondFlag = false;

    private string transitionFirst = "TransitionFirst";
    //private string firstAnimFlag = "FirstAnimFlag";
    private string isOpenFlag = "IsOpenFlag";

    // FirstAnim ::開くアニメーションへのトリガー(最初に動く)
    // FirstAnimFlag::開くアニメーションと閉じるアニメーション管理
    // StartAnim ::閉じるアニメーションへのトリガー(空のstateから)
    // EndAnim   ::閉じるアニメーションから空のstateに戻ってくるトリガー()
    // TransitionFirst::開くと、閉じるのアニメーションへのトリガー
    // TransitionEnd  ::開くと、閉じるのアニメーションから空のstateに戻ってくるトリガー

    void Start()
    {
        anim = startPepar.GetComponent<Animator>();
        //anim = endPepar.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 軍編成をタップした時
    /// </summary>
    public void ClickArmy()
    {
        Debug.Log("ClickArmy()");
        // 軍編成2回連続タップ
        if (armyFlag == true && selectFlag == false && secondFlag == false)
        {
            Debug.Log(armyFlag + " / " + selectFlag);
            anim.SetBool(isOpenFlag, false);
            //-----armyFlag = false;
            secondFlag = true;
        }

        //-----------------------------------------------------
        // 2連続タップ
        else if (armyFlag == false && selectFlag == false && secondFlag)
        {
            Debug.Log(armyFlag + " / " + selectFlag + " / " + secondFlag);
            anim.SetBool(isOpenFlag, true);
            secondFlag = false;
        }
        //-----------------------------------------------------

        // 1回目が戦場選択、2回目が軍編成
        else if (armyFlag == true && selectFlag == false)
        {
            Debug.Log(armyFlag + " / " + selectFlag + " 反転");
            anim.SetTrigger(transitionFirst);
            selectFlag = false;
            //-----armyFlag = true;
            secondFlag = false;
        }
    }

    /// <summary>
    /// 戦場選択をタップした時
    /// </summary>
    public void ClickSelect()
    {
        // 戦場選択2回連続タップ
        if (selectFlag == true && armyFlag == false && secondFlag == false)
        {
            Debug.Log(armyFlag + " / " + selectFlag);
            anim.SetBool(isOpenFlag, false);
            //-----selectFlag = false;
            secondFlag = true;
        }

        //-----------------------------------------------------
        // 2連続タップ
        else if (selectFlag ==　false && armyFlag && secondFlag)
        {
            Debug.Log(armyFlag + " / " + selectFlag + " / " + secondFlag);
            anim.SetBool(isOpenFlag, true);
            secondFlag = false;
        }
        //-----------------------------------------------------

        // 1回目が軍編成、2回目が戦場選択のとき
        else if (armyFlag == false && selectFlag == true)
        {
            Debug.Log(armyFlag + " / " + selectFlag + " 反転");
            anim.SetTrigger(transitionFirst);
            //-----selectFlag = true;
            armyFlag = false;
            secondFlag = false;
        }
    }

    /// <summary>
    /// どちらも巻物が閉じている時に呼ばれる
    /// </summary>
    public void EndAnim()
    {
        //anim.SetBool(firstAnimFlag, false);
        anim.SetTrigger("EndAnim");
    }

    /// <summary>
    /// 軍編成がタップされた時 armyFlag = true
    /// </summary>
    public void ArmyFlag()
    {
        //anim.SetBool(firstAnimFlag, true);
        anim.SetTrigger("FirstAnim");
        selectFlag = false;
        armyFlag = !armyFlag;
        //if (armyFlag == false) { armyFlag = true; }
        
    }

    /// <summary>
    /// 戦場選択がタップされた時 selectFlag = true
    /// </summary>
    public void SelectFrag()
    {
        //anim.SetBool(firstAnimFlag, true);
        anim.SetTrigger("FirstAnim");
        armyFlag = false;
        selectFlag = !selectFlag;
        //if (selectFlag == false) { selectFlag = true; }

    }
}
