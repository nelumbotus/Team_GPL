using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastFromMouse : MonoBehaviour {
    public float pokeForce;
    public Text text;
    public ArcBallUI ui;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Debug.DrawRay(ray.origin, ray.direction);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject);
                if (hit.transform.gameObject != null && hit.transform.gameObject.tag == "Selectable")
                {
                    ui.setTargetGameObject(hit.transform.gameObject);
                }
                text.text = hit.transform.gameObject.name;
                if (hit.rigidbody != null)
                {
                    Debug.Log("dwdads");
                    hit.rigidbody.AddForceAtPosition(ray.direction * pokeForce, hit.point);
                }
            }
        }
    }
}
