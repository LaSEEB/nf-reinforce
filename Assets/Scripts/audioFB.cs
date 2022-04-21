using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioFB : MonoBehaviour {

    public LSLReceiver receiver;

    public float normalizedInput;
    public float normalizedThreshold;

    private Object[] audioClips;

    public AudioSource[] audioSource;
    public AudioSource noise;
    public AudioSource music;


    // Use this for initialization
    void Start () {

        audioClips = Resources.LoadAll("Sounds", typeof(AudioClip));

        audioSource = GetComponents<AudioSource>();
        noise = audioSource[0];
        music = audioSource[1];

        music.clip = audioClips[0] as AudioClip;
        noise.clip = audioClips[1] as AudioClip;

    }
	
	// Update is called once per frame
	void Update ()
    {

        normalizedInput = receiver.normalizedInput;
        normalizedThreshold = valueScript.normalizedThreshold;

        // human hearing perception is logarithmic. The bigger the value of base is, the stronger the effect, the slower volume starts growing in the beginning and the faster it grows in the end
        noise.volume = (Mathf.Pow(10, Mathf.Abs(Mathf.PingPong(normalizedInput, 1) - normalizedThreshold)) - 1) / 9;
        music.volume = noise.volume;

        if (normalizedInput > normalizedThreshold)
        { //if the normalizedinput is larger than a certain threshold then music will be played instead of noise

            if (!music.isPlaying)
            { //music is initialized (in case it is the first time)
                music.Play();
            }
            else
            {
                music.UnPause();
            }

            if (noise.isPlaying)
            { //pause the noise if it is playing. If not, do nothing
                noise.Pause();
            }

        }
        else
        {
            if (!noise.isPlaying)
            {
                noise.Play();
            }
            else
            {
                noise.UnPause();
            }

            if (music.isPlaying)
            {
                music.Pause();
            }
        }
    }


}