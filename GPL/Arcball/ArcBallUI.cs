using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcBallUI : MonoBehaviour {
    public Camera ArcBallCamera;
    public GameObject targetGo;
    private Vector3 mousePosition;
    private Vector3 pMousePosition;
    public float scrollScale;
    public GameObject InvestigateUI;
    public GameObject[] buttons; 
    // Use this for initialization
    void Start () {
        pMousePosition = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.Q)){
            InvestigateUI.SetActive(false);

            //게임매니저 상태 변경
            GameManager.Instance.currGameState = GameManager.GameStates.Idle;
        }
        if (Input.GetMouseButtonDown(0))
        {
            pMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            mousePosition = Input.mousePosition;
            Vector3 left = (pMousePosition - mousePosition);
            Vector3 crossedVector = Vector3.Cross(Vector3.Normalize(left), ArcBallCamera.transform.rotation * Vector3.forward);
            pMousePosition = Input.mousePosition;
            targetGo.transform.RotateAround(targetGo.transform.position, - crossedVector, Vector3.Magnitude(left) * scrollScale);
        }
    }

    public void setTargetGameObject(GameObject go)
    {
        if(targetGo.transform.childCount > 0) 
            Destroy(targetGo.transform.GetChild(0).gameObject);

        if (go.tag == "Unselectable") {
            buttons[0].SetActive(false);
        }
        else  {
            Debug.Log("SelectableWithObtain");
           
            GameObject tempGO = Instantiate(go, targetGo.transform);
            tempGO.transform.localPosition = Vector3.zero;
            tempGO.GetComponent<MeshRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;

            if (go.tag == "SelectableWithObtain")
            {
                buttons[0].SetActive(true);
            }
            else if (go.tag == "SelectableWithoutObtain")
            {
                buttons[0].SetActive(false);
            }
        }
       

        InvestigateUI.SetActive(true);
        //게임매니저 상태 변경
        GameManager.Instance.currGameState = GameManager.GameStates.LookupObj;
    }
}
