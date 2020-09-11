using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class makimono : MonoBehaviour
{
    [SerializeField] GameObject Makia;
    //[SerializeField] GameObject pepar;
    [SerializeField] GameObject Makib;
    //public bool makiFrag = true;
    //[SerializeField] GameObject Peperb;
    //Animation anim;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void OpenMakimono()
    {
        Makia.transform.localScale = new Vector2(1, 1.25f);
        Makia.transform.localPosition = new Vector2(260, 0);
        Makib.transform.localScale = new Vector2(1, 1);
        Makib.transform.localPosition = new Vector2(350, 0);
    }

    public void CloseMakimono()
    {
        Makib.transform.localScale = new Vector2(1, 1.25f);
        Makib.transform.localPosition = new Vector2(260, 0);
        Makia.transform.localScale = new Vector2(1, 1);
        Makia.transform.localPosition = new Vector2(350, 0);
    }

    void isCanvasEnable()
    {

    }
}
