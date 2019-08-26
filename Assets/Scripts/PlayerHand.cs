using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHand : MonoBehaviour
{
    public Draggable card;
    public Draggable.Slot cardSlot = Draggable.Slot.HAND;


    private HorizontalLayoutGroup hlg;
    private BoxCollider collider;

    void Start()
    {
        hlg = GetComponent<HorizontalLayoutGroup>();
        collider = GetComponent<BoxCollider>();
    }

    public void OnTriggerStay(Collider other)
    {
        card = other.transform.GetComponent<Draggable>();
        if (card.isDragged == true)
        {
            if (cardSlot == Draggable.Slot.HAND)
            {
                card.parentToReturnTo = this.transform;
                card.placeholder.transform.SetParent(this.transform);

                if (Input.GetMouseButtonUp(0))
                {
                    Debug.Log("GetMouseButtonUp(0)");

                    other.transform.SetParent(card.parentToReturnTo);
                    other.transform.SetSiblingIndex(card.placeholder.transform.GetSiblingIndex());
                    other.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    card.isDragged = false;
                    //Destroy(card.placeholder);
                }
            }

        }
    }

    void Update()
    {
        RefreshLayout();

        if (Input.GetMouseButtonDown(0))
        {
            collider.enabled = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            collider.enabled = false;
        }
    }


    public void RefreshLayout()
    {
        Canvas.ForceUpdateCanvases();
        hlg.CalculateLayoutInputHorizontal();
        hlg.SetLayoutHorizontal();
    }
}
