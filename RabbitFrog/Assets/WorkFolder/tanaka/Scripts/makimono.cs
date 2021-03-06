﻿using System.Collections;
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

    [SerializeField] private bool testFlag = true;
    [SerializeField] private bool markFlag = true;
    public bool test = false;
    public bool mark = false;

    // 軍編成が開いているかどうかのFlag管理のプロパティー
    public bool GetTestFlag { get { return testFlag; } }
    // 戦場選択が開いているかどうかのFlag管理のプロパティー
    public bool GetMarkFlag { get { return markFlag; } }

    public float speed;
    float present_Location = 1;

    makimonoAnim makimonoAnimation;

    void Start()
    {
        makimonoAnimation = GetComponent<makimonoAnim>();
        makimonoAnimation.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(testFlag + " / " + markFlag);
        Debug.Log(test + " / " + mark);
        // testが軍編成
        if (testFlag == false)
        {
            present_Location += Time.deltaTime * speed;
            //if (present_Location <= 0)
            //{
            // 軍編成のposition移動makerが配置されている場所まで
            army.transform.position = Vector3.Lerp(startMaker.position, endMaker.position, present_Location);
            // 戦場選択…(上に同じく)　Leap…0と1なら移動できる
            select.transform.position = Vector3.Lerp(endMaker.position, startMaker.position, present_Location);
            //}
            if (present_Location >= 1)
            {
                // paperのAnimation再生、軍編成が開く
                testFlag = true;
                test = !test;
                test = true;
                present_Location = 1;
                //makimonoAnimation.ArmyFlag();
                //makimonoAnimation.ClickArmy();
            }
        }
        // markが戦場選択
        else if (markFlag == false)
        {
            present_Location -= Time.deltaTime * speed;
            //if (present_Location <= 0)
            //{
            army.transform.position = Vector3.Lerp(startMaker.position, endMaker.position, present_Location);
            select.transform.position = Vector3.Lerp(endMaker.position, startMaker.position, present_Location);
            //}
            if (present_Location <= 0)
            {
                // paperのAnimation再生、戦場選択が開く
                markFlag = true;
                mark = !mark;
                mark = true;
                present_Location = 0;
                //makimonoAnimation.SelectFrag();
                //makimonoAnimation.ClickSelect();
            }
        }
    }

    public void ArmyMakimono()
    {
        //if (present_Location > 0 || present_Location < 1) { return; }
        if (!testFlag) { return; }
        testFlag = false;
    }

    public void SelectMakimono()
    {
        //if (present_Location > 0 || present_Location < 1) { return; }
        if (!markFlag) { return; }
        markFlag = false;
    }

    public void ArmyOrganizationScale()
    {
        armyOrganization.transform.localScale = new Vector2(1, 1.43f);
        stageSelect.transform.localScale = new Vector2(1, 1);
    }

    public void StageSelectScale()
    {
        armyOrganization.transform.localScale = new Vector2(1, 1);
        stageSelect.transform.localScale = new Vector2(1, 1.43f);
    }
}
