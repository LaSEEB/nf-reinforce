using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cubeMenu : MonoBehaviour
{

    public cubeBehaviour cubeOutlet;

    //public InputField minInputField;
    //public InputField maxInputField;
    //public Text rawInputText;
    //public Text normalizedInputText;
    public Toggle floatToggle;
    public Toggle rotateToggle;
    public InputField thresholdInputField;

    // Use this for initialization
    void Start () {

        //minInputField.text = "-2.5";
        //maxInputField.text = "2.5";
        thresholdInputField.text = "0.2";
    }
	
	// Update is called once per frame
	void Update () {

        //rawInputText.text = cubeOutlet.inputData.ToString();
        //normalizedInputText.text = cubeOutlet.normalizedInput.ToString();

        //cubeOutlet.min = float.Parse(minInputField.text);
        //cubeOutlet.max = float.Parse(maxInputField.text);

        //cubeOutlet.threshold = float.Parse(thresholdInputField.text);
        cubeOutlet.floatOn = floatToggle.isOn ? true : false;
        //cubeOutlet.rotateOn = rotateToggle.isOn ? true : false;

    }
}
