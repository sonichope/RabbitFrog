﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation : MonoBehaviour
{
    [SerializeField] GameObject armyOrganization;
    [SerializeField] GameObject stageSelect;

    private makimonoAnim makimonoAnimation;
    Transform makimono;

    // Start is called before the first frame update
    void Start()
    {
        makimonoAnimation = GetComponent<makimonoAnim>();
        //makimonoAnimation.GetComponent<Animation>();
        //makimono = GameObject.FindWithTag("Makimono")?.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MakimonoScale()
    {
        armyOrganization.transform.localScale = new Vector2(1, 1);
        stageSelect.transform.localScale = new Vector2(1, 1);
    }
}