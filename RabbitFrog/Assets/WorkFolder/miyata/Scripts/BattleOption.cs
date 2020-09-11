using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleOption : MonoBehaviour
{
    [SerializeField]
    GameObject BattleOptionController;
    [SerializeField]
    GameObject BattleOptionController2;
    [SerializeField]
    GameObject BattleOptionController3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void active()
    {
        BattleOptionController.SetActive(false);
        BattleOptionController2.SetActive(true);
       
       
    }

    public void timestop()
    {
        BattleOptionController.SetActive(false);
        BattleOptionController3.SetActive(true);
        if(Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 0;
        }
       
    }

    public void timestart()
    {
        BattleOptionController.SetActive(true);
        BattleOptionController2.SetActive(false);
        BattleOptionController3.SetActive(false);
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
