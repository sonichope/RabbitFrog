using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrganizationMask : MonoBehaviour
{
    public Image image;
   public bool start_anime = false;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (image.fillAmount <= 1 && start_anime)
        {
            image.fillAmount += Time.deltaTime;
        }

        if (image.fillAmount >= 0 && !start_anime)
        {
            image.fillAmount -= Time.deltaTime;
        }


    }

    public void Run_animation()
    {
        //start_anime = !start_anime;
        start_anime = true;
    }

    //public IEnumerator test1()
    //{
    //    yield return new WaitForSeconds(Time.deltaTime);
    //    while(image.fillAmount <= 1)
    //    {
    //        image.fillAmount += Time.deltaTime;

    //    }
    //}
}
