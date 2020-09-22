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
    GameObject ScrollPaper;
    private RectTransform rect;

    [SerializeField,Range(0.0f, 3.0f)] // Scene転換速度
    float Speed = 1.0f;
    float Alpha;

    public bool Scene_changing = false;

    void Start()
    {
        rect = ScrollPaper.GetComponent<RectTransform>();
        StartCoroutine(InitScene());
        Alpha = 1.0f;
        effect.SetFloat("_t", Alpha);
    }

    //Post Effect処理
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, effect);    
    }

    /// <summary>
    /// 画面転換Effectが終わったらNextScene移動
    /// </summary>
    /// <param name="NextScene">次に移動するSceneName</param>
    /// <returns></returns>
    public IEnumerator NextScene(string SceneName)
    {
        ScrollPaper.SetActive(true);
        Alpha = 0;
        while (Alpha <= 0.95f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            Alpha += Time.deltaTime * Speed;          
            effect.SetFloat("_t", Alpha);
            rect.localScale = new Vector3(rect.localScale.x * -1, 1, 1);
        }
        ScrollPaper.SetActive(false);
        SceneManager.LoadScene(SceneName);
    }

    public  IEnumerator InitScene()
    {
        Scene_changing = true;
        ScrollPaper.SetActive(true);
        Alpha = 0.95f;

        while (Alpha >= 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            Alpha -= Time.deltaTime * Speed;
            effect.SetFloat("_t", Alpha);
            rect.localScale = new Vector3(rect.localScale.x * -1, 1, 1);
        }
        ScrollPaper.SetActive(false);
        Scene_changing = false;
    }
}
