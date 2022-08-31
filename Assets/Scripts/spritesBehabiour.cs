using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spritesBehabiour : MonoBehaviour
{
    public LSLReceiver receiver;
    //public LSLReceiverMarkers receiverMarkers;
    //public visualizationControl receivercontrol;

    private float normalizedInput;
    private float normalizedThreshold;
    //public RigidbodyInterpolation interpolation;

    public bool smoothOn;
    public bool scaleOn;
    public bool soundOn;
    public bool useColor;
    public bool floatOn;

    public float smoothTime = 0.3f;

    //public float zoomSpeed = 3f;
    public float zoomout = 20f;

    public Vector3 velocity = Vector3.zero;

    public GameObject[] spritesGO;

    private float scallingFactor = 3.4f;

   //public float zoomMultiplier = 2;
    public float defaultFov = 90;
    public float zoomDuration = 1;

    public static float timeout = 60.0f;

    public Camera cam;

    void Start()
    {
        //Sprites
        initSprites();
        //spritesGO[0].GetComponent<SpriteRenderer>().enabled = true;  //take the comment if UNDERWATER GAME
        spritesGO[36].GetComponent<SpriteRenderer>().enabled = true; //take the comment if TROPICAL GAME
        Debug.Log("Start");

    }

    void initSprites()
    {
        for (int i = 0; i <= 62; i++)
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
        //timeout = 60.0f;

        //Assuming that a sample contains at least 3 values for x,y,z
        //float x = 0.1f + normalizedInput * scallingFactor;

        if (normalizedInput > normalizedThreshold)
        {
            timeout -= Time.deltaTime;
            //Debug.Log("timeout: "+ timeout + " input: " + normalizedInput);
            //ZoomCamera(defaultFov * normalizedInput / zoomMultiplier);
            ZoomCamera(defaultFov * normalizedInput);
            //cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, defaultFov * normalizedInput, zoomDuration * smoothTime);
            //cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, defaultFov * normalizedInput, zoomDuration * Time.deltaTime);
        }

        else
        {
            timeout = 60.0f;
            Debug.Log("RESET: " + timeout);
            //ZoomCamera(defaultFov);
            cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, 60, zoomout * smoothTime);


        }
   

        // UNDERWATER GAME --> 2 SESSIONS --> WHEN NOT USED PUT IN COMMENT
        /*
        if (normalizedInput < normalizedThreshold/2)
        {
            //disableSprites(spritesGO, 0);
            spritesGO[0].GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("1");
        }
         else
            spritesGO[0].GetComponent<SpriteRenderer>().enabled = false;
        
        if (normalizedInput < 2* (normalizedThreshold/2) && normalizedInput > normalizedThreshold / 2)

        {
            //disableSprites(spritesGO, 0);
            spritesGO[1].GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("2");
        }
        else
            spritesGO[1].GetComponent<SpriteRenderer>().enabled = false;
        
        if (normalizedInput > normalizedThreshold)
        {
           // disableSprites(spritesGO, 5);
            spritesGO[5].GetComponent<SpriteRenderer>().enabled = true;

            cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, 30, zoomSpeed * Time.deltaTime);

        }
        else
            spritesGO[5].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 58.0f)
        if (timeout <= 57.5f)
        {
            spritesGO[6].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[6].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 56.0f)
        if (timeout <= 55.0f)
        {
            spritesGO[7].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[7].GetComponent<SpriteRenderer>().enabled = false;
        
        //if (timeout <= 54.0f)
        if (timeout <= 52.5f)
        {
            spritesGO[8].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[8].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 52.0f)
        if (timeout <= 50.0f)
        {
            spritesGO[9].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[9].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 50.0f)
        if (timeout <= 47.5f)
        {
            spritesGO[10].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[10].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 48.0f)
        if (timeout <= 45.0f)
        {
            spritesGO[11].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[11].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 46.0f)
        if (timeout <= 42.5f)
        {
            spritesGO[12].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[12].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 44.0f)
        if (timeout <= 40.0f)
        {
            spritesGO[13].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[13].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 42.0f)
        if (timeout <= 37.5f)
        {
            spritesGO[14].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[14].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 40.0f)
        if (timeout <= 35.0f)
        {
            spritesGO[15].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[15].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 38.0f)
        if (timeout <= 32.5f)
        {
            spritesGO[16].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[16].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 36.0f)
        if (timeout <= 30.0f)
        {
            spritesGO[17].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[17].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 34.0f)
        if (timeout <= 27.5f)
        {
            spritesGO[18].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[18].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 32.0f)
        if (timeout <= 25.0f)
        {
            spritesGO[19].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[19].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 30.0f)
        if (timeout <= 22.5f)
        {
            spritesGO[20].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[20].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 28.0f)
        if (timeout <= 20.0f)
        {
            spritesGO[21].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[21].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 26.0f)
        if (timeout <= 17.5f)
        {
            spritesGO[22].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[22].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 24.0f)
        if (timeout <= 15.0f)
        {
            spritesGO[23].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[23].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 22.0f)
        if (timeout <= 12.5f)
        {
            spritesGO[24].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[24].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 20.0f)
        if (timeout <= 10.0f)
        {
            spritesGO[25].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[25].GetComponent<SpriteRenderer>().enabled = false;


        //if (timeout <= 18.0f)
        if (timeout <= 7.5f)
        {
            spritesGO[26].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[26].GetComponent<SpriteRenderer>().enabled = false;

        //if (timeout <= 16.0f)
        if (timeout <= 5.0f)
        {
            spritesGO[27].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[27].GetComponent<SpriteRenderer>().enabled = false;


        //if (timeout <= 14.0f)
        if (timeout <= 2.5f)
        {
            spritesGO[28].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[28].GetComponent<SpriteRenderer>().enabled = false;


        //if (timeout <= 12.0f)
        if (timeout <= 0.0f)
        {
            spritesGO[29].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[29].GetComponent<SpriteRenderer>().enabled = false;


        /*if (timeout <= 10.0f)
        {
            spritesGO[30].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[30].GetComponent<SpriteRenderer>().enabled = false;


        if (timeout <= 8.0f)
        {
            spritesGO[31].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[31].GetComponent<SpriteRenderer>().enabled = false;


        if (timeout <= 6.0f)
        {
            spritesGO[32].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[32].GetComponent<SpriteRenderer>().enabled = false;


        if (timeout <= 4.0f)
        {
            spritesGO[33].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[33].GetComponent<SpriteRenderer>().enabled = false;


        if (timeout <= 2.0f)
        {
            spritesGO[34].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[34].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 0.0f)
        {
            spritesGO[35].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[35].GetComponent<SpriteRenderer>().enabled = false;

        */


        // TROPICAL GAME --> 2 SESSIONS --> WHEN NOT USED PUT IN COMMENT
        
        if (normalizedInput < normalizedThreshold / 2)
        {
            //disableSprites(spritesGO, 0);
            spritesGO[36].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
            spritesGO[36].GetComponent<SpriteRenderer>().enabled = false;

        if (normalizedInput > normalizedThreshold / 2 && normalizedInput < 2 * (normalizedThreshold / 2))

        {
            //disableSprites(spritesGO, 26);
            spritesGO[37].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
            spritesGO[37].GetComponent<SpriteRenderer>().enabled = false;

        if (normalizedInput > normalizedThreshold)
        {
            //disableSprites(spritesGO, 27);
            spritesGO[38].GetComponent<SpriteRenderer>().enabled = true;

            //cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, 30, zoomSpeed * Time.deltaTime);
        }
        else
            spritesGO[38].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 57.5f)
        {
            spritesGO[39].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[39].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 55.0f)
        {
            spritesGO[40].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[40].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 52.5f)
        {
            spritesGO[41].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[41].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 50.0f)
        {
            spritesGO[42].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[42].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 47.5f)
        {
            spritesGO[43].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[43].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 45.0f)
        {
            spritesGO[44].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[44].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 42.5f)
        {
            spritesGO[45].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[45].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 40.0f)
        {
            spritesGO[46].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[46].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 37.5f)
        {
            spritesGO[47].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[47].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 35.0f)
        {
            spritesGO[48].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[48].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 32.5f)
        {
            spritesGO[49].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[49].GetComponent<SpriteRenderer>().enabled = false;
        
        if (timeout <= 30.0f)
        {
            spritesGO[50].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[50].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 27.5f)
        {
            spritesGO[51].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[51].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 25.0f)
        {
            spritesGO[52].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[52].GetComponent<SpriteRenderer>().enabled = false;

        
        if (timeout <= 22.5f)
        {
            spritesGO[53].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[53].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 20.0f)
        {
            spritesGO[54].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[54].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 17.5f)
        {
            spritesGO[55].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[55].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 15.0f)
        {
            spritesGO[56].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[56].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 12.5f)
        {
            spritesGO[57].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[57].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 10.0f)
        {
            spritesGO[58].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[58].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 7.5f)
        {
            spritesGO[59].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[59].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 5.0f)
        {
            spritesGO[60].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[60].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 2.5f)
        {
            spritesGO[61].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[61].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 0.0f)
        {
            spritesGO[62].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[62].GetComponent<SpriteRenderer>().enabled = false;
        
    }

    void ZoomCamera(float target)
    {
        //float angle = Mathf.Abs((defaultFov * normalizedInput / zoomMultiplier) - defaultFov);
        float angle = Mathf.Abs((defaultFov * normalizedInput) - defaultFov);
        target = Mathf.Clamp(target, 30, 60);
        cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, target, angle / zoomDuration * Time.deltaTime);
        //cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, defaultFov * normalizedInput, zoomDuration * Time.deltaTime);
    }

}
