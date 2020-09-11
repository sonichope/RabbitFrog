using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makimonoAnim : MonoBehaviour
{
    [SerializeField] GameObject pepar;
    Animation anim;

    void Start()
    {
        anim = pepar.gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play();
        }
    }
}
