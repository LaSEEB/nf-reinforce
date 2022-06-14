using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spritesBehabiour : MonoBehaviour
{
    public LSLReceiver receiver;
    private float normalizedInput;
    private float normalizedThreshold;
    //public RigidbodyInterpolation interpolation;

    public bool smoothOn;
    public bool scaleOn;
    public bool soundOn;
    public bool useColor;
    public bool floatOn;

    private Color lerpedColor;

    public float smoothTime = 0.3f;
    public float smoothTime2 = 10.1f;

    public float zoomSpeed = 3f;
    public float zoomout = 6f;

    public Vector3 velocity = Vector3.zero;

    //public float smoothedSpeed = 0.125f;
    //public Vector3 offset;
    public Transform target;

    // public GameObject sphere;
    //public List<Sprite> Sprites;
    public GameObject[] spritesGO;

    private float scallingFactor = 3.4f;

    public static float timeout = 20.0f;

    public Camera cam;


    public Animation anim;

    void Start()
    {
        //Sprites
        initSprites();
        spritesGO[0].GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log("Start");
        //spritesGO[5].transform.localScale = new Vector3(3f, 3f, 3f);
        //scaleChange = new Vector3(-0.1f, -0.1f, -0.1f);

    }

    void initSprites()
    {
        for (int i = 0; i <= 25; i++)
        {
          spritesGO[i].GetComponent<SpriteRenderer>().enabled = false;

        }
    }

    void disableSprites(GameObject[] a,int now)
    {
        
        for (int i = 0; i <= now; i++)
        {
            //if (i!=now)
                spritesGO[i].GetComponent<SpriteRenderer>().enabled = false;

        }
    }

    void FixedUpdate()
    {
        normalizedInput = receiver.normalizedInput;
        normalizedThreshold = valueScript.normalizedThreshold;
        //Debug.Log(normalizedInput);

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
        //var targetScale = new Vector3(x, x, x); //defining the size of the sphere
        //var targetPosition = new Vector3(z, z, z); //defining the size of the sphere

        //Vector3 scallingSize;
        //scallingSize = smoothOn ? Vector3.SmoothDamp(transform.localScale, targetScale, ref velocity, smoothTime) : targetScale;

        //scallingSize = smoothOn ? Vector3.Lerp(transform.localScale, targetScale, smoothTime) : targetScale;

        // Smoothly move the camera towards that target position
        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        //Vector3 desiredPosition = targetScale;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothedSpeed);
        //transform.position = smoothedPosition;



        if (normalizedInput > normalizedThreshold)
        {
            timeout -= Time.deltaTime;
            //Debug.Log("timeout: "+ timeout + " input: " + normalizedInput);
        }
        else
        {
            timeout = 20.0f;
            Debug.Log("RESET: " + timeout);
            cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, 60, zoomout * Time.deltaTime);

        }

        //if (normalizedInput > 0.1f && normalizedInput < 0.2f)
        if (normalizedInput <= 0)
        {
            //disableSprites(spritesGO, 0);
            spritesGO[0].GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("1");
        }

        if (normalizedInput < (normalizedThreshold/4))

        {
            disableSprites(spritesGO, 0);
            spritesGO[1].GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("2");
        }
        if (normalizedInput < 2*(normalizedThreshold / 4) && normalizedInput >  normalizedThreshold / 4)

        {
            disableSprites(spritesGO, 1);
            spritesGO[2].GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("3");
        }
        if (normalizedInput < 3 * (normalizedThreshold / 4) && normalizedInput > 2 * (normalizedThreshold / 4))

        {
            disableSprites(spritesGO, 2);
            spritesGO[3].GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("entrou");

        }

        
        if (normalizedInput < 4 * (normalizedThreshold / 4) && normalizedInput > 3 * (normalizedThreshold / 4))

        {
            disableSprites(spritesGO, 3);
            spritesGO[4].GetComponent<SpriteRenderer>().enabled = true;

        }
        
        if (normalizedInput > normalizedThreshold)
        {
            disableSprites(spritesGO, 4);
            spritesGO[5].GetComponent<SpriteRenderer>().enabled = true;

            //Assuming that a sample contains at least 3 values for x,y,z
            //float x = 0.1f + normalizedInput * scallingFactor;
            //var targetScale = new Vector3(x, x, x);
            //Vector3 desiredScale = targetScale;
            //Vector3 smothedScale = Vector3.SmoothDamp(targetScale, desiredScale, ref velocity2, smoothTime2 * Time.deltaTime);
            //spritesGO[5].transform.localScale = new Vector3(desiredScale.x, smothedScale.y, desiredScale.z);

            //spritesGO[5].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            /*
            anim = GetComponent<Animation>();
            foreach (AnimationState state in anim)
            {
                state.speed = 0.5F;
            }
            */

            cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, x, zoomSpeed * Time.deltaTime);
            
            //spritesGO[5].transform.localScale = smoothOn ? scallingSize : transform.localScale;
            //spritesGO[5].transform.localPosition = smoothOn ? transform.position : transform.localPosition;

        }
 
        // TODO: timeout thresholds below
        
        if (timeout <= 19.0f)
        {
            spritesGO[6].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[6].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("2s ABOVE THRESHOLD!");
        }
        else
            spritesGO[6].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 18.0f)
        {
            spritesGO[7].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[7].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("4s ABOVE THRESHOLD!");
        }
        else
            spritesGO[7].GetComponent<SpriteRenderer>().enabled = false;
        
        if (timeout <= 17.0f)
        {
            spritesGO[8].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[8].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("6s ABOVE THRESHOLD!");
        }
        else
            spritesGO[8].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 16.0f)
        {
            spritesGO[9].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[9].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("8s ABOVE THRESHOLD!");
        }
        else
            spritesGO[9].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 15.0f)
        {
            spritesGO[10].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[10].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("10s ABOVE THRESHOLD!");
        }
        else
            spritesGO[10].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 14.0f)
        {
            spritesGO[11].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[11].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("10s ABOVE THRESHOLD!");
        }
        else
            spritesGO[11].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 13.0f)
        {
            spritesGO[12].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[12].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("10s ABOVE THRESHOLD!");
        }
        else
            spritesGO[12].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 12.0f)
        {
            spritesGO[13].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[13].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("10s ABOVE THRESHOLD!");
        }
        else
            spritesGO[13].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 11.0f)
        {
            spritesGO[14].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[14].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("10s ABOVE THRESHOLD!");
        }
        else
            spritesGO[14].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 10.0f)
        {
            spritesGO[15].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[15].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("10s ABOVE THRESHOLD!");
        }
        else
            spritesGO[15].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 9.0f)
        {
            spritesGO[16].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[16].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("10s ABOVE THRESHOLD!");
        }
        else
            spritesGO[16].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 8.0f)
        {
            spritesGO[17].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[17].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("10s ABOVE THRESHOLD!");
        }
        else
            spritesGO[17].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 7.0f)
        {
            spritesGO[18].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[18].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("10s ABOVE THRESHOLD!");
        }
        else
            spritesGO[18].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 6.0f)
        {
            spritesGO[19].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[19].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("10s ABOVE THRESHOLD!");
        }
        else
            spritesGO[19].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 5.0f)
        {
            spritesGO[20].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[20].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("10s ABOVE THRESHOLD!");
        }
        else
            spritesGO[20].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 4.0f)
        {
            spritesGO[21].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[21].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("10s ABOVE THRESHOLD!");
        }
        else
            spritesGO[21].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 3.0f)
        {
            spritesGO[22].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[22].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("10s ABOVE THRESHOLD!");
        }
        else
            spritesGO[22].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 2.0f)
        {
            spritesGO[23].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[23].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("10s ABOVE THRESHOLD!");
        }
        else
            spritesGO[23].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 1.0f)
        {
            spritesGO[24].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[24].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("10s ABOVE THRESHOLD!");
        }
        else
            spritesGO[24].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 0.0f)
        {
            spritesGO[25].GetComponent<SpriteRenderer>().enabled = true;
            //spritesGO[25].transform.localScale = scaleOn ? scallingSize : transform.localScale;

            //Debug.Log("10s ABOVE THRESHOLD!");
        }
        else
            spritesGO[25].GetComponent<SpriteRenderer>().enabled = false;
        
       
    }
    //ToDO: Lerp
    // https://forum.unity.com/threads/lerp-between-two-materials.490161/  
  
}
