using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HandObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private int myHandNumber;
    private Transform parentObject;
    private GameObject dragObject;
    private HandManager handManager;

    void Awake()
    {
        parentObject = transform.parent;
        handManager = FindObjectOfType<HandManager>();
    }

    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        CreateCharacterObject();
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
        var pos = Camera.main.ScreenToWorldPoint(pointerEventData.position);
        pos.z += 10.0f;
        handManager.CharacterSummon(pos, myHandNumber);
    }

    

    /// <summary>
    /// Dragしたキャラクターの複製
    /// </summary>
    public void CreateCharacterObject()
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
}
