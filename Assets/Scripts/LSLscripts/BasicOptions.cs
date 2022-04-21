using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicOptions : MonoBehaviour {

    public GameObject menu;
    private bool show;

	// Use this for initialization
	void Start ()
    {
        show = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            show = !show;
            menu.SetActive(show);
        }
        /*if (Input.GetKey(KeyCode.N))
        {
            menu.SetActive(true);
        }*/
    }
}
