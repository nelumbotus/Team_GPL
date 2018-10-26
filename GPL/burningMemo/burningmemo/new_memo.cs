using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class new_memo : MonoBehaviour {
    public Text ObjText;

    GameObject new_change_memo;
	// Use this for initialization
	void Start () {
		
	}
	
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Candle")
        {
            ObjText.text = 
                "\n \n \n             < 꼭꼭 숨어라 >\n         라<b>라</b> 라라<b>솔</b>\n         <b>미</b>라라<b>라</b> 라라솔";
        }
    }
}
