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
        summonGageValText.text = Mathf.Floor(summonGageVal).ToString("0");

        summonGageVal = Mathf.Clamp(summonGageVal + Time.deltaTime / 3, 0.0f, 10.0f);

        // デバッグ用
        //-----------------------------------------------------------------------------

        if (Input.GetKeyDown(KeyCode.A))
        {
            summonGageVal = Mathf.Clamp(summonGageVal + 1.0f, 0.0f, 10.0f);

        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            summonGageVal = Mathf.Clamp(summonGageVal - 1.0f, 0.0f, 10.0f);
        }

        //-----------------------------------------------------------------------------

        summonGage.fillAmount = summonGageVal / 10.0f;

        #region シーン遷移
        //if (gameTime <= 0)
        //{
            
        //}
        #endregion
    }
}
