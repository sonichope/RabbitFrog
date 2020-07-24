using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnBeginDrag()
    {
        Debug.Log("ドラッグした");
        // ここで何を召喚するか判断する
    }

    public void OnEndDrag()
    {
        Debug.Log("離した");
        // 判断したキャラクターを召喚する
        // 召喚した後にImageを次のキャラクターに切り替える
        // DeckObjectからDeckManagerクラスにセットしたキャラクターを報告する
        // staticの使用を考える
    }
}
