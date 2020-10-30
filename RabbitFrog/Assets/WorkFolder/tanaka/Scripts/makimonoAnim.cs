using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class makimonoAnim : MonoBehaviour
{
    [SerializeField] GameObject startPaper;

    public new Animation animation;

    Animator anim;

    private makimono _makimono;

    [SerializeField] private bool armyFlag = false;
    [SerializeField] private bool selectFlag = false;
    // transitionFlagのtrue,falseを管理する
    [SerializeField] private bool transitionAnimFlag = false;
    // 2回クリックしたかを検知する
    [SerializeField] private bool secondFlag = false;

    private string transitionFirst = "TransitionFirst";
    private string isOpenFlag = "IsOpenFlag";
    private string transitionFlag = "TransitionFlag";

    // FirstAnim ::開くアニメーションへのトリガー(最初に動く)
    // FirstAnimFlag::開くアニメーションと閉じるアニメーション管理
    // StartAnim ::閉じるアニメーションへのトリガー(空のstateから)
    // EndAnim   ::閉じるアニメーションから空のstateに戻ってくるトリガー()
    // TransitionFirst::開くと、閉じるのアニメーションへのトリガー
    // TransitionEnd  ::開くと、閉じるのアニメーションから空のstateに戻ってくるトリガー

    void Start()
    {
        anim = startPaper.GetComponent<Animator>();
        _makimono = GetComponent<makimono>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BoolFlag()
    {
        if(!transitionAnimFlag)
        {
            anim.SetBool(transitionFlag, false);
        }
        else if(transitionAnimFlag)
        {
            anim.SetBool(transitionFlag, true);
        }
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
            Debug.Log("軍編成2回連続タップ / " + armyFlag + " / " + selectFlag);
            anim.SetBool(isOpenFlag, false);
            //-----armyFlag = false;
            secondFlag = true;
        }

        //-----------------------------------------------------
        // 2連続タップ
        else if (armyFlag == false && selectFlag == false && secondFlag)
        {
            Debug.Log("2連続タップ / " + armyFlag + " / " + selectFlag + " / " + secondFlag);
            anim.SetBool(isOpenFlag, true);
            secondFlag = false;
            //_makimono.MakimonoScale();
        }
        //-----------------------------------------------------

        // 1回目が戦場選択、2回目が軍編成(軍編成の巻物が開いている時)
        else if (armyFlag == true && selectFlag == false)
        {
            Debug.Log("1回目が戦場選択、2回目が軍編成(軍編成の巻物が開いている時) / " + armyFlag + " / " + selectFlag + " 反転");
            anim.SetTrigger(transitionFirst);
            //-----armyFlag = true;
            selectFlag = false;
            //secondFlag = false;
            //
            transitionAnimFlag = !transitionAnimFlag;
            anim.SetBool(transitionFlag, transitionAnimFlag);
        }
        
        // ArmyFlag()が一瞬呼ばれるからFlagが反転する
        //else if (armyFlag == false && selectFlag == true)
        //{
        //    anim.SetBool(transitionFlag, true);
        //    armyFlag = false;
        //    //-----selectFlag = false;
        //    secondFlag = false;
        //}
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
        else if (selectFlag ==　false && armyFlag == false && secondFlag)
        {
            Debug.Log(armyFlag + " / " + selectFlag + " / " + secondFlag);
            anim.SetBool(isOpenFlag, true);
            secondFlag = false;
            //_makimono.MakimonoScale();
        }
        //-----------------------------------------------------

        // 1回目が軍編成、2回目が戦場選択のとき
        else if (armyFlag == false && selectFlag == true)
        {
            Debug.Log(armyFlag + " / " + selectFlag + " 反転");
            anim.SetTrigger(transitionFirst);
            // 開いたままのアニメーションを再生
            armyFlag = false;
            //-----selectFlag = true;
            //econdFlag = false;
            transitionAnimFlag = !transitionAnimFlag;
            anim.SetBool(transitionFlag, transitionAnimFlag);
        }

        //-----------------------------------------------------
        //// 一度"MakimonoBothAnim"が呼ばれた後にもう一度別の巻物を開きなおす時の処理
        //else if (armyFlag == true && selectFlag == false)
        //{
        //    anim.SetBool(transitionFlag, true);
        //    secondFlag = false;
        //}

        //-----------------------------------------------------
        // "MakimonoBothAnim"が呼ばれた後にもう一度同じ巻物がタップされた時の処理
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
        anim.SetBool(isOpenFlag, false);
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
        anim.SetBool(isOpenFlag, false);
        anim.SetTrigger("FirstAnim");
        armyFlag = false;
        selectFlag = !selectFlag;
        //if (selectFlag == false) { selectFlag = true; }
    }
}
