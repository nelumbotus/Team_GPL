using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : Singleton<inventory> {

    public List<Item> items;

    private void Awake()
    {
        items = new List<Item>();
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void inventoryUpdate(Item item) {
        // 현재 가지고 있는 아이템들을 슬롯에 표시
        GameObject slot = new GameObject("Button");
        slot.AddComponent<RawImage>();

        slot.GetComponent<RawImage>().texture = item.icon;
        slot.name = item.name;

        slot.transform.parent = transform;
        slot.AddComponent<inventorySlot>();
    }
}
