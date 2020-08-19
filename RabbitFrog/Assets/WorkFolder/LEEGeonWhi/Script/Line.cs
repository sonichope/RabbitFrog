using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public float lineLength;
    public float HP;

    private BoxCollider2D Box_col;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        StartCoroutine(obj_destroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init()
    {
        Box_col = gameObject.AddComponent<BoxCollider2D>();
        Box_col.isTrigger = true;
    }

    /// <summary>
    /// 判定用 function
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Debug.Log("判定あり test");
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
            Debug.Log("判定なし test");
        }
    }

    IEnumerator obj_destroy()
    {
        yield return new WaitForSeconds(3.0f);
        InkAmout.increase_Gauge(0.1f);
        Destroy(gameObject);
    }
}
