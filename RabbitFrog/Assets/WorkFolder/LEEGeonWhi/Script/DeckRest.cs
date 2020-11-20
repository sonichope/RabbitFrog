using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckRest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DeckSave.Reset();
        SaveData.SaveReset();
    }
}
