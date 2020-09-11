using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DeckObject : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image iconImage;
    private Sprite nowSprite;
    public CardPoolObject cardPoolObject;
    public PreviewManager preMana;


    void Start()
    {
        nowSprite = null;
        preMana = FindObjectOfType<PreviewManager>();
    }

    /// <summary>
    /// マウスカーソルがオブジェクトに乗ったとき
    /// </summary>
    /// <param name="pointerEventData"></param>
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (pointerEventData.pointerDrag == null) return;
        Image dropImage = pointerEventData.pointerDrag.GetComponent<Image>();
        iconImage.sprite = dropImage.sprite;
        iconImage.color = Vector4.one;
    }

    /// <summary>
    /// マウスカーソルがオブジェクトから離れたとき
    /// </summary>
    /// <param name="pointerEventData"></param>
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (pointerEventData.pointerDrag == null) return;
        iconImage.sprite = nowSprite;
        if (nowSprite == null) { iconImage.color = Vector4.one; }
        else { iconImage.color = Vector4.one; }
    }

    /// <summary>
    /// ドラッグをやめたとき
    /// </summary>
    /// <param name="pointerEventData"></param>
    public void OnDrop(PointerEventData pointerEventData)
    {
        Image dropImage = pointerEventData.pointerDrag.GetComponent<Image>();
        cardPoolObject = pointerEventData.pointerDrag.GetComponent<CardPoolObject>();
        cardPoolObject.character.myCardType = pointerEventData.pointerDrag.GetComponent<CardPoolObject>().character.myCardType;
        iconImage.sprite = dropImage.sprite;
        nowSprite = dropImage.sprite;
        iconImage.color = Vector4.one;
    }

    /// <summary>
    /// クリック時
    /// </summary>
    /// <param name="pointerEventData"></param>
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.pointerEnter == null) { return; }
        preMana.DisplayPreview();
        cardPoolObject = pointerEventData.pointerEnter.GetComponent<CardPoolObject>();
        Debug.Log(cardPoolObject);
        //preMana.costText.text = pointerEventData.pointerEnter.GetComponent<CardPoolObject>().character.cost.ToString();
        
        //Debug.Log(pointerEventData.pointerEnter.GetComponent<CardPoolObject>().character.cost);
    }
}
