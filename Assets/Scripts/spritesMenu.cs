using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class spritesMenu : MonoBehaviour
{

    public spritesBehabiour spritesOutlet;

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
    void Start()
    {

        //minInputField.text = "-2.5";
        //maxInputField.text = "2.5";

    }

    // Update is called once per frame
    void Update()
    {

        spritesOutlet.scaleOn = scaleToggle.isOn ? true : false;
        spritesOutlet.smoothOn = smoothToggle.isOn ? true : false;
        spritesOutlet.useColor = colorToggle.isOn ? true : false;
        spritesOutlet.soundOn = soundToggle.isOn ? true : false;

        spritesOutlet.smoothTime = smoothTimeSlider.value;
        slidertext.text = spritesOutlet.smoothTime.ToString();

        //sphereOutlet.min = float.Parse(minInputField.text);
        //sphereOutlet.max = float.Parse(maxInputField.text);

        //rawInputText.text = sphereOutlet.inputData.ToString();
        //normalizedInputText.text = sphereOutlet.normalizedInput.ToString();

    }
}
