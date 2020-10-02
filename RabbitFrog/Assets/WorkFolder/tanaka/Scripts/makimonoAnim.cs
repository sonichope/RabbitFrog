using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makimonoAnim : MonoBehaviour
{
    [SerializeField] GameObject pepar;
    Animator anim;
    makimono _makimono;

    private bool animFrag = true;

    void Start()
    {
        Debug.Log("aaa");
        anim = pepar.GetComponent<Animator>();
        //anim = GetComponent(typeof(Animator)) as Animation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartArmy()
    {
        //_animation.Play();
        anim.SetTrigger("StartAnim");
        if (animFrag == false)
        {
            animFrag = true;
            //testAnimPlay();
        }
    }

    public void StartSelect()
    {
        anim.SetTrigger("StartAnim");
        if (animFrag == false)
        {
            animFrag = true;
            //testAnimPlay();
        }
    }

    public void ReturnAnim()
    {
        anim.SetTrigger("ReturnAnim");
    }

    //public void testAnimPlay()
    //{
    //    anim.Play("StartAnim", 0, 0.0f);
    //    animFrag = false;
    //}
}
