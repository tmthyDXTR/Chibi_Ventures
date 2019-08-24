using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{
    public void OnMouseDrag()
    {
        Debug.Log("OnDrag");
        this.transform.position = mousePos();
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
