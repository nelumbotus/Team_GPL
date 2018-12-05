using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToInventoryBtn : MonoBehaviour
{
    //for add btn
    public GameObject SelectedObj; // 아크볼 ui의 SelectedObject
    // for exit btn
    public GameObject InvestigateUI;
    public GameObject ArcballUI;

    public void Add()
    {
        //SelectedObj.transform.GetChild(0).GetComponent<Item>().AddToInventory();
        // SelectedObj.transform.GetChild(0)는 아크볼에서 instance된 오브젝트를 가져오기 때문에 
        // 현재 selected된 오브젝트를 게임매니저에 저장했다가 가져오는 방식으로 했는데 더 좋은 방법이 있다면 고쳐주세요 .. 
        GameManager.Instance.currHitObject.GetComponent<Item>().AddToInventory();
        InvestigateUI.SetActive(false);
        GameManager.Instance.currGameState = GameManager.GameStates.Idle;
    }
    public void Exit()
    {
        InvestigateUI.SetActive(false);
        GameManager.Instance.currGameState = GameManager.GameStates.Idle;
    }
}

