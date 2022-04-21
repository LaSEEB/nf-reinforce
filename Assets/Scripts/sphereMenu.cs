using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sphereMenu : MonoBehaviour {

    public sphereBehaviour sphereOutlet;

    public Toggle scaleToggle;
    public Toggle smoothToggle;
    public Slider smoothTimeSlider;
    public Text slidertext;
    public Toggle colorToggle;
    public Toggle soundToggle;
    //public InputField minInputField;
    //public InputField maxInputField;
    //public Text rawInputText;
    //public Text normalizedInputText;

    // Use this for initialization
    void Start () {

        //minInputField.text = "-2.5";
        //maxInputField.text = "2.5";

    }

    // Update is called once per frame
    void Update () {

        sphereOutlet.scaleOn = scaleToggle.isOn ? true : false;
        sphereOutlet.smoothOn = smoothToggle.isOn ? true : false;
        sphereOutlet.useColor = colorToggle.isOn ? true : false;
        sphereOutlet.soundOn = soundToggle.isOn ? true : false;

        sphereOutlet.smoothTime = smoothTimeSlider.value;
        slidertext.text = sphereOutlet.smoothTime.ToString();

        //sphereOutlet.min = float.Parse(minInputField.text);
        //sphereOutlet.max = float.Parse(maxInputField.text);

        //rawInputText.text = sphereOutlet.inputData.ToString();
        //normalizedInputText.text = sphereOutlet.normalizedInput.ToString();

    }
}
