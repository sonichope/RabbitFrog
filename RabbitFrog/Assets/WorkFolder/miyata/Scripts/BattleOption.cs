using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleOption : MonoBehaviour
{
    [SerializeField]
    GameObject BOC;
    [SerializeField]
    GameObject BOC2;
    [SerializeField]
    GameObject BOC3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void BOC4()
    {
        BOC.SetActive(false);
        BOC2.SetActive(true);
       
       
    }

    public void BOC5()
    {
        BOC.SetActive(false);
        BOC3.SetActive(true);
        if(Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 0;
        }
       
    }

    public void BOC6()
    {
        BOC.SetActive(true);
        BOC2.SetActive(false);
        BOC3.SetActive(false);
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1.0f;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
