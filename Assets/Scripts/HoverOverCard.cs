using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverOverCard : MonoBehaviour
{
    private Vector3 originalSize;
    public float hoverSize = 2.5f; // Multiply original card size
    public float zoomSpeed;

    private Canvas canvas;
    void Start()
    {
        originalSize = transform.localScale;
        canvas = GetComponent<Canvas>();
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        canvas.sortingOrder = 1;
        transform.localScale = new Vector3(originalSize.x * hoverSize, originalSize.y * hoverSize, originalSize.z);
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        canvas.sortingOrder = 0;
        transform.localScale = originalSize;
    }

}
