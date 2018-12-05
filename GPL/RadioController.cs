using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour {
    public int type; //0은 시작 상태 1는 금고가 열린 후 2는 중문을 연 후
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        if(type == 1) {
            GameObject.Find("RadioCanvas").GetComponent<RadioCanvasController>().ScaleToOne();
        } 
        if(type == 2) {
            //ㄱ건전지 얻을 수 있게
        }
        if(type == 3) {
            //건전지 회수 후
        }

    }
}
