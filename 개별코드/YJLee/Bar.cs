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
    private double min = 40;
    private double max = 310;

    void Start () {
        txt.text = "80";
        Tr = dial.GetComponent<Transform>();
        //prev = Tr.rotation.z;
        prev = Tr.eulerAngles.z;
    }
      
      //0 ~ 3 
    void Update () { 
        //pres = Tr.rotation.z;
        pres = Tr.eulerAngles.z;

        diff = pres - prev; // 지금에서 과거를 뺀것 .. 양수면 증가, 음수면 감소한것
        prev = pres;
        if(diff > 0 ) {//&& transform.position.x >= min 
            transform.Translate(-2f,0,0);
        }
        else if( diff < 0 ) { //transform.position.x <= max
            transform.Translate(+2f,0,0);
        }
        txt.text = ""+ (80 + transform.position.x);

    }
}