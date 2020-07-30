using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Character : CharacterBase
{
    [Header("移動速度")] public float moveSpeed;               // 移動速度
    [Header("召喚数")] public int summonVol;                   // 召喚数
    [Header("コスト")] public int cost;                        // コスト

    private GameObject nearObj;
    private GameObject homingObj;
    private GameObject Player;
    private GameObject atkObj;
    //[SerializeField] private Transform enemy;
    [SerializeField] private float speed;
    [SerializeField] private float Distance;
    //[SerializeField] private float moveDistance;
    //private int health;
    private Vector2 enemyPos;
    private bool serchFlag = false;
    private bool attackFlag = false;
    private float time = 30.0f;
 
    void Start()
    {
        nearObj = serchTag(gameObject, "Enemy");
        homingObj = GameObject.FindGameObjectWithTag("Enemy");
        //Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        
    }

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
        if (serchFlag)
        {
            // if (distance >= attackRenge)  ==> 下の処理を呼ぶ
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, enemyPos * 0, 0.0f * Time.deltaTime);
        }
        else
        {
            transform.Translate(-speed, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (serchFlag) { return; }
        //if (attackFlag) { return; }
        if (collision.gameObject.tag == "Enemy")
        {
            //attackFlag = true;
            serchFlag = true;
            enemyPos = collision.transform.position;

            nearObj = serchTag(gameObject, "Enemy");
            Debug.Log("敵だ！！");
            Debug.Log(gameObject.transform.position);
        }
        //print(timer);
    }

    GameObject serchTag(GameObject nowObj, string tagName)
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
    }

    public override void Attack()
    {
        // 攻撃
        // overrideで細かい攻撃方法追加
    }

    /// <summary>
    /// キャラの死亡
    /// </summary>
    public override void Death()
    {
        if (serchFlag == true && time == 0.0f)
        {
            IsDeath = true;
            gameObject.SetActive(false);
        }
    }
}
