using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnBeginDrag()
    {
        Debug.Log("ドラッグした");
    }

    public void OnEndDrag()
    {
        Debug.Log("離した");
    }
}
