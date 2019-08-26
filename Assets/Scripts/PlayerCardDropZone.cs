using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class PlayerCardDropZone : MonoBehaviour
{
    public Draggable card;
    public Draggable.Slot cardSlot = Draggable.Slot.UNIT;

    public int freeUnitSlots;

    private HorizontalLayoutGroup hlg;
    private BoxCollider collider;


    public void OnTriggerEnter(Collider other)
    {
        card = other.transform.GetComponent<Draggable>();
        int cost = other.transform.GetComponent<CardDisplay>().cost;
        if (card != null && card.isDragged == true)
        {
            if (cardSlot == card.cardType 
                && GameHandler.CheckPlayerUnitSlots() == true 
                && GameHandler.playerSupply >= cost)
            {
                card.parentToReturnTo = this.transform;
                card.placeholder.transform.SetParent(this.transform);                
            }            
        }
    }
    public void OnTriggerStay(Collider other)
    {
        card = other.transform.GetComponent<Draggable>();
        int cost = other.transform.GetComponent<CardDisplay>().cost;
        if (card.isDragged == true)
        {
            if (cardSlot == card.cardType 
                && GameHandler.CheckPlayerUnitSlots() == true
                && GameHandler.playerSupply >= cost)
            {
                card.parentToReturnTo = this.transform;
                card.placeholder.transform.SetParent(this.transform);
            }
        }
    }


    public void OnTriggerExit(Collider other)
    {
        card = other.transform.GetComponent<Draggable>();
        if (card.isDragged == true)
        {
            card.parentToReturnTo = card.originalParent;
            card.placeholder.transform.SetParent(card.originalParent);
        }
    }

    void Start()
    {
        hlg = GetComponent<HorizontalLayoutGroup>();
        collider = GetComponent<BoxCollider>();
        freeUnitSlots = GameHandler.GetPlayerFreeUnitSlots();

        GameHandler.OnPlayerFreeUnitSlotsChanged += delegate (object sender, EventArgs e)
        {
            UpdatePlayerFreeUnitSlots();
        };

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

    private void UpdatePlayerFreeUnitSlots()
    {
        freeUnitSlots = GameHandler.GetPlayerFreeUnitSlots();
    }

    public void RefreshLayout()
    {
        Canvas.ForceUpdateCanvases();
        hlg.CalculateLayoutInputHorizontal();
        hlg.SetLayoutHorizontal();
    }
}
