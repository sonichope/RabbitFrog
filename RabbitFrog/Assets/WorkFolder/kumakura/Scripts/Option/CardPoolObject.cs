using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class CardPoolObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Transform parentObject;
    private GameObject dragObject;

    public CardType myCardType;
    
    public enum CardType
    {
        none,
        infantry,
        infantryPlatoon,
        cavalry,
        knight,
        samurai,
        archeryCorps,
        ninja,
        cavalryGeneral,
        heavyKnight,
        monster,
        necromancer,
        ghost,
        thunderGod,
    }

    void Awake()
    {
        parentObject = transform.parent.parent.parent.parent;
    }

    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        CreateDragObject();
        dragObject.transform.position = GetMousePosition();
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        dragObject.transform.position = GetMousePosition();
    }


    public void OnEndDrag(PointerEventData pointerEventData)
    {
        gameObject.GetComponent<Image>().color = Vector4.one;
        Destroy(dragObject);
    }

    /// <summary>
    /// MousePositionの取得
    /// </summary>
    /// <returns></returns>
    private Vector3 GetMousePosition()
    {
        Vector3 screenMousuPos = Input.mousePosition;
        screenMousuPos.z = 10f;
        Camera gameCamera = Camera.main;
        Vector3 worldMousePos = gameCamera.ScreenToWorldPoint(screenMousuPos);
        return worldMousePos;
    }

    /// <summary>
    /// DragしたObjectの作成
    /// </summary>
    private void CreateDragObject()
    {
        Vector3 mousePos = Input.mousePosition;
        dragObject = new GameObject("DragObject");
        dragObject.transform.SetParent(parentObject);
        dragObject.transform.SetAsLastSibling();
        dragObject.transform.localPosition = mousePos;
        dragObject.transform.localScale = Vector3.one;

        CanvasGroup canvasGroup = dragObject.AddComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false;

        Image dragImage = dragObject.AddComponent<Image>();
        Image souceImage = GetComponent<Image>();

        dragImage.sprite = souceImage.sprite;
        dragImage.rectTransform.sizeDelta = souceImage.rectTransform.sizeDelta;
        dragImage.color = souceImage.color;
        dragImage.material = souceImage.material;
        dragImage.preserveAspect = true;

        gameObject.GetComponent<Image>().color = Vector4.one * 0.6f;
    }


}
