﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ConfirmCanvas : MonoBehaviour
{
    [SerializeField]
    Effect_Sketch effect_sketch;

    Canvas confirmCanvas;
    // Start is called before the first frame update
    void Start()
    {
        confirmCanvas = GetComponent<Canvas>();
    }

    public void NextScene()
    {
         StartCoroutine(effect_sketch.NextScene(StageSelectControl.NextScene));
        confirmCanvas.rootCanvas.enabled = !confirmCanvas.rootCanvas.enabled;
    }

    public void Cencle()
    {
        confirmCanvas.rootCanvas.enabled = !confirmCanvas.rootCanvas.enabled;
    }
}
