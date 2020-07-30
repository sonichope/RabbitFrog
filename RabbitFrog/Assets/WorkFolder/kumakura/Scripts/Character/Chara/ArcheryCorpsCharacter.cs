using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcheryCorpsCharacter : Character
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDeath) { return; }
        CharacterMove(moveSpeed);
    }
}
