using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makimono : MonoBehaviour
{
    [SerializeField] GameObject army;
    [SerializeField] GameObject armyOrganization;
    [SerializeField] GameObject select;
    [SerializeField] GameObject stageSelect;

    public Transform startMaker;
    public Transform endMaker;

    [SerializeField] private bool testFrag = true;
    [SerializeField] private bool markFrag = true;

    public float speed;

    float present_Location = 0;

    private makimonoAnim makimonoAnimation;

    void Start()
    {
        makimonoAnimation = GetComponent<makimonoAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        // testが軍編成
        if(testFrag == false)
        {
            present_Location += Time.deltaTime * speed;
            army.transform.position = Vector3.Lerp(startMaker.position, endMaker.position, present_Location);
            select.transform.position = Vector3.Lerp(endMaker.position, startMaker.position, present_Location);
            if (present_Location >= 1)
            {
                //makimonoAnimation.EndAnim();
                Debug.Log("aaaa");
                // peperのAnimation再生、軍編成が開く
                testFrag = true;
                present_Location = 1;
                //makimonoAnimation.ArmyFlag();
                makimonoAnimation.ClickArmy();
            }
            return;
        }
        // markが戦場選択
        if(markFrag == false)
        {
            //present_Location -= (Time.time * speed) / distance_two;
            present_Location -= Time.deltaTime * speed;
            //Debug.Log(present_Location);
            army.transform.position = Vector3.Lerp(startMaker.position, endMaker.position, present_Location);
            select.transform.position = Vector3.Lerp(endMaker.position, startMaker.position, present_Location);
            if (present_Location <= 0)
            {
                //makimonoAnimation.EndAnim();
                Debug.Log("bbbb");
                // peperのAnimation再生、戦場選択が開く
                markFrag = true;
                present_Location = 0;
                //makimonoAnimation.SelectFrag();
                makimonoAnimation.ClickSelect();
            }
        }
    }

    public void ArmyMakimono()
    {
        //if (present_Location > 0 || present_Location < 1) { return; }
        if (!testFrag) { return; }
        testFrag = false;
    }

    public void SelectMakimono()
    {
        //if (present_Location > 0 || present_Location < 1) { return; }
        if (!markFrag) { return; }
        markFrag = false;
    }

    public void ArmyOrganizationScale()
    {
        armyOrganization.transform.localScale = new Vector2(1, 1.25f);
        stageSelect.transform.localScale = new Vector2(1, 1);
    }

    public void StageSelectScale()
    {
        armyOrganization.transform.localScale = new Vector2(1, 1);
        stageSelect.transform.localScale = new Vector2(1, 1.25f);
    }
}
