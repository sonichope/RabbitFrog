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

    [SerializeField] private bool armyFlag = true;
    [SerializeField] private bool selectFlag = true;

    // FirstAnim ::開くアニメーションへのトリガー
    // ReturnAnim::開くアニメーションから空のstateに戻ってくるトリガー
    // StartAnim ::閉じるアニメーションへのトリガー
    // EndAnim   ::閉じるアニメーションから空のstateに戻ってくるトリガー
    // TransitionFirst::開くと、閉じるのアニメーションへのトリガー
    // TransitionEnd  ::開くと、閉じるのアニメーションから空のstateに戻ってくるトリガー

    void Start()
    {
        Debug.Log("aaa");
        anim = startPepar.GetComponent<Animator>();
        anim = endPepar.GetComponent<Animator>();
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
        if (armyFlag == false)
        {
            anim.SetTrigger("StartAnim");
        }
    }

    /// <summary>
    /// 戦場選択をタップした時
    /// </summary>
    public void ClickSelect()
    {
        if(selectFlag == false)
        {
            anim.SetTrigger("StartAnim");
        }
    }

    /// <summary>
    /// どちらかがタップされている時そのままの状態で空のstateへ行く
    /// </summary>
    public void ReturnAnim()
    {
        anim.SetTrigger("ReturnAnim");
    }

    /// <summary>
    /// どちらかがタップされている状態で一度タップしたものと同じものをタップされた時
    /// </summary>
    public void EndAnim()
    {
        anim.SetTrigger("EndAnim");
    }

    /// <summary>
    /// 軍編成がタップされた時 armyFlag = false
    /// </summary>
    public void ArmyFlag()
    {
        anim.SetTrigger("FirstAnim");
        if (!armyFlag) { return; }
        armyFlag = false;
    }

    /// <summary>
    /// 戦場選択がタップされた時 selectFlag = false
    /// </summary>
    public void SelectFrag()
    {
        anim.SetTrigger("FirstAnim");
        if (!selectFlag) { return; }
        selectFlag = false;
    }
}
