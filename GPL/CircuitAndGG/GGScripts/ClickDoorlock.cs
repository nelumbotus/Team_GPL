/*

 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickDoorlock : MonoBehaviour
{
    string currentPassword = "";
    int enterCount = 0;
    public GameObject door;
    public GameObject doorlock;

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
       
        if(currentPassword == "6574")
        {
            door.SetActive(false);
            doorlock.SetActive(false);
        }
        else
        {
            enterCount = 0;
            currentPassword = "";
            GetComponent<Text>().text = "----";
        }
    }
}
