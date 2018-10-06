using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	 
     //추적할 게임 오브젝트를 인스펙터에서 드래그. (자동으로 그 오브젝트의 transform 컴포넌트가 할당되나봄)
	public Transform target; //추적할 플레이어.
    
	public float dist = 10.0f; //카메라와 타겟의 거리.
	public float height = 5.0f; //타겟보다 카메라가 얼마나 높이 있을지
	public float dampRotate = 5.0f; // 회전감도

	private Transform tr; //카메라의 위치

	void Start () {
        tr = GetComponent<Transform>();
	}
	
	// LateUpdate: Update 함수가 모두 호출 된 이후에 호출.
	//Scene의 "모든 Update 함수"가 완료된 후 호출.. (부드럽게 카메라가 이동하기 위해 필수!)
	void LateUpdate () {

		//Mathf.LerpAngle(실수a, 실수b, 실수t ) --> t 시간동안 a부터 b까지 변경되는 각도를 실수로 리턴.
        float currYAngle = Mathf.LerpAngle(tr.eulerAngles.y, target.eulerAngles.y, dampRotate * Time.deltaTime);

        //쿼터니언 타입으로 변경.
		Quaternion rot = Quaternion.Euler(0, currYAngle, 0);

        //카메라의 위치를 직접적으로 변경 (Translate메소드 쓰지 않고.. 절대좌표로 변경)
		//1. 타겟의 위치에, (회전된 이후 각도를 고려하여) 카메라-타겟 사이 거리를 빼줌
        //2. 높이를 더해줌..
		tr.position = target.position - (rot * Vector3.forward * dist) + ( Vector3.up * height);


        //타겟을 바라보도록 회전.
		tr.LookAt(target);		
	}
}
