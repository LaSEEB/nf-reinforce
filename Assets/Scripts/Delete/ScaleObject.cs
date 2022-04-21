using Assets.LSL4Unity.Scripts.AbstractInlets;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * 
 * To be used at LaSEEB for Neurofeedback demos [visual, auditory]
 * 
 * */

[RequireComponent(typeof(AudioSource))]
//AFloatInlet + AIntInlet // receive simultaneously signal streams (openvibeSignal - float inlets) and stimulations streams (openvibeMarkers - int inlets) from openvibe (future addition)
public class ScaleObject : AFloatInlet {

    /****************************  SPHERE  ***************************************************/
    public bool smooth;
    public float smoothTime = 0.1f; // for smoothing
    private Vector3 velocity = Vector3.zero;

    public Transform targetTransform; // sphere to transform
    public GameObject mySphere;

    public bool scale;

    public bool useX;
    public bool useY;
    public bool useZ;

    public bool useColor;
    public Color lerpedColor;

    public bool soundOn;
    public bool addNoise;
    public float startingVol = 0.0f;
    //private float currentVelocity = 0f;
    public AudioSource[] audioSource;
    public AudioSource noise;
    public AudioSource music;

    public int srate;
    public int windowsec;
    public List<float> buffer = new List<float>();
    public float min;
    public float max;
    public float normalizedinput;
    public float inputdata;
	public float inputmarker;

    /****************************  FLOATING CUBE  ***************************************************/
    public GameObject cube;
    public float threshold;
    public float maxHeight;
    private float force = 80f;
    public bool floatOn;
    public bool rotateOn;
    

    protected override void Process(float[] newSample, double timeStamp)
    {
        /****************************  SPHERE  ***************************************************/


        inputdata = newSample[0];

        // normalize buffer
        normalizedinput = (inputdata - min) / (max - min);
        //Debug.Log("Normalized input: "+normalizedinput);

        //Assuming that a sample contains at least 3 values for x,y,z
        float x = useX ? normalizedinput : 1;
		float y = useY ? normalizedinput : 1; // newSample[1] - from more than 1 streams
		float z = useZ ? normalizedinput : 1; // newSample[2]

		// SIZE AND SMOOTHNESS OF THE SPHERE
        // we map the data to the scale factors
		var targetScale = new Vector3(x, y, z); //defining the size of the sphere
        Vector3 scallingSize;
		scallingSize = smooth ? Vector3.SmoothDamp(transform.localScale, targetScale, ref velocity, smoothTime) : targetScale;
      
        targetTransform.localScale = scale ? scallingSize : transform.localScale;

        // COLOR
        lerpedColor = Color.Lerp(Color.white, Color.cyan, Mathf.PingPong(normalizedinput, 1));
        mySphere.GetComponent<Renderer>().material.color = useColor ? lerpedColor : Color.white; 

        // AUDIO
        audioSource = GetComponents<AudioSource>();

        noise = audioSource[0];
        music = audioSource[1];

        // applying a logaritmic scale to both sounds (future addition)

        noise.volume = 1 - Mathf.PingPong (normalizedinput, 1); //sound gets noisier the lower the normalized input
		music.volume = Mathf.PingPong(normalizedinput, 1);

        //if (addNoise) // no need for the noise check box, since noise will be played when normalizedinput falls below a certain threshold

        if (soundOn) {
			if (normalizedinput > 0.5f) { //if the normalizedinput is larger than a certain threshold then music will be played instead of noise

				if (!music.isPlaying) { //music is initialized (in case it is the first time)
					music.Play ();
				} else {
					music.UnPause ();
				}

				if (noise.isPlaying) { //pause the noise if it is playing. If not, do nothing
					noise.Pause ();
				}

			} else {
				if (!noise.isPlaying) {
					noise.Play ();
				} else {
					noise.UnPause ();
				}

				if (music.isPlaying) {
					music.Pause ();
				}
			}
		}
		else {
			noise.Stop ();
			music.Stop ();
		}

        //		Debug.Log ("music" + music.volume + "noise" + noise.volume);

        /************************************  FLOATING CUBE  ***********************************************************************/
        if (floatOn)
        {
            if (normalizedinput > threshold && cube.transform.position.y < maxHeight)
            {
                cube.GetComponent<Rigidbody>().AddForce(Vector3.up * force);
                if(rotateOn)
                    cube.transform.rotation = Random.rotation;
                //Debug.Log ("Normalized Input: " + normalizedinput);
            }
        }

    }
}