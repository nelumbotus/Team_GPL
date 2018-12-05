using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDoorlock : MonoBehaviour {

    public GameObject doorlock;
    public GameObject player;
    private bool is_shown;
    private GameObject target;
    private Animator _animator;
    private bool isbool = false;

    void Start ()
    {
        doorlock.SetActive(false);
        is_shown = false;
        _animator = GetComponent<Animator>();
    }

    void Update ()
    {
    if (Input.GetKey(KeyCode.Q))
        {
            doorlock.SetActive(false);
            GameManager.Instance.currGameState = GameManager.GameStates.Idle;
        }

        //if (Input.GetMouseButtonDown(0) && !is_shown)
        //{
        //    target = GetClickedObject();
        //    if (target.Equals(gameObject)) {
        //        doorlock.SetActive(true);
        //        //player.SetActive(false);
        //        is_shown = true;
        //        isbool = true;
        //    }
        //}

    }
    public void startAnim () {
        isbool = true;
        _animator.SetBool("open", isbool);
    }

    private void OnMouseDown()
    {
        GameManager.Instance.currGameState = GameManager.GameStates.LookupObj;
        doorlock.SetActive(true);
    }

}

