using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class handBackGround : MonoBehaviour
{
    [SerializeField] private BattleController battleController;
    private Image image;

    public int cost = 0;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = battleController.SummonGageVal / cost;
    }
}
