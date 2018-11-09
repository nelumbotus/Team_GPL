/*
램프에 있는 PointLight 오브젝트에 이 스크립트를 부착합니다.

램프(pointLight)클릭시, circuit퍼즐이 뜹니다, 퍼즐을 해결 한 뒤에 램프를 다시 클릭하면
모스부호에 맞게 light가 깜빡거립니다.

(point light클릭이 잘 되도록, collider크기를 키워주세요 ..)

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {
	//6 5 7 4
	float[] secs = {2,1,1,1,1,1,1,1,1,1,2,2,1,1,1,1,1,1,1,2};
	Color[] colors = {Color.blue, Color.red, Color.green, Color.white};
	bool on;
	Light lgt;

	// Use this for initialization
	void Start () {
		on = false;
		lgt = gameObject.GetComponent<Light>();
		GameObject.Find("Circuit").GetComponent<CircuitManager>().ScaleToZero();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void OnMouseDown(){
		if (!GameObject.Find("Circuit").GetComponent<CircuitManager>().complete){
		GameObject.Find("Circuit").GetComponent<CircuitManager>().ScaleToOne();
		}
		else{
			StartCoroutine(TimeLightOn(2));
		}
	}

	IEnumerator TimeLightOn(int sec){
		Debug.Log("호출댐 ㅎㅎ");
		// 0 1 2 3 4 => 쉬고
		// 5 6 7 8 9 => 쉬고 
		// 10 11 12 13 14 => 쉬고
		for(int i = 0; i < secs.Length; i++){
			lgt.color = colors[i / 5];
			LightOn();
			yield return new WaitForSeconds(secs[i] / 3);
			LightOff();
			yield return new WaitForSeconds(0.5f);
			if(i % 5 == 4){
				yield return new WaitForSeconds(2);
			}
		}

	}

	public void LightOn(){
		lgt.intensity = 7;
	}
	public void LightOff(){
		lgt.intensity = 0.1f;
	}

}
