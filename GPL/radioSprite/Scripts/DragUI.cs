using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragUI : MonoBehaviour {
   float distance = 100;

   void OnMouseDrag()
   {
       //print("Drag!!");
       Vector3 mousePosition = new Vector3(Input.mousePosition.x,
       Input.mousePosition.y, distance);
       Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
       transform.position = objPosition;
   }

   // Use this for initialization
   void Start () {

    }
    
    // Update is called once per frame
    void Update () {

   }
}