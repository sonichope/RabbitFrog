using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Effect_Sketch : MonoBehaviour
{
    [SerializeField]
     Material effect;

    [SerializeField]
    Image ScrollPaper;

    [SerializeField,Range(0.0f, 3.0f)]
    float Speed = 1.0f;

    float Alpha = 1.0f;
   
    void Start()
    {
        Alpha = 1.0f;
        effect.SetFloat("_t", Alpha);

        StartCoroutine(fade_In());
    }

    void Update()
    {
        Debug.Log("Screen Width : " + Screen.width);
    }
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, effect);    
    }

    public IEnumerator fade_Out()
    {
        Alpha = 0;
        
        while (Alpha <= 0.95f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            Alpha += Time.deltaTime * Speed;          
            effect.SetFloat("_t", Alpha);
            //gameObject.rectTransform.localScale = new Vector3(gameObject.rectTransform.localScale.x * -1, 1, 1);
        }
        //StartCoroutine(fade_Out());

    }

    public  IEnumerator fade_In()
    {
        Alpha = 0.95f;

        while (Alpha >= 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            Alpha -= Time.deltaTime * Speed;
            effect.SetFloat("_t", Alpha);
            ScrollPaper.rectTransform.localScale = new Vector3(ScrollPaper.rectTransform.localScale.x * -1, 1, 1);
        }
        //StartCoroutine(fade_In());

    }
}
