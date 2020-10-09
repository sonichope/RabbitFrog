using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaitleBackCon : MonoBehaviour
{
    [SerializeField]
    GameObject TitleChoicesCon;
    [SerializeField]
    GameObject TitleChoicesCon2;
    [SerializeField]
    GameObject TitleChoicesCon3;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void active()
    {
        TitleChoicesCon.SetActive(true);
        TitleChoicesCon2.SetActive(false);
    }

    public void optionBack()
    {
        TitleChoicesCon2.SetActive(false);
        TitleChoicesCon3.SetActive(true);
    }


}
