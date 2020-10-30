using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private GameObject Parent_obj;

    // Start is called before the first frame update

    void Start()
    {
        Parent_obj = transform.parent.gameObject;
        this.gameObject.transform.Rotate(0,180.0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.transform.position -= new Vector3(Time.deltaTime * 5.0f, 0, 0);
            Parent_obj.GetComponent<WallParent>().HP -= Time.deltaTime * 5;
        }

        if (col.gameObject.tag == "Character")
        {
            col.transform.position += new Vector3(Time.deltaTime * 5.0f, 0, 0);
            Parent_obj.GetComponent<WallParent>().HP -= Time.deltaTime * 5;
        }
    }
}
