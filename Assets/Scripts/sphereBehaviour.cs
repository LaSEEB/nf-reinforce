using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereBehaviour : MonoBehaviour
{
    public LSLReceiver receiver;

    private float normalizedInput;
    private float normalizedThreshold;

    public bool smoothOn;
    public bool scaleOn;
    public bool soundOn;
    public bool useColor;

    private Color lerpedColor;

    public float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;

    public GameObject sphere;
    private float scallingFactor = 3.4f;

    void Start () {
		
	}
	
	void Update ()
    {    
        normalizedInput = receiver.normalizedInput;
        normalizedThreshold = valueScript.normalizedThreshold;
        // if the input value is below the minimum, we make the sphere's radius saturate at a certain value.
        if (normalizedInput < 0f)
        {
            normalizedInput = 0f;
        }
        if (normalizedInput > 1f)
        {
            normalizedInput = 1f;
        }


        //Assuming that a sample contains at least 3 values for x,y,z
        float x = 0.1f + normalizedInput * scallingFactor;

        // SIZE AND SMOOTHNESS OF THE SPHERE
        // we map the data to the scale factors
        var targetScale = new Vector3(x, x, x); //defining the size of the sphere
        Vector3 scallingSize;
        scallingSize = smoothOn ? Vector3.SmoothDamp(transform.localScale, targetScale, ref velocity, smoothTime) : targetScale;
        sphere.transform.localScale = scaleOn ? scallingSize : transform.localScale;

        // COLOR
        sphere.GetComponent<Renderer>().material.color = normalizedInput < normalizedThreshold ? Color.red : Color.white;
              
        //lerpedColor = Color.Lerp(Color.white, Color.cyan, Mathf.PingPong(normalizedInput, 1));
        //sphere.GetComponent<Renderer>().material.color = useColor ? lerpedColor : Color.white;
        

    }
}
