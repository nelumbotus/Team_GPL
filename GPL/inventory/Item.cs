// 인벤토리에 들어갈 수 있는 아이템 클래스
// 인벤토리에 넣을 수 있는 아이템들에 이 스크립트를 추가한 후 인벤토리에 표시될 아이콘을 넣어주세요

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public string name;
    public Texture2D icon;

    bool isUsing = false;
    bool isAdded = false;

    Vector3 mousePos;

	// Use this for initialization
	void Start () {
        name = gameObject.name;
        gameObject.tag = "SelectableWithObtain";
    }
	
	// Update is called once per frame
	void Update () {

		
	}
    public void AddToInventory()
    {
        if (isAdded == false) {
            Debug.Log("add item in inventory");
            //클릭 시 인벤토리에 추가 후 인벤토리 리스트 업데이트 호출
            inventory.Instance.items.Add(this);
            inventory.Instance.inventoryUpdate(this);

            gameObject.SetActive(false);
            isAdded = true;
        }
       
    }

}
