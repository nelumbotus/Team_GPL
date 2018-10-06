using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    //순서대로.. 플레이어의 좌우, 상하 이동 방향을 의미하는 변수.
    private float h = 0.0f;
	private float v = 0.0f;

    //플레어의 "위치(Transform)"컴포넌트를 저장할 변수.
    //이 객체에 변화를 주는게, 곧 이 스크립트(PlayerController)가 붙은 오브젝트의 위치 변화로 이어진다.
	private Transform tr;

    //플레이어의 이동속도, 회전속도. public으로 선언시 inspector 뷰 에서 따로 값을 설정 할 수 있다.
	public float moveSpeed = 10.0f;
	public float rotSpeed = 100.0f;

    //GameMgr 이라는 스크립트를 담을 변수. (스크립트 자체가 일종의 컴포넌트 이다.)
	//public GameMgr _gameMgr;

	// Use this for initialization
	void Start () {

        // <<특정 오브젝트의 컴포넌트 가져오기>>
        //1.GameManager 라는 오브젝트를 생성해둠.
        //2.오브젝트에 GameMgr이라는 스크립트를 생성하여 붙임. 3.(스크립트이름 == '타입'의 역할)
        //4.GameManager이라는 이름의 오브젝트의 GameMgr타입의 컴포넌트(스크립트 의미)를 찾아와서 할당하는 코드
		//_gameMgr = GameObject.Find("GameManager").GetComponent<GameMgr>();

        //transform이라는 키워드로 바로 접근 가능. 하지만 버전 차이를 고려해서 정석대로 가져옴.
		tr = GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {
        // 키보드 입력(상하(h), 좌우(v))을 -1과 1사이의 실수값으로 받아옴.
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");

		//Debug.Log("H = " + h.ToString()); //Debug.Log("V = " + v.ToString()); //Debug.Log(Input.GetAxis("Mouse X").ToString());
		
		//Time.deltaTime의 역할 => 프레임 단위가 아닌, 초 단위로 변화적용. (다른 기기여도 같은 속도 구현)
        //normalized(벡터정규화)? => 정규화 하지 않으면 대각선 이동시 속도가 빨라짐.
        //Space.Self => 기준좌표.
		Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
		tr.Translate(moveDir.normalized * Time.deltaTime * moveSpeed, Space.Self);

        //Vector3.Magnitude(Vector3.forward) --> 벡터의 크기 (추가)
		
		//마우스 좌우 이동으로 캐릭터 회전
		//args:  회전기준 축 * 델타 * 회전속도 * 마우스변위
        //플레이어가 보이지 않는다고 해서, 아래 코드를 지우면안됨! (카메라가 플레이어의 회전각을 기준으로 회전할것임!)
		tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));

	}

}