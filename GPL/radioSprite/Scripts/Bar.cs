//기능: 다이얼이 회전될 경우, 라디오 위 bar의 위치를 좌우로 이동시키며, 라디오 주파수(text)값을 변경한다

//사용법:
//1. 이 스크립트를 라디오의 bar object의 컴포넌트로 추가한다.
//2. 스크립트의 dial 칸 에는 라디오의 dial object를 드래그앤드롭. 
//3. 스크립트의 text 칸 에는 라디오 위에 표시될 text 오브젝트를 드래그앤드롭.

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
      
public class Bar : MonoBehaviour {

    public Text txt;
    public GameObject dial; 
    public Transform dialTr;
    private double prev;
    private double pres;
    private double diff;
    private Transform Tr;
    private double min = 711;
    private double max = 1055;

    public AudioSource radioSound;
    public AudioSource song;

    private bool once = false;

    private float defaultRadioSound = 1f;

    void Start () {
        radioSound.volume = 0f;

        song.volume = 0;

        txt.text = "80";
        Tr = dial.GetComponent<Transform>();
        prev = Tr.eulerAngles.z;
    }
      
      //0 ~ 3 
    void Update () {
        Vector2 v = transform.localPosition;
        v.y = 35f;
        transform.localPosition = v;
        //transform.Translate(0, 0.1f, 0);
        pres = Tr.eulerAngles.z;

        diff = pres - prev; // 지금에서 과거를 뺀것 .. 양수면 증가, 음수면 감소한것
        prev = pres;
        
        //Debug.Log(transform.position);
        if(diff > 0 && transform.position.x >= min){
            //transform.Translate(-0.5f,0,0);
            transform.Translate(-0.3f,0,0);
        }
        else if( diff < 0 && transform.position.x <= max){
            //transform.Translate(+0.5f,0,0);
            transform.Translate(+0.3f,0,0);
        }
        txt.text = ""+ (transform.position.x); //x.. 711 ~ 
        Debug.Log("x = " + transform.position.x + " y = " + transform.localPosition.y);

        float songSound = (transform.position.x - 711)/344;

        song.volume = songSound;
        radioSound.volume = 1 - songSound;
        Debug.Log(songSound);
        //---------------------------두 오디오 볼륨조절 필요---------------------

    	if(Input.GetKeyDown(KeyCode.Q)){
            GameManager.Instance.currGameState = GameManager.GameStates.Idle;
            GameObject.Find("RadioCanvas").GetComponent<RadioCanvasController>().ScaleToZero();
            song.volume = 0;
            radioSound.volume = defaultRadioSound;
		}
    }
    public void Play(){
        radioSound.Play();
        song.Play();
        radioSound.volume = defaultRadioSound; //why...
    }
    public void Off(){
        radioSound.Pause();
        song.Pause();
        radioSound.volume = 0f;
        //setActive(false);  라디오 캔버스 자체를 false시켜버림 .. 
    }
}