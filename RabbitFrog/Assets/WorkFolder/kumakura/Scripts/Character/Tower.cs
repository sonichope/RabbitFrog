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
        if (hp <= 0) { Death(); }
    }

    /// <summary>
    /// 攻撃
    /// </summary>
    public override void Attack()
    {
        
    }
    
    /// <summary>
    /// 死亡
    /// </summary>
    public override void Death()
    {
        IsDeath = true;
        gameObject.SetActive(false);
        GameSceneManager.LoadClearScene();
    }
}
