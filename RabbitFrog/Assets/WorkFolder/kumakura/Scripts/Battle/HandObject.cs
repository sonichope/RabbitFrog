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

    void Awake()
    {
        parentObject = transform.parent;
    }

    void Start()
    {
        
    }

    void Update()
    {

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
        CharacterSummon(pointerEventData.position);
    }

    /// <summary>
    /// キャラクターの召喚
    /// </summary>
    public void CharacterSummon(Vector3 pos)
    {
        switch (DeckManager.deckObjects[myHandNumber].cardPoolObject.myCardType)
        {
            case CardPoolObject.CardType.infantry:
                break;

            case CardPoolObject.CardType.infantryPlatoon:
                break;

            case CardPoolObject.CardType.cavalry:
                break;

            case CardPoolObject.CardType.knight:
                break;

            case CardPoolObject.CardType.samurai:
                break;

            case CardPoolObject.CardType.archeryCorps:
                break;

            case CardPoolObject.CardType.ninja:
                break;

            case CardPoolObject.CardType.cavalryGeneral:
                break;

            case CardPoolObject.CardType.heavyKnight:
                break;

            case CardPoolObject.CardType.monster:
                break;

            case CardPoolObject.CardType.necromancer:
                break;

            case CardPoolObject.CardType.ghost:
                break;

            case CardPoolObject.CardType.thunderGod:
                break;

        }
        Debug.Log(DeckManager.deckObjects[myHandNumber].cardPoolObject.myCardType);
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
