using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class radio : MonoBehaviour {
    //public GameObject radioUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.Escape)) 
            //GameObject.Find("RadioCanvas").GetComponent<RadioCanvasController>().ScaleToZero();
    }
    private void OnMouseDown()
    {
        Debug.Log("radio click");
        GameManager.Instance.currGameState = GameManager.GameStates.LookupObj;
        GameObject.Find("RadioCanvas").GetComponent<RadioCanvasController>().ScaleToOne();
    }
    
}
