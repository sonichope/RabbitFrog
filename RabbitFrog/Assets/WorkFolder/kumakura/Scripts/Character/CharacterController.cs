using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CharacterController : CharacterBase
{
    CircleCollider2D attackRengeCol;


    void Start()
    {
        AttackMethod(myAttackMethod);
        AttackRange(myAttackRange);
        AttackSpeed(myAttackSpeed);
        CharaCharacteristic(myCharacteristic);
        SetCharacterImage(image);

    }

    void Update()
    {
        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    /*--------------------------------------------------------------------------
    
    「索敵範囲」に入った敵に近づいて攻撃をする
     この時、「攻撃方法」によって攻撃開始する距離が決まる
    「攻撃範囲」は攻撃開始距離に入ったときに誰に攻撃するか
    「攻撃速度」は次の攻撃までの時間

     --------------------------------------------------------------------------*/

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
                return;

            case attackMethod.mediumDistance:
                // 攻撃方法　中設定
                return;

            case attackMethod.longDistance:
                // 攻撃方法　大設定
                return;
        }
    }

    /// <summary>
    /// 攻撃範囲
    /// </summary>
    /// <param name="atkRenge">攻撃範囲</param>
    public void AttackRange(attackRange atkRenge)
    {
        attackRengeCol = GetComponent<CircleCollider2D>();
        switch (atkRenge)
        {
            case attackRange.small:
                // 攻撃範囲　小設定
                attackRengeCol.radius = 1.0f;
                return;

            case attackRange.large:
                // 攻撃範囲　大設定
                attackRengeCol.radius = 3.0f;
                return;
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
                return;

            case attackSpeed.usually:
                // 攻撃速度　普通設定
                return;

            case attackSpeed.fast:
                // 攻撃速度　速い設定
                return;
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
                return;
            
            case characteristic.quickness:
                // 特徴　俊足設定
                return;

            case characteristic.ironWall:
                // 特徴　鉄壁設定
                return;
            
            case characteristic.covert:
                // 特徴　隠密設定
                return;
            
            case characteristic.explosion:
                // 特徴　爆発設定
                return;
            
            case characteristic.electricShock:
                // 特徴　感電設定
                return;
        }
    }

    /// <summary>
    /// 画像配置
    /// </summary>
    /// <param name="image">画像</param>
    private void SetCharacterImage(Sprite image)
    {
        GetComponent<SpriteRenderer>().sprite = image;
    }

}
