using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class show_memo : MonoBehaviour {
    public GameObject memoUI;
    public GameObject memo1;
    public GameObject memo2;
    public GameObject memo3;

    private bool is_shown;

	// Use this for initialization
	void Start () {
        is_shown = false;
    }
	
	// Update is called once per frame
	void Update () {
        // 메모 UI가 뜬 상태에서 Q를 누르면 UI 닫음.
        if (Input.GetKey(KeyCode.Q) && is_shown)
        {
            GameManager.Instance.currGameState = GameManager.GameStates.Idle;
            memoUI.SetActive(false);
            is_shown = false;
        }
    }

    private void OnMouseDown()
    {
        GameManager.Instance.currGameState = GameManager.GameStates.LookupObj;
        memoUI.SetActive(true);
        // 인벤토리에 쪽지가 없는 상태라면 촛불만 보여야 한다.
        if (inventory.Instance.items.Exists(obj => obj.name == "memo"))
        {
            memo1.SetActive(true);
            memo2.SetActive(true);
            memo3.SetActive(true);
        }
        else
        {
            memo1.SetActive(false);
            memo2.SetActive(false);
            memo3.SetActive(false);
        }
        is_shown = true;
    }
}
