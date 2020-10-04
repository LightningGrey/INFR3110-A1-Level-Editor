using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, 
    IEndDragHandler, IDragHandler
{ 
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("mouse is down");      
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("mouse starting to be dragged");
    }

    public void OnDrag(PointerEventData eventData)
    { 
        Debug.Log("mouse is dragged");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("mouse is done being dragged");
    }
}
