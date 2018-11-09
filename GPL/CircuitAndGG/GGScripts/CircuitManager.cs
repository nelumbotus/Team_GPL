/*
CircuitCanvas 프리팹의 circuit Image에 이 스크립트를 부착합니다.
전체 circuit의 모습을 보였다, 안보이게 해주며
circuit을 한번씩 돌릴때마다 정답을 맞추었는지 체크하고, 퍼즐 완성시 esc키로 종료 가능합니다.
*/


﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircuitManager : MonoBehaviour {
	public Image[] blocks;
	public Image clear;
	private string answer = "";
	public bool complete;
	
	private int[] indices = {0, 4, 5, 6, 8, 9, 10, 11, 12, 13, 14, 15};
	private string[] lines = {"", "", "", ""};
	// Use this for initialization
	void Start () {
		complete = false;
		clear.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(complete){
			if(Input.GetKeyDown(KeyCode.Escape)){
				ScaleToZero();
			}
		}
	}
	public void ScaleToZero(){
		transform.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0,0,0);
		//Debug.Log(transform.gameObject.GetComponent<RectTransform>().localScale);
		//transform.rectTransform.localScale = new Vector(newscale,1f,1f);
	}
	public void ScaleToOne(){
		
		transform.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
		//Debug.Log(transform.gameObject.GetComponent<RectTransform>().localScale);
		//transform.rectTransform.localScale = new Vector(newscale,1f,1f);
	}
	public void CheckCircuit(){

		for(int i = 0; i < 16; i++){
			lines[i/4] += blocks[i].GetComponent<RotateUI>().clicks;
		}
		answer = "";
		for(int i = 0; i < indices.Length; i++){
			answer += blocks[i].GetComponent<RotateUI>().clicks % 4;
		}
		if(answer == "132020102011"){
			complete = true;
			if(complete){
				Debug.Log("노래져야해");
				clear.enabled = true;
				//complete 상태에서 esc누르면 꺼짐
			}
		}
		Debug.Log(answer);
		//Debug.Log(lines[0]);Debug.Log(lines[1]);Debug.Log(lines[2]);Debug.Log(lines[3]);

	}
}
