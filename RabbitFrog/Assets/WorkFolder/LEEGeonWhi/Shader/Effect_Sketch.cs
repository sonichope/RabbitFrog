using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Effect_Sketch : MonoBehaviour
{
    //[SerializeField]
    // Material effect;

    [SerializeField] 
    GameObject Panel;
    Image image;
    Color color;
    private RectTransform rect;

    [SerializeField,Range(0.0f, 3.0f)] // Scene転換速度
    float Speed = 1.0f;
    float Alpha = 1.0f;

    public bool Scene_changing = false;

    void Start()
    {
        //rect = ScrollPaper.GetComponent<RectTransform>();
        this.GetComponent<Camera>().depth = 0;
        image = Panel.GetComponent<Image>();

        StartCoroutine(InitScene());
        Alpha = 1.0f;
        color = image.color;
        color.a = Alpha;
        image.color = color;
        //effect.SetFloat("_t", Alpha);
    }

//#if UNITY_EDITOR
//    //Post Effect処理
//    void OnRenderImage(RenderTexture source, RenderTexture destination)
//    {
//        Graphics.Blit(source, destination, effect);
//    }
//#endif

    /// <summary>
    /// 画面転換Effectが終わったらNextScene移動
    /// </summary>
    /// <param name="NextScene">次に移動するSceneName</param>
    /// <returns></returns>
    public IEnumerator NextScene(string SceneName)
    {
        //ScrollPaper.SetActive(true);
        Panel.SetActive(true);

        Alpha = 0;
        color.a = Alpha;
        image.color = color;

        while (Alpha <= 0.95f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            Alpha += Time.deltaTime * Speed;
            color.a = Alpha;
            image.color = color;

            //effect.SetFloat("_t", Alpha);
            //rect.localScale = new Vector3(rect.localScale.x * -1, 1, 1);
        }
        //ScrollPaper.SetActive(false);
        //Panel.SetActive(false);


        SceneManager.LoadScene(SceneName);
    }

    public  IEnumerator InitScene()
    {
        Panel.SetActive(true);

        Scene_changing = true;
        //ScrollPaper.SetActive(true);
        Alpha = 1.0f;
        color.a = Alpha;
        image.color = color;

        while (Alpha >= 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            Alpha -= Time.deltaTime * Speed;
            color.a = Alpha;
            image.color = color;

            //effect.SetFloat("_t", Alpha);
            //rect.localScale = new Vector3(rect.localScale.x * -1, 1, 1);
        }
        Alpha = 0;
        color.a = Alpha;
        image.color = color;
        Panel.SetActive(false);

        //ScrollPaper.SetActive(false);
        Scene_changing = false;
    }
}
