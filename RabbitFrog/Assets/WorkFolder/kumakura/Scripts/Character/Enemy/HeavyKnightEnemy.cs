﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyKnightEnemy : Enemy
{
    void Start()
    {
        
    }

    void Update()
    {
        if (IsDeath) { return; }
        if (hp <= 0) { Death(); }
        EnemyMove(moveSpeed);
    }
}
