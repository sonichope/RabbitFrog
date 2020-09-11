using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewManager : MonoBehaviour
{
    public Image panel;
    public GameObject preview;
    public Text nameText;
    public Text explanationText;
    public Text costText;
    public Image characterImage;

    public bool isPreview = false;

    void Start()
    {
        panel.enabled = false;
        preview.SetActive(false);
    }

    public void DisplayPreview()
    {
        panel.enabled = !panel.enabled;
        isPreview = !isPreview;
        preview.SetActive(isPreview);
    }
}
