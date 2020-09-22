using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase
{
    [Header("移動速度")] public float moveSpeed;               // 移動速度
    [Header("召喚数")] public int summonVol;                   // 召喚数
    [Header("攻撃方法")] public AttackMethod myAttackMethod;   // 攻撃方法
    [Header("攻撃範囲")] public float attackRange = 1.5f;
    [SerializeField, Header("攻撃速度")] private float attackInterval = 1.75f;

    public bool targetFlag = false;

    protected Vector2 characterPos;
    protected bool serchFlag = false;
    protected float time = 0.0f;
    protected CharacterBase targetCharacter;

    public enum AttackMethod
    {
        shortDistance,
        middleDistance,
        longDistance,
    }

    public void EnemyMove(float speed)
    {
        if (IsMove)
        if (serchFlag)
        {
            var distance = Vector3.Distance(transform.position, characterPos);
            if (distance < attackRange)
            {
                Attack();
                return;
            }
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, characterPos, speed);
        }
        else
        {
            transform.Translate(speed, 0f, 0f);
        }
    }

    public override void Attack()
    {
        time += Time.deltaTime;
        if (serchFlag && time > attackInterval)
        {
            targetCharacter.hp -= power;
            time = 0f;
        }

        if (targetCharacter.IsDeath) { serchFlag = false; }
    }

    public override void Death()
    {
        IsDeath = true;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (serchFlag) { return; }
        if (collision.gameObject.tag == "Character")
        {
            targetCharacter = collision.GetComponent<CharacterBase>();
            serchFlag = true;
            characterPos = collision.transform.position;
        }
    }
}
