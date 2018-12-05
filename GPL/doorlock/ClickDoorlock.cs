using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickDoorlock : MonoBehaviour
{
    string currentPassword = "";
    int enterCount = 0;
    public GameObject doorlock;
    //public GameObject player;
    public GameObject door;
    public string correctPassword;

    public void ClickNumButton(int num)
    {
        // 입력한 비밀번호가 아직 4자리 수가 아니라면 계속해서 입력..
        if (enterCount < 4)
        {
            GetComponent<Text>().text = currentPassword + num;
            currentPassword = currentPassword + num;
            enterCount += 1;
        }
    }

    public void ClickResetButton()
    {
        enterCount = 0;
        currentPassword = "";
        GetComponent<Text>().text = "----";
    }
    public void ClickEnterButton()
    {

        if (currentPassword == correctPassword)
        {
            GameManager.Instance.currGameState = GameManager.GameStates.Idle;
            // 문일 때
            if (door.CompareTag("Door")) {
                GameObject.Find("bar").GetComponent<Bar>().Off(); //--------
                door.GetComponent<ShowDoorlock>().startAnim();
                doorlock.SetActive(false);
                Debug.Log("비밀번호 맞췄음");

                // 두번째 문이 열릴 때
                if(door.name == "GPL_Door_Second") 
                {
                    GameManager.Instance.gameClear();
                }
            }
            else {
                // 금고 일 때
                //RadioController를 radio오브젝트에 붙여..
                GameObject.Find("radioCube").GetComponent<RadioController>().type = 1;
                GameObject.Find("bar").GetComponent<Bar>().Play();
                Destroy(door);
                doorlock.SetActive(false);
                door.SetActive(false);
            }

        }
        else
        {

            ClickResetButton();
        }
    }


}