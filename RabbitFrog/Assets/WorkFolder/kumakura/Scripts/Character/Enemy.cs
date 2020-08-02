using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase
{
    [Header("移動速度")] public float moveSpeed;               // 移動速度
    [Header("召喚数")] public int summonVol;                   // 召喚数

    private float attackRange;
    private Vector2 characterPos;
    private bool serchFlag = false;
    private float time = 0.0f;
    private float interval;
    private CharacterBase targetCharacter;

    public override void Attack()
    {
        // targetCharacterのHPを減らす処理
    }

    public override void Death()
    {
        IsDeath = true;
        gameObject.SetActive(false);
    }
}
