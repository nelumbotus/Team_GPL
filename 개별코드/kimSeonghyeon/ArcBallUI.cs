using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcBallUI : MonoBehaviour {
    public Camera ObjectCamera;
    public GameObject targetGo;
    private Vector3 mousePosition;
    private Vector3 pMousePosition;
    public float scrollScale;
    // Use this for initialization
    void Start () {
        pMousePosition = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            pMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            mousePosition = Input.mousePosition;
            Vector3 left = (pMousePosition - mousePosition);
            Vector3 crossedVector = Vector3.Cross(Vector3.Normalize(left), ObjectCamera.transform.rotation * Vector3.forward);
            pMousePosition = Input.mousePosition;
            targetGo.transform.RotateAround(targetGo.transform.position, - crossedVector, Vector3.Magnitude(left) * scrollScale);
        }
    }

    public void setTargetGameObject(GameObject go)
    {
        Debug.Log("dsdssddsds");
        Destroy(targetGo.transform.GetChild(0).gameObject);
        GameObject tempGO = Instantiate(go, targetGo.transform);
        tempGO.transform.localPosition = Vector3.zero;
    }
}
