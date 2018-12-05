using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetVec = Camera.main.transform.position;
        targetVec.y = transform.position.y;
        transform.LookAt(targetVec, Vector3.up);
	}
}
