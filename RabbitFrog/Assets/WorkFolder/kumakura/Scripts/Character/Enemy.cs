using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase
{
    [Header("移動速度")] public float moveSpeed;               // 移動速度
    [Header("召喚数")] public int summonVol;                   // 召喚数

    [SerializeField, Header("攻撃範囲")] private float attackRange = 1.5f;
    private Vector2 characterPos;
    private bool serchFlag = false;
    private float time = 0.0f;
    [SerializeField, Header("攻撃間隔")] private float attackInterval = 1.75f;
    private CharacterBase targetCharacter;


    public void EnemyMove(float speed)
    {
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
            Debug.Log("残り味方HP:" + targetCharacter.hp);
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
