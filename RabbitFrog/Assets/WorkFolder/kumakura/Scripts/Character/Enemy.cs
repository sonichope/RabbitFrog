using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase
{
    [Header("移動速度")] public float moveSpeed;               // 移動速度
    [Header("召喚数")] public int summonVol;                   // 召喚数
    [Header("コスト")] public int cost;                        // コスト

    private float attackRange;
    private Vector2 characterPos;
    private bool serchFlag = false;
    private float time = 0.0f;
    private float interva;

    public override void Attack()
    {
        
    }

    public override void Death()
    {
        IsDeath = true;
        gameObject.SetActive(false);
    }
}
