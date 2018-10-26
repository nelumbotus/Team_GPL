using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseInventory : MonoBehaviour {
    // 오브젝트의 회전축 받아오기
    public Vector3 rotateAxis;

    // 화면 상의 위치와 회전값 ..

    float rotateAmount = 0.0f;
    Vector3 finalRotate;
    Vector3 currRotate;

    // Use this for initialization
    void Start () {
        currRotate = transform.localRotation.eulerAngles;
        //현재 회전 상태를 유지하고 받아온 회전축으로 회전하기 위해 받아온 회전축이 있는 부분만 0인 벡터 생성
        finalRotate = new Vector3(
            (rotateAxis.x == 0) ? currRotate.x : 0, (rotateAxis.y == 0) ? currRotate.y : 0, (rotateAxis.z == 0) ? currRotate.z : 0
        );
	}
	
	// Update is called once per frame
	void Update () {
        rotateAmount += Input.GetAxis("Mouse X") * 100.0f * Time.deltaTime;

        Mathf.Clamp(rotateAmount, -60, 60);
        transform.localEulerAngles = rotateAxis * rotateAmount + finalRotate;
       
    }
}
