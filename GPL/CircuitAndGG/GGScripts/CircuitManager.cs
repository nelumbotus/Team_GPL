using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircuitManager : MonoBehaviour
{
    public Image[] blocks;
    public Image clear;
    private string answer = "";
    public bool complete;

    //private int[] indices = {0, 4, 5, 6, 8, 9, 10, 11, 12, 13, 14, 15};
    private int[] indices = { 0, 1, 2, 4, 5, 6, 8, 9, 10, 11, 12, 13, 14, 15 };//-----------------------
    private string[] lines = { "", "", "", "" };
    // Use this for initialization
    void Start()
    {
        complete = false;
        clear.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (complete)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ScaleToZero();
            }
        }
    }
    public void ScaleToZero()
    {   
        GameManager.Instance.currGameState = GameManager.GameStates.Idle;
        transform.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        //Debug.Log(transform.gameObject.GetComponent<RectTransform>().localScale);
        //transform.rectTransform.localScale = new Vector(newscale,1f,1f);
    }
    public void ScaleToOne()
    {
        GameManager.Instance.currGameState = GameManager.GameStates.LookupObj;
        transform.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        //Debug.Log(transform.gameObject.GetComponent<RectTransform>().localScale);
        //transform.rectTransform.localScale = new Vector(newscale,1f,1f);
    }
    public void CheckCircuit()
    {

        for (int i = 0; i < 16; i++)
        {
            lines[i / 4] += blocks[i].GetComponent<RotateUI>().clicks;
        }
        answer = "";
        for (int i = 0; i < indices.Length; i++)
        {
            //answer += blocks[i].GetComponent<RotateUI>().clicks % 4;
            if (indices[i] == 6 || indices[i] == 9 || indices[i] == 13 || indices[i] == 14)
            {
                answer += blocks[indices[i]].GetComponent<RotateUI>().clicks % 2;
            }
            else
            { //---------------------------------------------------------------
                answer += blocks[indices[i]].GetComponent<RotateUI>().clicks % 4;
            }
        }
        if (answer == "13220120113101")
        { //------------------------------------------
            complete = true;
            if (complete)
            {
                Debug.Log("노래져야해");
                clear.enabled = true;
                //complete 상태에서 esc누르면 꺼짐
            }
        }
        Debug.Log(answer);
        //Debug.Log(lines[0]);Debug.Log(lines[1]);Debug.Log(lines[2]);Debug.Log(lines[3]);

    }
}