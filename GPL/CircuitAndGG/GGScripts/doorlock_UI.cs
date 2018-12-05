using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorlock_UI : MonoBehaviour {

	
    // Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) gameObject.SetActive(false);
	}
}
