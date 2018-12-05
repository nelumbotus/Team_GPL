using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_memo : MonoBehaviour {

    public Sprite character_memo;

    public float animTime = 2f;

    private Image fadeImage;

    private float start = 1f;
    private float end = 0f;
    private float time = 0f;

	// Use this for initialization
    
    void Update()
    {

        // PlayFadeOut();
    }
    
    /* void Awake()
    {
        fadeImage = GetComponent<Image>();
    } */

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "candle")
        {
            gameObject.GetComponent<Image>().overrideSprite = character_memo;

            Debug.Log("아야!");
        }
    }

    /* void PlayFadeOut()
    {
        time += Time.deltaTime / animTime;
        Color color = fadeImage.color;
        color.a = Mathf.Lerp(start, end, time);
        fadeImage.color = color;
    }
    */
}
