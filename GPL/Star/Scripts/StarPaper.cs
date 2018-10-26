using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPaper : MonoBehaviour {
    public GameObject starMask;
    GameObject starUI;

    // Use this for initialization
    void Start () {
        //gamemanager로부터 star에 관련된 ui를 미리 가져온다.
        starUI = GameManager.Instance.UI.transform.FindChild("Star").gameObject;
	}
	
	void Update () {
		
	}
    private void OnMouseDown()
    {
        GameManager.Instance.currGameState = GameManager.GameStates.LookupObj;
        starUI.SetActive(true);

        //인벤토리에 Lamp가 있으면
        if(inventory.Instance.items.Exists(obj => obj.name == "Lamp"))
        {
            //별자리 확인 마스크를 킨다
            starMask.SetActive(true);
        }
    }
}
