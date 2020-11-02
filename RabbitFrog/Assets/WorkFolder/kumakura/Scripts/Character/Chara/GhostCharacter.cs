using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCharacter : Character
{
    [SerializeField]
    GameObject effect;

    [SerializeField]
    Collider2D[] hitColliders;

    [SerializeField]
    float radius = 2.0f;

    void Start()
    {
    }

    void Update()
    {
        if (IsDeath) { return; }
        if (hp <= 0) { Death(); }
        CharacterMove(moveSpeed);
    }

    void LateUpdate()
    {
        hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);
    }

    public override void Death()
    {
        // ここに爆発の処理
        //イゴンヒ201030修正
        Explosion(hitColliders);      
        var test = Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(test, 2.0f);
        base.Death();
    }
}
