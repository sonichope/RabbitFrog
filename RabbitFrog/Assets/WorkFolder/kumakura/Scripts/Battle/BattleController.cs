using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour
{
    [SerializeField] private float gameTime = 90;   // 残り時間
    [SerializeField] private Text timeText;
    [SerializeField] private Image summonGage;
    [SerializeField] private Text summonGageValText;

    private float summonGageVal = 5.0f;     // 召喚ゲージ　: 最大は10
    public float SummonGageVal
    {
        get { return summonGageVal; }
        set { summonGageVal = value; }
    }

    void Start()
    {

    }

    void Update()
    {
        gameTime -= Time.deltaTime;
        timeText.text = gameTime.ToString("00");
        summonGageValText.text = summonGageVal.ToString("0");

        summonGageVal = Mathf.Clamp(summonGageVal + Time.deltaTime / 3, 0.0f, 10.0f);

        // デバッグ用
        //-----------------------------------------------------------------------------

        if (Input.GetKeyDown(KeyCode.A))
        {
            summonGageVal = Mathf.Clamp(summonGageVal + 1.0f, 0.0f, 10.0f);
            //for (int i = 0; i < DeckManager.deckObjects.Length; i++)
            //{
            //    Debug.Log(DeckManager.deckObjects[i].cardPoolObject.myCardType);
            //}
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            summonGageVal = Mathf.Clamp(summonGageVal - 1.0f, 0.0f, 10.0f);
        }

        //-----------------------------------------------------------------------------

        summonGage.fillAmount = summonGageVal / 10.0f;

        #region シーン遷移
        // 条件は後々変更する
        // PCからタブレットでも動くように条件式を書き換える
        if (Input.GetMouseButtonDown(0))
        {
            // とりあえずBattleFirstのみ
            // 今後は条件に応じてシーン遷移の分岐
            // クリアして先に進む場合は次のBattleへ
            // BattleThirdでクリアした場合ClearSceneへ
            //SceneManager.LoadScene("ClearScene");
        }

        if (Input.GetMouseButtonDown(1))
        {
            // クリアして次に進まない場合
            //SceneManager.LoadScene("OptionScene");
        }
        #endregion
    }
}
