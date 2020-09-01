using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackOption : MonoBehaviour
{
    public void Button()
    {
        SceneManager.LoadScene("OptionScene");
    }
}
