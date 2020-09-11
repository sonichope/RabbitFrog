using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionCon : MonoBehaviour
{
    [SerializeField]
    GameObject optionScene;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void option()
    {
        Debug.Log("移った");
        optionScene.SetActive(true);
    }

    public void OnBackOption()
    {
        SceneManager.LoadScene("OptionScene");
    }

}
