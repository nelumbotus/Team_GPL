using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDoorlock : MonoBehaviour {

    public GameObject doorlock;
    public GameObject player;
    private bool is_shown;
    private GameObject target;

    void Start ()
    {
        doorlock.SetActive(false);
        is_shown = false;
    }

    void Update ()
    {
        if (Input.GetKey(KeyCode.Escape) && is_shown)
        {
            doorlock.SetActive(false);
            player.SetActive(true);
            is_shown = false;
        }

        if (Input.GetMouseButtonDown(0) && !is_shown)
        {
            target = GetClickedObject();
            if (target.Equals(gameObject)) {
                doorlock.SetActive(true);
                //player.SetActive(false);
                is_shown = true;
            }
        }
    }

    private GameObject GetClickedObject() {
        RaycastHit hit;
        GameObject target = null; 
Debug.Log(Camera.main);
        //마우스 포인트 근처 좌표를 만든다. 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        //마우스 근처에 오브젝트가 있는지 확인
        if( true == (Physics.Raycast(ray.origin, ray.direction * 30, out hit)))
        {
		Debug.Log(hit);
            //있으면 오브젝트를 저장한다.
            target = hit.collider.gameObject; 

        } 

        return target; 

    } 

}

