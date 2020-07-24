using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioTextControl : MonoBehaviour
{
    [SerializeField] private string[] sentence; // シナリオを格納する箱
    [SerializeField] private Text uiText;       // 

    [SerializeField, Range(0.01f, 0.3f)]
    float intervalForCharacterDisplay = 0.05f;  // １文字の表示にかかる時間
    
    private int currentLine = 0;
    private string currentText = string.Empty;  // 現在の文字列
    private float timeUntilDisplay = 0;         // 表示にかかる時間
    private float timeElapsed = 1;              // 文字列の表示を開始した時間
    private int lastUpdateCharacter = -1;       // 表示中の文字列

    // 文字の表示が完了しているかどうか
    public bool IsCompleteDisplayText
    {
        get { return Time.time > timeElapsed + timeUntilDisplay; }
    }


    void Start()
    {
        SetNextLine();
    }

    void Update()
    {
        if (currentLine == sentence.Length && Input.GetMouseButtonDown(0))
        {
            GameSceneManager.LoadOptionScene();
        }

        if (IsCompleteDisplayText)
        {
            if (currentLine < sentence.Length && Input.GetMouseButtonDown(0))
            {
                SetNextLine();
            }
        }
        else
        {
            // 完了していない文字をすべて表示する
            if (Input.GetMouseButtonUp(0))
            {
                timeUntilDisplay = 0;
            }
        }


        // クリックから経過した時間が想定表示時間の何％か確認し、表示文字数を出す
        int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);

        // 表示文字数が前回の表示文字数と異なるならテキストを更新する
        if (displayCharacterCount != lastUpdateCharacter)
        {
            uiText.text = currentText.Substring(0, displayCharacterCount);
            lastUpdateCharacter = displayCharacterCount;
        }
    }

    private void SetNextLine()
    {
        currentText = sentence[currentLine];
        currentLine++;

        // 想定表示時間と現在の時刻をキャッシュ
        timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
        timeElapsed = Time.time;

        // 文字カウントを初期化
        lastUpdateCharacter = -1;
    }
}
