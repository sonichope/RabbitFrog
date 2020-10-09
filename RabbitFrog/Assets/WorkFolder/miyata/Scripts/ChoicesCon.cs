using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesCon : MonoBehaviour
{
    [SerializeField]
    GameObject ChoicesController;
    [SerializeField]
    GameObject ChoicesController2;
    [SerializeField]
    GameObject ChoicesController3;
    

    // Start is called before the first frame update
    void Start()
    {
         
    }

    public void active()
    {
        ChoicesController.SetActive(true);
        ChoicesController2.SetActive(false);
    }

    public void Retire()
    {
        ChoicesController2.SetActive(false);
        ChoicesController3.SetActive(true);
    }
}
