using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mosPaper : MonoBehaviour {
    public GameObject mosPaperUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Q))
        {
            mosPaperUI.SetActive(false);
            GameManager.Instance.currGameState = GameManager.GameStates.Idle;
        }

    }
    private void OnMouseDown()
    {
        GameManager.Instance.currGameState = GameManager.GameStates.LookupObj;
        mosPaperUI.SetActive(true);
    }
}