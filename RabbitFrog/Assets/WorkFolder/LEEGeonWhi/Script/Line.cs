using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public float lineLength;
    public float HP;

    private BoxCollider2D Box_col;
    private bool Check_Overlap;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        //StartCoroutine(obj_destroy());
        StartCoroutine(Change_Overlap());
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            InkAmout.increase_Gauge(0.1f);
            Destroy(gameObject);
        }
    }

    void Init()
    {
        Box_col = gameObject.AddComponent<BoxCollider2D>();
        Box_col.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy" && Check_Overlap == false)
        {
            HP -= 0.5f;
        }

    }

    /// <summary>
    /// 判定用 function
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Enemy" && Check_Overlap == true)
        {
            InkAmout.increase_Gauge(0.1f);
            Destroy(gameObject);
        }

        if (col.tag == "Enemy" && Check_Overlap == false)
        {
            col.GetComponent<Enemy>().IsMove = false;
            //HP -= Time.deltaTime;
        }
    }

    /// <summary>
    /// 判定用 function
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerExit2D(Collider2D col)
    {


        if (col.tag == "Enemy")
        {
            col.GetComponent<Enemy>().IsMove = true;
            Debug.Log("判定なし test");
        }
    }

    //IEnumerator obj_destroy()
    //{
    //    yield return new WaitForSeconds(3.0f);
    //    InkAmout.increase_Gauge(0.1f);
    //    Destroy(gameObject);
    //} 

    /// <summary>ㅖ
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator Change_Overlap()
    {
        Check_Overlap = true;
        yield return new WaitForSeconds(0.05f);
        Check_Overlap = false;
    }
}
