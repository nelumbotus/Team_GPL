using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class radio : MonoBehaviour {
    public GameObject radioUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) radioUI.SetActive(false);
	}
    private void OnMouseDown()
    {
        Debug.Log("radoi click");
        radioUI.SetActive(true);
    }
    
}
