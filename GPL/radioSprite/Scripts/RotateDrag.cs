    //기능: 부착된 오브젝트를 마우스 드래그로 회전 시킴.

    //사용법: 회전 시킬 오브젝트에 스크립트를 부착함.
     using UnityEngine;
     using System.Collections;
      
     public class RotateDrag : MonoBehaviour {
      
         private Camera myCam;
         private Vector3 screenPos;
         private float   angleOffset;
      
         void Start () {
             myCam=Camera.main;
         }
      
         void Update () { 

            if(Input.GetMouseButtonDown(0)) {
              //screenPos = myCam.WorldToScreenPoint (transform.position);
              Debug.Log(transform.position);
              screenPos = transform.position;
              Vector3 v3 = Input.mousePosition - screenPos;
              angleOffset = Mathf.Atan2(v3.y, v3.x)  * Mathf.Rad2Deg;
            }
            //This fires while the button is pressed down
            if(Input.GetMouseButton(0)) {
                   Vector3 v3 = Input.mousePosition - screenPos;
                   float angle = Mathf.Atan2(v3.y, v3.x) * Mathf.Rad2Deg;
                   transform.eulerAngles = new Vector3(0,0,angle+angleOffset);  
            }
         }
     }