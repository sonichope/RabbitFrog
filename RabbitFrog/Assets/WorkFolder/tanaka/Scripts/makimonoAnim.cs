using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makimonoAnim : MonoBehaviour
{
    [SerializeField] GameObject startPepar;
    [SerializeField] GameObject endPepar;
    Animator anim;
    [SerializeField] private new Animation animation;
    makimono _makimono;

    //private bool animFrag = true;
    [SerializeField] private bool armyFrag = true;
    [SerializeField] private bool selectFrag = true;

    // 一回タップ、広げるアニメーション
    // 二回目タップ仕舞うアニメーション(同じ巻物をタップした時)
    // 違う巻物をクリックした時、仕舞うアニメーションは経由せずそのままタップしたほうの巻物を広げる

    void Start()
    {
        Debug.Log("aaa");
        anim = startPepar.GetComponent<Animator>();
        anim = endPepar.GetComponent<Animator>();
        //animation = endPepar.GetComponent<Animation>();
        //animation = startPepar.GetComponent<Animation>();
        endPepar.SetActive(false);
        //anim = GetComponent(typeof(Animator)) as Animation;
    }

    // Update is called once per frame
    void Update()
    {
        // アニメーションが終わったら
        //if (!animation.IsPlaying("MakimonoStartAnim"))
        //{
        //    endPepar.SetActive(true);
        //    startPepar.SetActive(false);
        //}
        //else if (!animation.IsPlaying("MakimonoEndAnim"))
        //{
        //    startPepar.SetActive(true);
        //    endPepar.SetActive(false);
        //}
    }

    public void ClickArmy()
    {
        if (armyFrag == false)
        {
            startPepar.SetActive(true);
            anim.SetTrigger("startanim");
            //StartArmy();
        }
        else if (armyFrag == true)
        {
            // 条件か何か付け足さないと一瞬で呼ばれてしまう
            endPepar.SetActive(true);
            startPepar.SetActive(false);
            anim.SetTrigger("FirstAnim");
            //if (!animation.IsPlaying("MakimonoStartAnim"))
            //{
            //}
        }
    }

    public void ClickSelect()
    {
        if (selectFrag == false)
        {
            startPepar.SetActive(true);
            anim.SetTrigger("startanim");
            //StartSelect();
        }
        else if (selectFrag == true)
        {
            endPepar.SetActive(true);
            startPepar.SetActive(false);
            anim.SetTrigger("FirstAnim");
        }
    }

    public void ArmyFlag()
    {
        if (!armyFrag) { return; }
        armyFrag = false;
    }

    public void SelectFlag()
    {
        if (!selectFrag) { return; }
        selectFrag = false;
    }

    public void ReturnAnim()
    {
        anim.SetTrigger("ReturnAnim");
    }
    
    public void EndAnim()
    {
        anim.SetTrigger("EndAnim");
    }

    //public void StartArmy()
    //{
    //    anim.SetTrigger("startanim");
    //}

    //public void StartSelect()
    //{
    //    anim.SetTrigger("StartAnim");
    //}
}
