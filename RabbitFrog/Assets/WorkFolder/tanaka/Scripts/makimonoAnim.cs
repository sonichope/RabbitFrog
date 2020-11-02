using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OptionState
{
    None = 0,
    Army,
    Select,
    Num
}

public class makimonoAnim : MonoBehaviour
{
    [SerializeField] OptionState optionState = OptionState.None;
    [SerializeField] GameObject startPaper;
    
    [SerializeField] private bool armyFlag = false;
    [SerializeField] private bool selectFlag = false;
    // transitionFlagのtrue,falseを管理する
    [SerializeField] private bool transitionAnimFlag = false;
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
        transitionAnimFlag = !transitionAnimFlag;
        Debug.Log("transitionFlagが" + transitionAnimFlag + "です");
        if (!transitionAnimFlag)
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
    /// クリックされたら動かす部分のコメント分
    public void ClickArmy()
    {
        Debug.Log("ClickArmy()");
        if (armyFlag == true && selectFlag == false && secondFlag == false)
        {
            Debug.Log("軍編成がタップされました / " + "armyFlagが" + armyFlag + " / " + "selectFlagが" + selectFlag);
            anim.SetBool(isOpenFlag, false);
            //-----armyFlag = false;
            secondFlag = true;
        }

        // 1回目が戦場選択、2回目が軍編成(軍編成の巻物が開いている時)
        else if (armyFlag == true && selectFlag == false)
        {
            Debug.Log("1回目が戦場選択、2回目が軍編成(軍編成の巻物が開いている時) / " + "armyFlagが" + armyFlag + " / " + "selectFlagが" + selectFlag + " 反転");
            // 開いている状態の巻物を入れ替える処理(1回目)
            anim.SetTrigger(transitionFirst);
            //-----armyFlag = true;
            selectFlag = false;
            secondFlag = false;
            // 入れ替えた処理からもう一度入れ替えの処理を行う時(2回目以降)
            //--------------------------------------------------------
            BoolFlag();
            //transitionAnimFlag = !transitionAnimFlag;
            anim.SetBool(transitionFlag, transitionAnimFlag);
            //--------------------------------------------------------
        }
        //-----------------------------------------------------

        // 2連続タップ
        else if (armyFlag == false && selectFlag == false && secondFlag)
        {
            Debug.Log("2連続タップ / " + "armyFlagが" + armyFlag + " / " + "selectFlagが" + selectFlag + " / " + "secondFlagが" + secondFlag);
            anim.SetBool(isOpenFlag, true);
            armyFlag = true;
            secondFlag = false;
            //_makimono.MakimonoScale();
        }
        //-----------------------------------------------------
    }

    /// <summary>
    /// 戦場選択をタップした時
    /// </summary>
    public void ClickSelect()
    {
        if (selectFlag == true && armyFlag == false && secondFlag == false)
        {
            Debug.Log("戦場選択がタップされました / " + "armyFlagが" + armyFlag + " / " + "selectFlagが" + selectFlag);
            anim.SetBool(isOpenFlag, false);
            //-----selectFlag = false;
            secondFlag = true;
        }

        // 1回目が軍編成、2回目が戦場選択のとき
        else if (armyFlag == false && selectFlag == true)
        {
            Debug.Log("armyFlagが" + armyFlag + " / " + "selectFlagが" + selectFlag + " 反転");
            armyFlag = false;
            anim.SetTrigger(transitionFirst);
            //-----selectFlag = true;
            secondFlag = false;
            //--------------------------------------------------------
            BoolFlag();
            //transitionAnimFlag = !transitionAnimFlag;
            anim.SetBool(transitionFlag, transitionAnimFlag);
            //--------------------------------------------------------
        }
        //-----------------------------------------------------
        // 2連続タップ
        else if (selectFlag == false && armyFlag == false && secondFlag)
        {
            Debug.Log("armyFlagが" + armyFlag + " / " + "selectFlagが" + selectFlag + " / " + "secondFlagが" + secondFlag);
            anim.SetBool(isOpenFlag, true);
            selectFlag = true;
            secondFlag = false;
            //_makimono.MakimonoScale();
        }
        //-----------------------------------------------------
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

    public void PushButton(OptionState clickButton)
    {
        OptionState prevState = optionState;
        OptionState nextState = (OptionState)clickButton;
        
        //if((int)nextState<0)
        //{
        //    nextState = OptionState.None;
        //}
        //if ((int)nextState >= (int)OptionState.Num)
        //{
        //    nextState = OptionState.None;
        //}

        if (prevState.Equals(OptionState.None))
        {
            if (nextState.Equals(OptionState.Army))//Armyに移動
            {
                anim.SetTrigger("FirstAnim");
            }
            else if (nextState.Equals(OptionState.Select))//Selectに移動
            {
                anim.SetTrigger("FirstAnim");
            }
            if (nextState.Equals(OptionState.None)) return;//何もしてない。
        }
        if (prevState.Equals(OptionState.Army))
        {
            if (nextState.Equals(OptionState.Army))//閉じる処理
            {
                nextState = OptionState.None;
                anim.SetBool(isOpenFlag, true);
            }
            else if (nextState.Equals(OptionState.Select))//Selectに移動
            {
                anim.SetTrigger(transitionFirst);
            }
            if (nextState.Equals(OptionState.None))//閉じる処理
            {
                anim.SetBool(isOpenFlag, true);
            }
        }
        if (prevState.Equals(OptionState.Select))
        {
            if (nextState.Equals(OptionState.Army))//Armyに移動
            {
                anim.SetTrigger(transitionFirst);
            }
            else if (nextState.Equals(OptionState.Select))//閉じる処理
            {
                anim.SetBool(isOpenFlag, true);
            }
            if (nextState.Equals(OptionState.None))//閉じる処理
            {
                anim.SetBool(isOpenFlag, true);
            }
        }
        optionState = nextState;
    }
}
