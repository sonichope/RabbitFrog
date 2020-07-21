using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioTextControl : MonoBehaviour
{
    [SerializeField] private string[] sentence; // シナリオを格納する箱
    [SerializeField] private Text uiText;       // 
    private int nowLineNum = 0;                 // 現在の行番号


    void Start()
    {
        TextUpdate();
    }

    void Update()
    {
        // 現在の行番号が最後まで行ってない状態でクリックすると、テキストを更新する
        if (nowLineNum < sentence.Length && Input.GetMouseButtonDown(0))
        {
            TextUpdate();
        }
    }

    private void TextUpdate()
    {
        uiText.text = sentence[nowLineNum];     // 現在の行のシナリオを表示
        nowLineNum++;                           // 次の行番号へ
    }
}
