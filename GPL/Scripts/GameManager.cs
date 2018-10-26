using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {
    public GameObject UI;

    public enum GameStates
    {
        Idle,
        LookupObj,
    };

    public GameStates currGameState;

    private void Awake()
    {
        currGameState = GameStates.Idle;
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
   
	}

}
