using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mask : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x - Camera.main.pixelWidth/2, Input.mousePosition.y - Camera.main.pixelHeight / 2, 0);
        transform.localPosition = mousePosition;

        Vector3 pos = transform.localPosition;
        pos.x *= -1;
        pos.y *= -1;
        //transform.GetChild(0).GetComponent<RectTransform>().localPosition = pos;
        transform.GetChild(0).localPosition = pos;

    }
}
