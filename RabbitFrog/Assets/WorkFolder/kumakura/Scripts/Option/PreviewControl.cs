using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewControl : MonoBehaviour
{
    [SerializeField] private Image panel;
    [SerializeField] private GameObject preview;
    [SerializeField] private Text nameText;
    [SerializeField] private Text explanationText;
    [SerializeField] private Text costText;
    [SerializeField] private Image characterImage;

    void Start()
    {
        panel.enabled = false;
        preview.SetActive(false);
    }

    void Update()
    {
        
    }

}
