using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class RotateUI : MonoBehaviour, IPointerClickHandler {
	public int clicks;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPointerClick(PointerEventData eventData){
		if (!GameObject.Find("Circuit").GetComponent<CircuitManager>().complete){
			clicks++;
			StartCoroutine(Bingle());
			//transform.Rotate(0,0,90);
		}
	}
	IEnumerator Bingle(){
		for(int i = 0; i < 30; i++) {
			transform.Rotate(0,0,3);
			yield return new WaitForSeconds(0.01f);
		}
		GameObject.Find("Circuit").GetComponent<CircuitManager>().CheckCircuit();
	}
}


