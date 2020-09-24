using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleCon : MonoBehaviour
{
    [SerializeField]
    GameObject titleScene;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //public void title()
    //{
    //    Debug.Log("移った");
    //    titleScene.SetActive(false);
    //}

    public void OnClick()
    {
        titleScene.SetActive(true);
    }

    public void OnClick2()
    {
        titleScene.SetActive(false);
    }
}
