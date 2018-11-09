/*
금고에 붙입니다.
금고 클릭시 도어락 UI창이 켜집니다.
*/
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class doorlock_click : MonoBehaviour {
    public GameObject doorlock;
    public void OnMouseDown()
    {
        doorlock.SetActive(true);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
