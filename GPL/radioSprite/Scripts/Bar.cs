using UnityEngine;
using System.Collections;
using UnityEngine.UI;
      
public class Bar : MonoBehaviour {

    public Text txt;
    public GameObject dial; //다이얼을 받아서.. 
    public Transform dialTr;
    private double prev;
    private double pres;
    private double diff;
    private Transform Tr;
    private double min = 40;
    private double max = 310;

    void Start () {
        //prev 여기서 정함 
        txt.text = "80";
        Tr = dial.GetComponent<Transform>();
        //prev = Tr.rotation.z;
        prev = Tr.eulerAngles.z;
    }
      
      //0 ~ 3 
    void Update () { 
        //pres 부터 갱신 해주고
        //pres = Tr.rotation.z;
        pres = Tr.eulerAngles.z;

        diff = pres - prev; // 지금에서 과거를 뺀것 .. 양수면 증가, 음수면 감소한것
        //Debug.Log(pres + "     "  + diff);
        prev = pres;
        if(diff > 0 ) {//&& transform.position.x >= min //반시계 .. <- 
            //Debug.Log(Tr.rotation.z);
            transform.Translate(-2f,0,0);
        }
        else if( diff < 0 ) { //transform.position.x <= max
            //Debug.Log(Tr.rotation.z);
            transform.Translate(+2f,0,0);
        }
        txt.text = ""+ (80 + transform.position.x);

    }
}