using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makimono : MonoBehaviour
{
    // [SerializeField] private GameObject makimono01;
    // Start is called before the first frame update
    private bool vecFlag = false;
    void Start()
    {
        StartCoroutine("SampleCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        Test();
    }

    IEnumerator SampleCoroutine()
    {
        if (vecFlag == true)
            yield return new WaitForSeconds(5.0f);
        
    }

    void Test()
    {
        if (vecFlag) { return; }
        vecFlag = true;
        Transform myTransform = transform;
        Vector2 pos = myTransform.position;
        pos.x += -0.01f;
        pos.y += 0;
        myTransform.position = pos;
    }
}
