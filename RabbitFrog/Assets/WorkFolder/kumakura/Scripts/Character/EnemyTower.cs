using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTower : Enemy
{
    void Start()
    {
        
    }

    void Update()
    {
        if (IsDeath) { return; }
        if (hp <= 0) { Death(); }
        if (serchFlag)
        {
            // 敵との距離を測る
            var distance = Vector3.Distance(transform.position, characterPos);
            // 攻撃範囲に入れば攻撃
            if (distance < attackRange)
            {
                Attack();
            }
        }
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public override void Death()
    {
        IsDeath = true;
        gameObject.SetActive(false);
        //WGameSceneManager.LoadClearScene();
    }
}
