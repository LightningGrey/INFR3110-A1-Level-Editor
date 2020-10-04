using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag3D : MonoBehaviour
{
    private Vector3 mouseOffset;
    private float zCoordinate;

    // Start is called before the first frame update
    void OnMouseDown()
    {
        zCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mouseOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    // Update is called once per frame
    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mouseOffset;
    }

    private Vector3 GetMouseWorldPos()
    {
        //mousePosition only has (x,y) coordinates
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = zCoordinate;
       
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
