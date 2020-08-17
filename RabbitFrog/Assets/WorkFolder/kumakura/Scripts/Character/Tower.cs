using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : CharacterBase
{
    void Start()
    {
        
    }

    void Update()
    {
        if (IsDeath) { return; }
        if (hp <= 0) { Death(); }
    }

    public override void Attack()
    {
        
    }

    public override void Death()
    {
        IsDeath = true;
        // 編成画面に戻るか聞くUIの表示
        gameObject.SetActive(false);
    }
}
