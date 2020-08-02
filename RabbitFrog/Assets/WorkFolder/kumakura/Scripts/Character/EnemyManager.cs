using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemyの生成などを管理
public class EnemyManager : MonoBehaviour
{
    // 生成したい敵Objectのリスト
    public GameObject[] createEnemyList;
    
    private float time = 0f;
    private float summonInterval = 3.0f;


    void Start()
    {
        
    }

    void Update()
    {
        RandomSummon();
    }

    private void RandomSummon()
    {
        time += Time.deltaTime;
        if (time > summonInterval)
        {
            time = 0;
            // 召喚場所の可視化を出来るようにする
            float pos_x = Random.Range(-4.5f, -1.0f);
            float pos_y = Random.Range(-2.0f, 2.0f);
            int randomSummonNum = Random.Range(0, createEnemyList.Length);
            Instantiate(createEnemyList[randomSummonNum], new Vector3(pos_x, pos_y, 0), Quaternion.identity);
        }
    }
}
