using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PlayerCardDropZone : MonoBehaviour
{
    public Transform card;

    private HorizontalLayoutGroup hlg;
    private BoxCollider collider;


    public void OnMouseEnter()
    {
        //Debug.Log("OnMouseEnter");
    }
    public void OnMouseExit()
    {
        //Debug.Log("OnMouseExit");
    }

    public void OnTriggerStay(Collider other)
    {
        card = other.transform;
        if (card.GetComponent<Draggable>().isDragged == true)
        {
            card.GetComponent<Draggable>().parentToReturnTo = this.transform;
            card.GetComponent<Draggable>().placeholder.transform.SetParent(this.transform);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        card = other.transform;
        if (card.GetComponent<Draggable>().isDragged == true)
        {
            card.GetComponent<Draggable>().parentToReturnTo = card.GetComponent<Draggable>().originalParent;
            card.GetComponent<Draggable>().placeholder.transform.SetParent(card.GetComponent<Draggable>().originalParent);

        }
    }

    void Awake()
    {
        hlg = GetComponent<HorizontalLayoutGroup>();
        collider = GetComponent<BoxCollider>();
    }

    void Update ()
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
