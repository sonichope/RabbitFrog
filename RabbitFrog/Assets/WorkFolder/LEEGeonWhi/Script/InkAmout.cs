using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InkAmout : MonoBehaviour
{
    public static Image image;

    void Start()
    {
        image = GetComponent<Image>();
        image.fillAmount = 1.0f;
    }

    /// <summary>
    /// インクの残量が減らす
    /// </summary>
    static public void decrease_Gauge(float amount)
    {
        if (image.fillAmount <= 0) return;
            image.fillAmount -= amount; 
    }

    /// <summary>
    /// インクの残量が上がる
    /// </summary>
    /// <param name="amount"></param>
    static public void increase_Gauge(float amount)
    {
        if (image.fillAmount >= 1) return;
        image.fillAmount += amount;
    }

    /// <summary>
    /// インクの残り残量をチェック
    /// </summary>
    /// <returns></returns>
    static public bool inkChack()
    {
        if (image.fillAmount <= 0) return false;
        else return true;
    }
}
