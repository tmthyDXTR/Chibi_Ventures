using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverOverCard : MonoBehaviour
{
    private Vector3 originalSize;
    private Vector3 originalPosition;
    public float hoverSize = 2.5f; // Multiply original card size
    public float zoomSpeed;

    private Canvas canvas;
    void Start()
    {
        originalSize = transform.localScale;
        canvas = GetComponent<Canvas>();
    }

    void OnMouseEnter()
    {
        SetHoverSize();
    }

    void OnMouseOver()
    {
        
    }

    void OnMouseExit()
    {
        SetOriginalSize();
    }


    public void SetHoverSize()
    {
        canvas.sortingOrder = 1;
        transform.localScale = new Vector3(originalSize.x * hoverSize, originalSize.y * hoverSize, originalSize.z);
    }

    public void SetOriginalSize()
    {
        canvas.sortingOrder = 0;
        transform.localScale = originalSize;
    }
}
