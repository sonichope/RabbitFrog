using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makimono : MonoBehaviour
{
    [SerializeField] GameObject army;
    [SerializeField] GameObject select;

    public Transform startMaker;
    public Transform endMaker;

    [SerializeField]private bool testFrag = true;
    [SerializeField]private bool markFrag = true;

    public float speed;
    //public float ax;

    private float distance_two;
    float present_Location = 0;

    // やりたい動き
    // 巻物がタップされた時のアニメーションが終了した時
    // 下の OpenMakimono(CloseMakimono) の動きをする
    // OpenMakimono が実行される時 pepar のアニメーションを実行する
    // 「この時巻物がタップされる度に pepar のアニメーションを繰り返し実行する」
    // タップされた巻物を画面の中央の方に持ってくる
    // 2つの巻物のpositionを入れ替える時
    // 2つの巻物を回転させるように入れ替える動きをつける(太鼓の達人の選択するところのように)

    void Start()
    {
        //move_Position = startMaker.transform.position;
        //toGoPoint = endMaker.transform.position;
        distance_two = Vector3.Distance(startMaker.position, endMaker.position);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(present_Location);
        if(testFrag == false)
        {
            //present_Location += (Time.time * speed) / distance_two;
            present_Location += speed;
            //Debug.Log(present_Location);
            army.transform.position = Vector3.Lerp(startMaker.position, endMaker.position, present_Location);
            select.transform.position = Vector3.Lerp(endMaker.position, startMaker.position, present_Location);
            if (present_Location >= 1)
            {
                // peperのAnimation再生
                testFrag = true;
                present_Location = 1;
            }
        }
        if(markFrag == false)
        {
            //present_Location -= (Time.time * speed) / distance_two;
            present_Location -= speed;
            //Debug.Log(present_Location);
            army.transform.position = Vector3.Lerp(startMaker.position, endMaker.position, present_Location);
            select.transform.position = Vector3.Lerp(endMaker.position, startMaker.position, present_Location);
            if (present_Location <= 0)
            {
                // peperのAnimation再生
                markFrag = true;
                present_Location = 0;
            }
        }
    }

    public void OpenMakimono()
    {
        //if (present_Location > 0 || present_Location < 1) { return; }
        testFrag = false;
        //Makia.transform.localPosition += new Vector3(ax, 0, 0);
        //Makib.transform.localPosition += new Vector3(-ax, 0, 0);
        //move_Position.x -= speed;
        //startMaker.transform.position = move_Position;
        //Makia.transform.localPosition = new Vector2(260, 0);
        //Makib.transform.localPosition = new Vector2(350, 0);
        army.transform.localScale = new Vector2(1, 1.25f);
        select.transform.localScale = new Vector2(1, 1);
        
    }

    public void CloseMakimono()
    {
        //if (present_Location > 0 || present_Location < 1) { return; }
        markFrag = false;
        //Makia.transform.localPosition += new Vector3(-ax, 0, 0);
        //Makib.transform.localPosition += new Vector3(ax, 0, 0);
        //transform.localPosition = new Vector2(260, 0);
        //Makia.transform.localPosition = new Vector2(350, 0);
        army.transform.localScale = new Vector2(1, 1);
        select.transform.localScale = new Vector2(1, 1.25f);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //}
}
