using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class doorlock_click : MonoBehaviour {
    public GameObject doorlock;
    public void OnMouseDown()
    {
        GameManager.Instance.currGameState = GameManager.GameStates.LookupObj;
        doorlock.SetActive(true);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.Q)) {
            doorlock.SetActive(false);
            GameManager.Instance.currGameState = GameManager.GameStates.Idle;
        }
	}
}
