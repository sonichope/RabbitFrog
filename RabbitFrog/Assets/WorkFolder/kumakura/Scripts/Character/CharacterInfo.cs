using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    [Header("キャラクター画像")] public Sprite image;          // キャラクター画像
    [Header("名前")] public charaname myName;                  // 名前
    [Header("体力")] public int hp;                            // 体力
    [Header("攻撃力")] public int power;                       // 攻撃力
    [Header("移動速度")] public int moveSpeed;                 // 移動速度
    [Header("召喚数")] public int summonVol;                   // 召喚数
    [Header("コスト")] public int cost;                        // コスト
    [Header("攻撃方法")] public attackMethod myAttackMethod;   // 攻撃方法
    [Header("攻撃範囲")] public attackRange myAttackRange;     // 攻撃範囲
    [Header("攻撃速度")] public attackSpeed myAttackSpeed;     // 攻撃速度
    [Header("特徴")] public characteristic myCharacteristic;   // 特徴

    public enum charaname     // 名前
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

    public enum attackMethod  // 攻撃方法
    {
        shortDistance,      // 近距離
        mediumDistance,     // 中距離
        longDistance,       // 遠距離
    }
    
    public enum attackRange   // 攻撃範囲
    {
        small,              // 小
        large,              // 大
    }

    public enum attackSpeed   // 攻撃速度
    {
        slow,               // 遅い
        usually,            // 普通
        fast,               // 速い
    }

    public enum characteristic // 特徴
    {
        none,               // 無し
        quickness,          // 俊足
        ironWall,           // 鉄壁
        covert,             // 隠密
        explosion,          // 爆発
        electricShock,      // 感電
    }
}
