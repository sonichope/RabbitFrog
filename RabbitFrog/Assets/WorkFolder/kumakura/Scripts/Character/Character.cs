using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField, Header("名前")] private charaname myName;                  // 名前
    [SerializeField, Header("体力")] private int hp;                            // 体力
    [SerializeField, Header("攻撃力")] private int power;                       // 攻撃力
    [SerializeField, Header("移動速度")] private int moveSpeed;                 // 移動速度
    [SerializeField, Header("召喚数")] private int summonVol;                   // 召喚数
    [SerializeField, Header("コスト")] private int cost;                        // コスト
    [SerializeField, Header("攻撃方法")] private attackMethod myAttackMethod;   // 攻撃方法
    [SerializeField, Header("攻撃範囲")] private attackRange myAttackRange;     // 攻撃範囲
    [SerializeField, Header("攻撃速度")] private attackSpeed myAttackSpeed;     // 攻撃速度
    [SerializeField, Header("特徴")] private characteristic myCharacteristic;   // 特徴

    private enum charaname     // 名前
    {
        歩兵,
        歩兵小隊,
        騎兵,
        騎士,
        侍,
        弓術隊,
        忍者,
        騎将,
        重騎士,
        怪物,
        死霊術師,
        雷神,
    }

    private enum attackMethod  // 攻撃方法
    {
        shortDistance,      // 近距離
        mediumDistance,     // 中距離
        longDistance,       // 遠距離
    }
    
    private enum attackRange   // 攻撃範囲
    {
        small,              // 小
        large,              // 大
    }

    private enum attackSpeed   // 攻撃速度
    {
        slow,               // 遅い
        usually,            // 普通
        fast,               // 速い
    }

    private enum characteristic // 特徴
    {
        none,               // 無し
        quickness,          // 俊足
        ironWall,           // 鉄壁
        covert,             // 隠密
        explosion,          // 爆発
        electricShock,      // 感電
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
