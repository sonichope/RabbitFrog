using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour
{
    [SerializeField] private float gameTime = 90;   // 残り時間
    [SerializeField] private Text timeText;

    private int summonGage = 5;     // 召喚ゲージ　: 最大は10

    void Start()
    {
        
    }

    void Update()
    {
        gameTime -= Time.deltaTime;
        timeText.text = gameTime.ToString("00");

        #region シーン遷移
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
        #endregion
    }
}
