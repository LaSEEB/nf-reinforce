using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;



public class valueScript : MonoBehaviour
{

    public static float min = 0f;
    public static float max = 1f;
    public static float threshold = 0.5f;
    public static float normalizedThreshold = 0.5f;

    public InputField minInputField;
    public InputField maxInputField;
    public InputField thresholdInputField;
    public Button setValuesBt;
    public Button startBt;


    void Start ()
    {
        minInputField.placeholder.GetComponent<Text>().text = min.ToString();
        maxInputField.placeholder.GetComponent<Text>().text = max.ToString();
        thresholdInputField.placeholder.GetComponent<Text>().text = threshold.ToString();
        setValuesBt.onClick.AddListener(setValues);

        if (values.displays == 2)
        {
            SceneManager.LoadScene("feedback_new", LoadSceneMode.Additive);
        }
        else if(values.displays == 1)
        {
            startBt.gameObject.SetActive(true);
            startBt.onClick.AddListener(loadFB);
        }
    }

    void Update ()
    {
        minInputField.placeholder.GetComponent<Text>().text = min.ToString();
        maxInputField.placeholder.GetComponent<Text>().text = max.ToString();
        thresholdInputField.placeholder.GetComponent<Text>().text = threshold.ToString();
    }

    void setValues()
    {
        try
        {
            min = float.Parse(minInputField.text);            
        }
        catch(FormatException ex)
        {
        }

        try
        {
            max = float.Parse(maxInputField.text);
        }
        catch (FormatException ex)
        {
        }

        try
        {
            threshold = float.Parse(thresholdInputField.text);            
        }
        catch (FormatException ex)
        {
        }

        normalizedThreshold = (threshold - min) / (max - min);
        minInputField.text = "";
        maxInputField.text = "";
        thresholdInputField.text = "";

    }

    void loadFB()
    {
        SceneManager.LoadScene("feedback_new");
    }


}
