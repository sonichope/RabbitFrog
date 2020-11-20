using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation : OptionController
{
    [SerializeField] GameObject armyOrganization;
    [SerializeField] GameObject stageSelect;

    [SerializeField] makimonoAnim makimonoAnimation;
    //OptionController optionCon;

    Animation anim;
    Animator animator;

    private string firstAnimFlag = "FirstAnimFlag";

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animation>();
        makimonoAnimation = GetComponent<makimonoAnim>();
        animator = GetComponent<Animator>();
        //anim.GetComponent<OptionController>();
        //makimonoAnimation.GetComponent<Animation>();
        //makimono = GameObject.FindWithTag("Makimono")?.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakimonoScale()
    {
        //animator.SetTrigger("EndAnim");
        //animator.SetBool(firstAnimFlag, true);
        armyOrganization.transform.localScale = new Vector2(1, 1);
        stageSelect.transform.localScale = new Vector2(1, 1);
    }
}
