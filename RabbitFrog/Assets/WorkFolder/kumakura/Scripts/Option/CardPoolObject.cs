using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardPoolObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Transform parentObject;
    private GameObject dragObject;
    private RectTransform rectTransform;

    void Awake()
    {
        parentObject = transform.parent.parent;
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        CreateDragObject();
        //dragObject.transform.position = pointerEventData.position;
        //dragObject.transform.localScale = pointerEventData.position;
        Vector2 localPos = GetLocalPostion(pointerEventData.position);
        rectTransform.localPosition = localPos;
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        //dragObject.transform.position = pointerEventData.position;
        //dragObject.transform.localScale = pointerEventData.position;
        Vector2 localPos = GetLocalPostion(pointerEventData.position);
        rectTransform.localPosition = localPos;
    }


    public void OnEndDrag(PointerEventData pointerEventData)
    {
        gameObject.GetComponent<Image>().color = Vector4.one;
        Destroy(dragObject);
    }


    private Vector2 GetLocalPostion(Vector2 screenPostion)
    {
        Vector2 result = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPostion, Camera.main, out result);
        return result;
    }

    /// <summary>
    /// DragしたObjectの作成
    /// </summary>
    private void CreateDragObject()
    {
        dragObject = new GameObject("DragObject");
        dragObject.transform.SetParent(parentObject);
        dragObject.transform.SetAsLastSibling();
        dragObject.transform.localScale = Vector3.one;

        //CanvasGroup canvasGroup = dragObject.AddComponent<CanvasGroup>();
        //canvasGroup.blocksRaycasts = false;

        Image dragImage = dragObject.AddComponent<Image>();
        Image souceImage = GetComponent<Image>();

        dragImage.sprite = souceImage.sprite;
        dragImage.rectTransform.sizeDelta = souceImage.rectTransform.sizeDelta;
        dragImage.color = souceImage.color;
        dragImage.material = souceImage.material;

        gameObject.GetComponent<Image>().color = Vector4.one * 0.6f;
    }


}
