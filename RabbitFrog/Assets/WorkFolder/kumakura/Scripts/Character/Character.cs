using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : CharacterBase
{
    [Header("移動速度")] public float moveSpeed;               // 移動速度
    [Header("召喚数")] public int summonVol;                   // 召喚数
    [Header("コスト")] public int cost;                        // コスト

    [SerializeField, Header("攻撃範囲")] private float attackRange = 1.5f;
    private Vector2 enemyPos;
    private bool serchFlag = false;
    private float time = 0.0f;
    [SerializeField, Header("攻撃間隔")] private float attackInterval = 1.75f;
    private CharacterBase targetEnemy;

    //[Header("特徴")] public characteristic myCharacteristic;   // 特徴

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
    /// キャラの特徴
    /// </summary>
    public virtual void Characteristic()
    {

    }

    /// <summary>
    /// キャラの移動関数
    /// </summary>
    /// <param name="speed"></param>
    public void CharacterMove(float speed)
    {
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
        if (collision.gameObject.tag == "Enemy")
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
        time += Time.deltaTime;
        if (serchFlag == true && time > attackInterval)
        {
            targetEnemy.hp -= power;
            Debug.Log("残りHP:" + targetEnemy.hp);
            time = 0f;
        }

        // 攻撃している敵が死んだら再び索敵の開始
        if (targetEnemy.IsDeath) { serchFlag = false; }
    }

    /// <summary>
    /// キャラの死亡
    /// </summary>
    public override void Death()
    {
        IsDeath = true;
        gameObject.SetActive(false);
    }
}
