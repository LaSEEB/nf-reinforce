using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class visualizationControl : MonoBehaviour {

    public LSLReceiverMarkers receiver;
    public GameObject scenarios;
    public GameObject intervalPanel;
    public GameObject endPanel;


    public Canvas pauseCanvas;
    public Button backBt;

	// Use this for initialization
	void Start ()
    {
        if (values.displays == 2) //if 2 display are used
        {
            //visualize on second display
            gameObject.GetComponent<Camera>().targetDisplay = 1; 
            pauseCanvas.targetDisplay = 1;
            backBt.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        scenarios.SetActive(receiver.trial);
        intervalPanel.SetActive(!receiver.trial);

        if (receiver.experimentEnd)
        {
            scenarios.SetActive(false);
            intervalPanel.SetActive(false);
            endPanel.SetActive(true);
        }
       		
	}
}
