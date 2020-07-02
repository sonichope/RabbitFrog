using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // 条件は後々変更する
        // PCからタブレットでも動くように条件式を書き換える
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("BattleFirst");
        }
    }
}
