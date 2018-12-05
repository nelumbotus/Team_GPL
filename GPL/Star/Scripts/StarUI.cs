using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarUI : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Q)) close();
	}
    public void close()
    {
        GameManager.Instance.currGameState = GameManager.GameStates.Idle;
        gameObject.SetActive(false);
    }
}
