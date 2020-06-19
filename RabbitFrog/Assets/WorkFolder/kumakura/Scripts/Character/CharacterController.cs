using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CharacterController : CharacterInfo
{
    void Start()
    {
        AttackMethod(myAttackMethod);
        AttackRange(myAttackRange);
        AttackSpeed(myAttackSpeed);
        CharaCharacteristic(myCharacteristic);
    }

    void Update()
    {
        if (hp <= 0)
        {
            enabled = false;
        }
    }


    /// <summary>
    /// 攻撃方法
    /// </summary>
    /// <param name="atkMethod">攻撃方法</param>
    public void AttackMethod(attackMethod atkMethod)
    {
        switch (atkMethod)
        {
            case attackMethod.shortDistance:
                // 攻撃方法　小設定
                break;

            case attackMethod.mediumDistance:
                // 攻撃方法　中設定
                break;

            case attackMethod.longDistance:
                // 攻撃方法　大設定
                break;
        }
    }

    /// <summary>
    /// 攻撃範囲
    /// </summary>
    /// <param name="atkRebge">攻撃範囲</param>
    public void AttackRange(attackRange atkRebge)
    {
        switch (atkRebge)
        {
            case attackRange.small:
                // 攻撃範囲　小設定
                break;

            case attackRange.large:
                // 攻撃範囲　大設定
                break;
        }
    }

    /// <summary>
    /// 攻撃速度
    /// </summary>
    /// <param name="atkSpeed">攻撃速度</param>
    public void AttackSpeed(attackSpeed atkSpeed)
    {
        switch (atkSpeed)
        {
            case attackSpeed.slow:
                // 攻撃速度　遅い設定
                break;

            case attackSpeed.usually:
                // 攻撃速度　普通設定
                break;

            case attackSpeed.fast:
                // 攻撃速度　速い設定
                break;
        }
    }

    /// <summary>
    /// 特徴
    /// </summary>
    /// <param name="atkCharacteristic">特徴</param>
    public void CharaCharacteristic(characteristic atkCharacteristic)
    {
        switch (atkCharacteristic)
        {
            case characteristic.none:
                // 特徴　無し設定
                break;
            
            case characteristic.quickness:
                // 特徴　俊足設定
                break;

            case characteristic.ironWall:
                // 特徴　鉄壁設定
                break;
            
            case characteristic.covert:
                // 特徴　隠密設定
                break;
            
            case characteristic.explosion:
                // 特徴　爆発設定
                break;
            
            case characteristic.electricShock:
                // 特徴　感電設定
                break;
        }
    }


}
