using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour
{
    Slider Volumeslider;

    private void Start()
    {
        Volumeslider = GetComponent<Slider>();

        float maxVolume = 200f;
        float nowVolume = 100f;

        Volumeslider.maxValue = maxVolume;

        Volumeslider.value = nowVolume;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Method()
    {
        Debug.Log("現在値:" + Volumeslider.value);

        if(Volumeslider.value >= 50)
        {
            Debug.Log("50以上");
        }
    }

}