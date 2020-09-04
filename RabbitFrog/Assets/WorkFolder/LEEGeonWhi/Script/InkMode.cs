using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InkMode : MonoBehaviour
{

    [SerializeField]
    Image image;

    RectTransform Set_rt;
    Vector3 rt_temp;

    //[SerializeField]
    //float Width;

    //Material rend;
    // Start is called before the first frame update
    void Start()
    {
        Set_rt = GetComponent<RectTransform>();
        rt_temp = Set_rt.localScale;
        //rend = GetComponent<Renderer>();
        //image.material.shader = Shader.Find("Unlit/OutLine");
    }

    // Update is called once per frame
    void Update()
    {
        if (LineController.is_inkMode)
        {
            //image.material.SetFloat("_Width", Width);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.6f);
            rt_temp.y = 1.8f;
            Set_rt.localScale = rt_temp;
        }
        if (!LineController.is_inkMode)
        {
            //image.material.SetFloat("_Width", 0);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1.0f);
            rt_temp.y = 2f;
            Set_rt.localScale = rt_temp;
        }
        //rend.material.SetFloat("_Shininess", shininess);

    }
}

//mat = GetComponent<Renderer>().material;
//mat.SetColor("_EnergyColor", energyColor);
//mat.SetFloat("_Visibility", visibility);
//mat.SetFloat("_CollisionTime", -99f); /
