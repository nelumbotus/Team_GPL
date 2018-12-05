using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioCanvasController : MonoBehaviour {
	
	private int[] indices = {0, 4, 5, 6, 8, 9, 10, 11, 12, 13, 14, 15};
	private string[] lines = {"", "", "", ""};
	// Use this for initialization
	void Start () {
        ScaleToZero();
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void ScaleToZero(){
		transform.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0,0,0);
	}
	public void ScaleToOne(){
		
		transform.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
	}

}
