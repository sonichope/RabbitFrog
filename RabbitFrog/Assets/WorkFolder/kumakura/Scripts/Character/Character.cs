using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : CharacterBase
{
    [Header("移動速度")] public float moveSpeed;               // 移動速度
    [Header("召喚数")] public int summonVol;                   // 召喚数
    [Header("コスト")] public int cost;                        // コスト
    //[Header("特徴")] public characteristic myCharacteristic;   // 特徴
    
    //public enum characteristic // 特徴
    //{
    //    none,               // 無し
    //    quickness,          // 俊足
    //    ironWall,           // 鉄壁
    //    covert,             // 隠密
    //    explosion,          // 爆発
    //    electricShock,      // 感電
    //}

    /// <summary>
    /// キャラの特徴
    /// </summary>
    public virtual void Characteristic()
    {

    }

    /// <summary>
    /// キャラの移動関数
    /// </summary>
    /// <param name="speed"></param>
    public void CharacterMove(float speed)
    {
        
    }

    public override void Attack()
    {
        // 攻撃
        // overrideで細かい攻撃方法追加
    }

    public override void Death()
    {
        Debug.Log("aaa");
    }
}
