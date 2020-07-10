using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerDeta : CharacterDeta
{


    public TowerDeta()
    {
        name = "";
        hp = maxHp;
        maxHp = 1000;
        power = 1;
    }
}
