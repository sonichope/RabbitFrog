using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour
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
            // とりあえずBattleFirstのみ
            // 今後は条件に応じてシーン遷移の分岐
            // クリアして先に進む場合は次のBattleへ
            // BattleThirdでクリアした場合ClearSceneへ
            SceneManager.LoadScene("ClearScene");
        }

        if (Input.GetMouseButtonDown(1))
        {
            // クリアして次に進まない場合
            SceneManager.LoadScene("OptionScene");
        }
    }
}
