using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionController : MonoBehaviour
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
            // 遷移するシーンはBattleシーン完成後に変更すること
            //SceneManager.LoadScene("BattleFirst");
        }
    }

    public void OnOpenOrganization()
    {
        Debug.Log("aaa");
    }

    public void OnOpenStageSelect()
    {
        Debug.Log("bbb");
    }
}
