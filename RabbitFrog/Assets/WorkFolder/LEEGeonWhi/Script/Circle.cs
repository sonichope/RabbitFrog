using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public float circumference;
    public float HP;

    void Start()
    {
        Init();
    }

    void Update()
    {
        StartCoroutine(obj_destroy());
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

        Destroy(gameObject);
    }
}
