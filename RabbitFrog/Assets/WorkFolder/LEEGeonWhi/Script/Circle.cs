using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public float circumference;
    public float HP;
    public bool obj_destroyed;

    void Start()
    {
        obj_destroyed = false;
        Init();
        StartCoroutine(obj_destroy());
    }

    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D col)
    {

        if (col.tag == "Enemy")
        {
            
          Vector3 direction = (transform.position - col.gameObject.transform.position).normalized;
            if (Vector2.Distance(transform.position, col.gameObject.transform.position) < 0.1f) return;
            col.gameObject.transform.position += direction * 0.05f;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void Init()
    {
        if (HP < 0) HP=0.1f;
    }

    IEnumerator obj_destroy()
    {
        while(HP > 0)
        {
            yield return new WaitForSeconds(1.0f);
            HP -= 0.2f;
        }

        InkAmout.increase_Gauge(0.1f);
        Destroy(gameObject);
    }
}
