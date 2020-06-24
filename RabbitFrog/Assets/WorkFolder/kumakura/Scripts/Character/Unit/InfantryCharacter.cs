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
        
    }

    public override void Death()
    {
        base.Death();
        gameObject.SetActive(false);
    }
}
