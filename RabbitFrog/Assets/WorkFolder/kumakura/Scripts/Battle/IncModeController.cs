using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IncModeController : MonoBehaviour
{

    private GameObject obj;
    public GameObject linePlefab;
    public float lineLength = 0.2f;
    public float lineWidth = 0.1f;

    private Vector2 touchPos;

    public bool IsDraw = false;



    void Start()
    {
        
    }

    void Update()
    {
        if (IsDraw == false) { return; }
        DrawLine();
    }

    public void OnIsDraw()
    {
        IsDraw = !IsDraw;
    }

    private void DrawLine()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 startPos = touchPos;
            Vector2 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if ((endPos - startPos).magnitude > lineLength)
            {
                obj = Instantiate(linePlefab, transform.position, transform.rotation) as GameObject;
                obj.transform.position = (startPos + endPos) / 2;
                obj.transform.right = (endPos - startPos).normalized;
                obj.transform.localScale = new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth);
                obj.transform.parent = this.transform;
                touchPos = endPos;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            foreach (Transform c in gameObject.transform)
            {
                c.gameObject.SetActive(false);
            }
        }
    }
}
