using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : CharacterBase
{
    [Header("移動速度")] public float moveSpeed;               // 移動速度
    [Header("召喚数")] public int summonVol;                   // 召喚数
    [Header("コスト")] public int cost;                        // コスト
    [Header("攻撃方法")] public AttackMethod myAttackMethod;   // 攻撃方法
    [SerializeField, Header("攻撃範囲")] private float attackRange = 1.5f;
    [SerializeField, Header("攻撃速度")] private float attackInterval = 1.75f;
    //[Header("特徴")] public characteristic myCharacteristic;   // 特徴

    private Vector2 enemyPos;
    private bool serchFlag = false;
    private float atackTime = 0.0f;
    private CharacterBase targetEnemy;

    //[Header("自身のカード名")] public CardType myCardType;

    //public enum CardType
    //{
    //    none = -1,
    //    infantry,
    //    infantryPlatoon,
    //    cavalry,
    //    knight,
    //    samurai,
    //    archeryCorps,
    //    ninja,
    //    cavalryGeneral,
    //    heavyKnight,
    //    monster,
    //    necromancer,
    //    ghost,
    //    thunderGod,
    //}

    public enum AttackMethod
    {
        shortDistance,
        middleDistance,
        longDistance,
    }

    //public enum characteristic // 特徴
    //{
    //    none,               // 無し
    //    quickness,          // 俊足
    //    ironWall,           // 鉄壁
    //    covert,             // 隠密
    //    explosion,          // 爆発
    //    electricShock,      // 感電
    //}

    /// <summary>
    /// キャラの移動関数
    /// </summary>
    /// <param name="speed"></param>
    public virtual void CharacterMove(float speed)
    {
        if (IsMove)
        // 敵の索敵が出来れていれば敵に近づく処理
        if (serchFlag)
        {
            // 敵との距離を測る
            var distance = Vector3.Distance(transform.position, enemyPos);
            // 攻撃範囲に入れば攻撃
            if (distance < attackRange)
            {
                Attack();
                return;
            }
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, enemyPos, speed);
        }
        else
        {
            // 索敵状態であればひたすら歩く処理
            transform.Translate(-speed, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (serchFlag) { return; }
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyTower")
        {
            // 敵のHPの情報を取得
            targetEnemy = collision.GetComponent<CharacterBase>();
            // 敵を発見したのでこれ以上他の敵と接触しないための処理
            serchFlag = true;
            // 索敵した敵のPositionを格納
            enemyPos = collision.transform.position;
        }

    }

    /*GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           
        float nearDis = 0;          
          
        GameObject targetObj = null;

        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }
        }
        Debug.Log("aaa");
        return targetObj;
    }*/

    /// <summary>
    /// 攻撃
    /// </summary>
    public override void Attack()
    {
        atackTime += Time.deltaTime;
        if (serchFlag == true && atackTime > attackInterval)
        {
            Debug.Log("攻撃");

            
            //if (targetEnemy.myCharacteristic == characteristic.ironWall)
            //{
            //    targetEnemy.hp -= 1;
            //}
            //else
            //{
            //    targetEnemy.hp -= power;
            //}
            switch (targetEnemy.myCharacteristic)
            {
                // 敵の特徴 : 無し
                // 敵の特徴 : 俊足
                // 敵の特徴 : 爆発
                // 敵の特徴 : 感電
                case characteristic.none:
                case characteristic.quickness:
                case characteristic.explosion:
                case characteristic.electricShock:
                    targetEnemy.hp -= power;
                    break;

                // 敵の特徴 : 隠密
                case characteristic.covert:
                    // 自身の攻撃方法が中距離、遠距離であれば攻撃不可
                    if (this.myAttackMethod == AttackMethod.longDistance || this.myAttackMethod == AttackMethod.middleDistance)
                    {
                        Debug.Log("隠密だから攻撃できないよ！");
                        break;
                    }
                    targetEnemy.hp -= power;
                    break;

                // 敵の特徴 : 鉄壁
                case characteristic.ironWall:
                    // 自身の特徴が俊足であれば鉄壁を無視
                    if (this.myCharacteristic == characteristic.quickness)
                    {
                        Debug.Log("鉄壁無視するよ！");
                        break;
                    }
                    targetEnemy.hp -= 1;
                    break;

                default:
                    Debug.LogError("特徴が不適切です");
                    break;
            }
            atackTime = 0f;
        }

        // 攻撃している敵が死んだら再び索敵の開始
        if (targetEnemy.IsDeath) { serchFlag = false; }
    }

    /// <summary>
    /// キャラの死亡
    /// </summary>
    public override void Death()
    {
        // 特徴が爆発ならばここで爆発をする

        IsDeath = true;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 爆発
    /// </summary>
    public void Explosion()
    {

    }
}
