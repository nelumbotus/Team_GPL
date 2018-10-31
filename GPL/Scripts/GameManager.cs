using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 다른 스크립트에서 GameManager 사용 : GameManager.Instance 로 public변수와 메소드에 접근 가능

public class GameManager : Singleton<GameManager> {
    public GameObject UI;
    

    //Acrball 에서 raycast (in RayCastFromMouse)
    public Text text;
    public ArcBallUI ui;

    //
    Vector3 clickRayVector;

    public enum GameStates
    {
        Idle,
        LookupObj,
    };

    public GameStates currGameState;

    private void Awake()
    {
        currGameState = GameStates.Idle;
    }

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;

        clickRayVector = new Vector3(0.5f, 0.5f, 0.0f);
	}
	
	// Update is called once per frame
    void Update () {
        ClickControl();

        if(currGameState == GameStates.Idle) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(currGameState == GameStates.LookupObj) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void ClickControl() {
        // Acrball 에서 raycast (in RayCastFromMouse)
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var ray = Camera.main.ViewportPointToRay(clickRayVector);
            Debug.DrawRay(ray.origin, ray.direction);
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                Debug.Log(hitObject);

                if (hitObject != null && hitObject.tag == "Selectable")
                {
                   
                    ui.setTargetGameObject(hitObject);
                    
                }
                text.text = hitObject.name;
            }
        }
    }

    void EscapeControl() {
     
    }
}
