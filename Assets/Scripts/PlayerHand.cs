using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHand : MonoBehaviour
{
    private HorizontalLayoutGroup hlg;
    private Collider collider;

    void Awake()
    {
        hlg = GetComponent<HorizontalLayoutGroup>();
        collider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        RefreshLayout();
    }

    public void RefreshLayout()
    {
        Canvas.ForceUpdateCanvases();
        hlg.CalculateLayoutInputHorizontal();
        hlg.SetLayoutHorizontal();
    }
}
