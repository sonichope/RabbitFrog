using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makimonoAnim : MonoBehaviour
{
    [SerializeField] GameObject startPaper;
    
    [SerializeField] private bool armyFlag = false;
    [SerializeField] private bool selectFlag = false;
    // transitionFlagのtrue,falseを管理する
    [SerializeField] private bool transitionAnimFlag = true;
    // 2回クリックしたかを検知する
    [SerializeField] private bool secondFlag = false;
    
    private string transitionFirst = "TransitionFirst";
    private string isOpenFlag = "IsOpenFlag";
    private string transitionFlag = "TransitionFlag";
    
    public new Animation animation;
    Animator anim;

    private makimono _makimono;

    // プロパティ例1
    public bool GetArmyFlag { get { return armyFlag; } }

    public bool GetSelectFlag { get { return selectFlag; } }

    #region プロパティ例2
    //public bool AAA()
    //{
    //    return armyFlag;
    //}
    #endregion

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
            armyFlag = true;
            secondFlag = false;
            //_makimono.MakimonoScale();
        }
        //-----------------------------------------------------

        // 1回目が戦場選択、2回目が軍編成(軍編成の巻物が開いている時)
        else if (armyFlag == true && selectFlag == false)
        {
            Debug.Log("1回目が戦場選択、2回目が軍編成(軍編成の巻物が開いている時) / " + armyFlag + " / " + selectFlag + " 反転");
            // 開いている状態の巻物を入れ替える処理(1回目)
            anim.SetTrigger(transitionFirst);
            //-----armyFlag = true;
            selectFlag = false;
            secondFlag = false;
            // 入れ替えた処理からもう一度入れ替えの処理を行う時(2回目以降)
            //--------------------------------------------------------
            transitionAnimFlag = !transitionAnimFlag;
            anim.SetBool(transitionFlag, transitionAnimFlag);
            //--------------------------------------------------------
        }
    }

    /// <summary>
    /// 戦場選択をタップした時
    /// </summary>
    public void ClickSelect()
    {
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
            selectFlag = true;
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
            secondFlag = false;
            //--------------------------------------------------------
            transitionAnimFlag = !transitionAnimFlag;
            anim.SetBool(transitionFlag, transitionAnimFlag);
            //--------------------------------------------------------
        }
    }

    /// <summary>
    /// どちらも巻物が閉じている時に呼ばれる
    /// </summary>
    public void EndAnim()
    {
        anim.SetTrigger("EndAnim");
    }

    /// <summary>
    /// 軍編成がタップされた時 armyFlag = true
    /// </summary>
    public void ArmyFlag()
    {
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
        anim.SetBool(isOpenFlag, false);
        anim.SetTrigger("FirstAnim");
        armyFlag = false;
        selectFlag = !selectFlag;
        //if (selectFlag == false) { selectFlag = true; }
    }
}
