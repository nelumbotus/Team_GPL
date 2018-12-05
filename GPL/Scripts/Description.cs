using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 마우스 오버하면 text를 표시해주기 위한 스크립트
// 텍스트를 띄우고 싶은 오브젝트에 이 스크립트 추가 후 text만 세팅해주세요

public class Description : MonoBehaviour {
    public string text;
    public string dialText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnMouseOver()
    {
        if(GameManager.Instance.currGameState == GameManager.GameStates.Idle)
            GameManager.Instance.mouseOverText.text = text;
    }
    private void OnMouseExit()
    {
        GameManager.Instance.mouseOverText.text = "";
    }
    private void OnMouseDown()
    {
        GameManager.Instance.gameObject.GetComponent<Dialoguemanager>().clicked(dialText);
    }


}
