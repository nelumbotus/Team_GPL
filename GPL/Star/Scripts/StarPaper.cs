using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPaper : MonoBehaviour {

    public GameObject starMask;
    public GameObject starUI;

    private bool is_shown;

    // Use this for initialization
    void Start () {
     
	}
	
	void Update () {
        if(Input.GetKey(KeyCode.Escape) && is_shown) {
            starUI.SetActive(false);
            GameManager.Instance.currGameState = GameManager.GameStates.Idle;
            is_shown = false;
        }
	}

    private void OnMouseDown()
    {
        GameManager.Instance.currGameState = GameManager.GameStates.LookupObj;
        starUI.SetActive(true);
        is_shown = true;

        //인벤토리에 Lamp가 있으면
        if (inventory.Instance.items.Exists(obj => obj.name == "Lamp"))
        {
            //별자리 확인 마스크를 킨다
            starMask.SetActive(true);
        }
    }
}
