using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makimonoAnim : MonoBehaviour
{
    //[SerializeField] GameObject pepar;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        //anim = GetComponent(typeof(Animator)) as Animation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("StartAnim");
        }
    }

    //void ShowMakimono()
    //{
    //    anim.!Play("MakimonoanimTest");
    //    Debug.Log("aaa");
    //}
}
