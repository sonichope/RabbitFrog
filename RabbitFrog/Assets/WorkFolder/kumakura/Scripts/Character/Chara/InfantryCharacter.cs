using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfantryCharacter : Character
{
    void Start()
    {
        
    }

    void Update()
    {
        if (IsDeath) { return; }
    }

    //public override void Death()
    //{
    //    base.Death();
    //}
}
