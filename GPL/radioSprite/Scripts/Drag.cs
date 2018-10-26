using UnityEngine;
using System.Collections;


public class Drag : MonoBehaviour {

    private Vector3 offset;


    void OnMouseDown()
    {
        offset = gameObject.transform.position -
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 8.0f));
    }

    void OnMouseDrag()
    {
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 8.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
    }
}