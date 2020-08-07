using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCharacter : Character
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDeath) { return; }
        if (hp <= 0) { Death(); }
        CharacterMove(moveSpeed);
    }

    public override void Death()
    {
        // ここに爆発の処理
        base.Death();
    }
}
