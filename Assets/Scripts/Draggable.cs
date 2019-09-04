using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{
    private UnitInfo card;
    private HoverOverCard hover;

    public Transform originalParent;
    public Transform parentToReturnTo = null;
    public bool isDragged = false;
    public bool isDropped = false;

    public GameObject placeholderPrefab;
    public GameObject placeholder;

    public enum Slot { UNIT, SPELL, HAND }
    public Slot cardType = Slot.UNIT;

    void Awake()
    {
        originalParent = this.transform.parent;

        card = GetComponent<UnitInfo>();
        hover = GetComponent<HoverOverCard>();
    }

    public void OnMouseDown()
    {
        Debug.Log("OnBeginDrag");

        placeholder = Instantiate(placeholderPrefab, this.transform.position, Quaternion.identity) as GameObject;
        placeholder.transform.SetParent(this.transform.parent);
        placeholder.transform.localScale = new Vector3(0.33f, 0.33f, 0);
        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        
        isDragged = true;
        if(isDropped == true)
        {
            Debug.Log("Unit Card Grabbed");
            isDropped = false;
            GameHandler.PlayerGrabUnit();
            GameHandler.AddSupply(card.cost);
        }

        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
    }

    public void OnMouseDrag()
    {
        //Debug.Log("OnDrag");

        this.transform.position = mousePos();
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        int newSiblingIndex = parentToReturnTo.childCount;
        for(int i = 0; i < parentToReturnTo.childCount; i++)
        {
            if(this.transform.position.x < parentToReturnTo.GetChild(i).position.x)
            {
                newSiblingIndex = i;
                if(placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                {
                    newSiblingIndex--;
                }
                break;
            }
        }
        placeholder.transform.SetSiblingIndex(newSiblingIndex);
    }

    public void OnMouseUp()
    {
        Debug.Log("OnEndDrag");


        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        isDragged = false;
        isDropped = false;
        Destroy(placeholder);
        if (parentToReturnTo.name == "PlayerCardDropZone")
        {
            Debug.Log("Unit Card Dropped");
            GameHandler.PlayerDropUnit(this.gameObject);
            GameHandler.RemoveSupply(card.cost);
            isDropped = true;
        }
    }

    Vector3 mousePos()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            return new Vector3 (hit.point.x, hit.point.y, 0);
        }
        return hit.point;
    }
}
