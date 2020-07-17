using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Searching : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tmp = GameObject.Find("Infantry(clone)").transform.position;
        GameObject.Find("Infantry(clone)").transform.position = new Vector2(tmp.x + 100, tmp.y);
        Debug.Log("敵だ！！");

        float x = tmp.x;
        float y = tmp.y;
    }
}
