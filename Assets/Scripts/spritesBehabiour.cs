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

    public float smoothTime = 0.3f;

    public float zoomSpeed = 3f;
    public float zoomout = 6f;

    public Vector3 velocity = Vector3.zero;

    public GameObject[] spritesGO;

    private float scallingFactor = 3.4f;

    public static float timeout = 20.0f;

    public Camera cam;

    void Start()
    {
        //Sprites
        initSprites();
        //spritesGO[0].GetComponent<SpriteRenderer>().enabled = true;  //take the comment if UNDERWATER GAME
        spritesGO[26].GetComponent<SpriteRenderer>().enabled = true; //take the comment if TROPICAL GAME
        Debug.Log("Start");

    }

    void initSprites()
    {
        for (int i = 0; i <= 46; i++)
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

        // UNDERWATER GAME --> 2 SESSIONS --> WHEN NOT USED PUT IN COMMENT
        /*
        if (normalizedInput < normalizedThreshold/2)
        {
            //disableSprites(spritesGO, 0);
            spritesGO[0].GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("1");
        }
        
        if (normalizedInput < 2* (normalizedThreshold/2) && normalizedInput > normalizedThreshold / 2)

        {
            disableSprites(spritesGO, 0);
            spritesGO[1].GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("2");
        }
        /*
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
            spritesGO[4].GetComponent<SpriteRenderer>().enabled = true;

            cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, x, zoomSpeed * Time.deltaTime);

        }
         
        if (timeout <= 19.0f)
        {
            spritesGO[6].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[6].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 18.0f)
        {
            spritesGO[7].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[7].GetComponent<SpriteRenderer>().enabled = false;
        
        if (timeout <= 17.0f)
        {
            spritesGO[8].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[8].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 16.0f)
        {
            spritesGO[9].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[9].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 15.0f)
        {
            spritesGO[10].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[10].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 14.0f)
        {
            spritesGO[11].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[11].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 13.0f)
        {
            spritesGO[12].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[12].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 12.0f)
        {
            spritesGO[13].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[13].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 11.0f)
        {
            spritesGO[14].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[14].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 10.0f)
        {
            spritesGO[15].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[15].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 9.0f)
        {
            spritesGO[16].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[16].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 8.0f)
        {
            spritesGO[17].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[17].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 7.0f)
        {
            spritesGO[18].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[18].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 6.0f)
        {
            spritesGO[19].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[19].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 5.0f)
        {
            spritesGO[20].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[20].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 4.0f)
        {
            spritesGO[21].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[21].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 3.0f)
        {
            spritesGO[22].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[22].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 2.0f)
        {
            spritesGO[23].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[23].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 1.0f)
        {
            spritesGO[24].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[24].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 0.0f)
        {
            spritesGO[25].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[25].GetComponent<SpriteRenderer>().enabled = false;

        */


        // TROPICAL GAME --> 2 SESSIONS --> WHEN NOT USED PUT IN COMMENT
        
        if (normalizedInput < normalizedThreshold / 2)
        {
            //disableSprites(spritesGO, 0);
            spritesGO[26].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
            spritesGO[26].GetComponent<SpriteRenderer>().enabled = false;

        if (normalizedInput > normalizedThreshold / 2 && normalizedInput < 2 * (normalizedThreshold / 2))

        {
            //disableSprites(spritesGO, 26);
            spritesGO[27].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
            spritesGO[27].GetComponent<SpriteRenderer>().enabled = false;

        if (normalizedInput > normalizedThreshold)
        {
            //disableSprites(spritesGO, 27);
            spritesGO[28].GetComponent<SpriteRenderer>().enabled = true;

            cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, x, zoomSpeed * Time.deltaTime);

        }
        else
            spritesGO[28].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 19.0f)
        {
            spritesGO[29].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[29].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 18.0f)
        {
            spritesGO[30].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[30].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 17.0f)
        {
            spritesGO[31].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[31].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 16.0f)
        {
            spritesGO[32].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[32].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 15.0f)
        {
            spritesGO[33].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[33].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 14.0f)
        {
            spritesGO[34].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[34].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 13.0f)
        {
            spritesGO[35].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[35].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 12.0f)
        {
            spritesGO[36].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[36].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 11.0f)
        {
            spritesGO[37].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[37].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 10.0f)
        {
            spritesGO[38].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[38].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 9.0f)
        {
            spritesGO[39].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[39].GetComponent<SpriteRenderer>().enabled = false;
        
        if (timeout <= 8.0f)
        {
            spritesGO[40].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[40].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 7.0f)
        {
            spritesGO[41].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[41].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 6.0f)
        {
            spritesGO[42].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[42].GetComponent<SpriteRenderer>().enabled = false;

        
        if (timeout <= 5.0f)
        {
            spritesGO[43].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[43].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 4.0f)
        {
            spritesGO[44].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[44].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 3.0f)
        {
            spritesGO[45].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[45].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 2.0f)
        {
            spritesGO[46].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[46].GetComponent<SpriteRenderer>().enabled = false;
        /*
        if (timeout <= 1.0f)
        {
            spritesGO[24].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[24].GetComponent<SpriteRenderer>().enabled = false;

        if (timeout <= 0.0f)
        {
            spritesGO[25].GetComponent<SpriteRenderer>().enabled = true;

        }
        else
            spritesGO[25].GetComponent<SpriteRenderer>().enabled = false;

        */        
    }
  
}
