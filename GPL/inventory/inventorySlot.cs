using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventorySlot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        UseItem();
    }

    void UseItem()
    {
        Debug.Log("use item : " + name);
        GameObject item = inventory.Instance.items.Find(obj => obj.name == name).gameObject;
    }

}
