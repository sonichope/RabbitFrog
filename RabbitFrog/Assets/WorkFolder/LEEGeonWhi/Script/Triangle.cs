using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    private BoxCollider2D Box_col;

    public float HP = 0;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            //col.GetComponent<Enemy>().HP -= ??;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
           

        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {

        }
    }

    void Init()
    {
        Box_col = gameObject.AddComponent<BoxCollider2D>();
        Box_col.isTrigger = true;
    }
}
