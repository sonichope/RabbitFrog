using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makimonoAnim : MonoBehaviour
{
    [SerializeField] GameObject pepar;
    Animator anim;
    Animation _animation;
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

    public void Army()
    {
        //_animation.Play();
        anim.SetTrigger("StartAnim");
        if (animFrag == false)
        {
            testAnimPlay();
            animFrag = true;
            Debug.Log("testAnimPlayを呼び出せたよ");
        }
    }

    public void Select()
    {
        anim.SetTrigger("StartAnim");
        if (animFrag == false)
        {
            testAnimPlay();
            animFrag = true;
        }
    }

    public void testAnimPlay()
    {
        anim.Play("StartAnim", 0, 0.0f);
        animFrag = false;
    }
}
