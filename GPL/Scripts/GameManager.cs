using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

// 다른 스크립트에서 GameManager 사용 : GameManager.Instance 로 public변수와 메소드에 접근 가능

public class GameManager : Singleton<GameManager> {
    public GameObject UI;
    public float rayDistance = 5.0f;

    //public bool PW_SUCCESS = false; // 게임매니저에 boolean으로 pw를 맞췄는지 못맞췄는지를 확인해준다.
    //public int count_door = 0; // 문 갯수 세기, 시작시 : 0, 중문 통과후 : 1, 마지막문 : 2.
    //Acrball 에서 raycast (in RayCastFromMouse)

    //Acrball 에서 raycast (in RayCastFromMouse)
    public Text text;
    public ArcBallUI ui;

    public Text mouseOverText;

    //
    Vector3 clickRayVector;
    public GameObject currHitObject;

    public GameObject gameClearUI;

    public enum GameStates
    {
        Idle,
        LookupObj,
    };

    public enum PuzzleStates
    {
        start,
        circuit_completed,
        safebox_opened,
        memo_completed,
        lamp_found
    }


    public GameStates currGameState;
    PuzzleStates currPuzzleState;

    private void Awake()
    {
        currGameState = GameStates.Idle;
        currPuzzleState = PuzzleStates.start;
    }

    public PlayableDirector timeline;
    public bool IsTimelinePlaying(){
        return timeline.state == PlayState.Playing;
    }

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;

        clickRayVector = new Vector3(0.5f, 0.5f, 0.0f);
	}
	
	// Update is called once per frame
    void Update () {
        ClickControl();

        //커서 컨트롤 
        if (currGameState == GameStates.Idle) {
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
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
            if (Physics.Raycast(ray, out hit) && hit.distance < rayDistance)
            {
                GameObject hitObject = hit.transform.gameObject;
                Debug.Log(hitObject);

                if (hitObject != null && (hitObject.tag == "SelectableWithObtain" || hitObject.tag == "SelectableWithoutObtain" || hitObject.tag == "Unselectable") )
                {
                   
                    ui.setTargetGameObject(hitObject);
                    currHitObject = hitObject;
                    
                }

                if(hitObject.GetComponent<Description>() != null)
                {
                    text.text = hitObject.GetComponent<Description>().text;
                }
                else 
                {
                    text.text = hitObject.name;
                }
            }
        }
    }

    void EscapeControl() {
     
    }

    public void gameClear() {
        Debug.Log("game clear");
        gameClearUI.SetActive(true);
    }
}
