using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class spritesBehabiour : MonoBehaviour
{
    public LSLReceiver receiver;
    private float normalizedInput;
    private float normalizedThreshold;

    public bool smoothOn;
    public bool scaleOn;
    public bool soundOn;
    public bool useColor;
    public bool floatOn;

    private Color lerpedColor;

    public float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;

    // public GameObject sphere;
    //public List<Sprite> Sprites;
    public GameObject[] spritesGO;


    private float scallingFactor = 3.4f;

    public static float timeout = 10.0f;


    void Start()
    {

        //Sprites
        initSprites();
        spritesGO[0].GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log("Start");

    }

    void initSprites()
    {
        for (int i = 0; i <= 10; i++)
        {
          spritesGO[i].GetComponent<SpriteRenderer>().enabled = false;

        }
    }

    void disableSprites(GameObject[] a,int now)
    {
        for (int i = 0; i < 11; i++)
        {
            if (i!=now)
                spritesGO[i].GetComponent<SpriteRenderer>().enabled = false;

        }
    }

    void Update()
    {
        normalizedInput = receiver.normalizedInput;
        normalizedThreshold = valueScript.normalizedThreshold;
        //Debug.Log(normalizedInput);

        if (normalizedInput > 0.6f)
        {
            timeout -= Time.deltaTime;
            Debug.Log("timeout: "+ timeout + " input: " + normalizedInput);
        }
        else
        {
            timeout = 10.0f;
            Debug.Log("RESET: " + timeout);
        }

        if (normalizedInput > 0.1f && normalizedInput < 0.2f)

        {
            disableSprites(spritesGO, 1);
            spritesGO[1].GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("1");
        }

        if (normalizedInput > 0.2f && normalizedInput < 0.3f)

        {
            disableSprites(spritesGO, 2);
            spritesGO[2].GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("2");
        }
        if (normalizedInput > 0.3f && normalizedInput < 0.4f)

        {
            disableSprites(spritesGO, 3);
            spritesGO[3].GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("3");
        }
        if (normalizedInput > 0.4f && normalizedInput < 0.5f)

        {
            disableSprites(spritesGO, 4);
            spritesGO[4].GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("entrou");

        }

        if (normalizedInput > 0.5f && normalizedInput < 0.6f)

        {
            disableSprites(spritesGO, 5);
            spritesGO[5].GetComponent<SpriteRenderer>().enabled = true;

        }

        if (normalizedInput > 0.6f)
        {
            disableSprites(spritesGO, 6);
            spritesGO[6].GetComponent<SpriteRenderer>().enabled = true;
            //timeout = 1.0f;
            Debug.Log("2s ABOVE THRESHOLD!");

        }

        if (normalizedInput > 0.6f && timeout <= 8.0f)
        {
            disableSprites(spritesGO, 6);
            spritesGO[6].GetComponent<SpriteRenderer>().enabled = true;
            disableSprites(spritesGO, 7);
            spritesGO[7].GetComponent<SpriteRenderer>().enabled = true;
            //timeout = 1.0f;
            Debug.Log("2s ABOVE THRESHOLD!");

        }

        if (normalizedInput > 0.6f && timeout <= 6.0f)
        {
            disableSprites(spritesGO, 6);
            spritesGO[6].GetComponent<SpriteRenderer>().enabled = true;
            disableSprites(spritesGO, 7);
            spritesGO[7].GetComponent<SpriteRenderer>().enabled = true;
            disableSprites(spritesGO, 8);
            spritesGO[8].GetComponent<SpriteRenderer>().enabled = true;
            //timeout = 1.0f;
            Debug.Log("4s ABOVE THRESHOLD!");

        }

        if (normalizedInput > 0.6f && timeout <= 4.0f)
        {
            disableSprites(spritesGO, 6);
            spritesGO[6].GetComponent<SpriteRenderer>().enabled = true;
            disableSprites(spritesGO, 7);
            spritesGO[7].GetComponent<SpriteRenderer>().enabled = true;
            disableSprites(spritesGO, 9);
            spritesGO[9].GetComponent<SpriteRenderer>().enabled = true;
            //timeout = 1.0f;
            Debug.Log("6s ABOVE THRESHOLD!");

        }

        if (normalizedInput > 0.6f && timeout <= 2.0f)
        {
            disableSprites(spritesGO, 6);
            spritesGO[6].GetComponent<SpriteRenderer>().enabled = true;
            disableSprites(spritesGO, 7);
            spritesGO[7].GetComponent<SpriteRenderer>().enabled = true;
            disableSprites(spritesGO, 8);
            spritesGO[8].GetComponent<SpriteRenderer>().enabled = true;
            disableSprites(spritesGO, 10);
            spritesGO[10].GetComponent<SpriteRenderer>().enabled = true;
            //timeout = 1.0f;
            Debug.Log("8s ABOVE THRESHOLD!");

        }

        if (normalizedInput > 0.6f && timeout <= 0.0f)
        {
            disableSprites(spritesGO, 6);
            spritesGO[6].GetComponent<SpriteRenderer>().enabled = true;
            disableSprites(spritesGO, 7);
            spritesGO[7].GetComponent<SpriteRenderer>().enabled = true;
            disableSprites(spritesGO, 8);
            spritesGO[8].GetComponent<SpriteRenderer>().enabled = true;
            disableSprites(spritesGO, 9);
            spritesGO[9].GetComponent<SpriteRenderer>().enabled = true;
            disableSprites(spritesGO, 11);
            spritesGO[11].GetComponent<SpriteRenderer>().enabled = true;
            //timeout = 1.0f;
            Debug.Log("10s ABOVE THRESHOLD!");

        }

        /* normalizedInput = receiver.normalizedInput;
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
         //Debug.Log(normalizedInput);

         //Assuming that a sample contains at least 3 values for x,y,z
         float x = 0.1f + normalizedInput * scallingFactor;

         // SIZE AND SMOOTHNESS OF THE SPHERE
         // we map the data to the scale factors
         var targetScale = new Vector3(x, x, x); //defining the size of the sphere
         Vector3 scallingSize;
         scallingSize = smoothOn ? Vector3.SmoothDamp(transform.localScale, targetScale, ref velocity, smoothTime) : targetScale;
         //sphere.transform.localScale = scaleOn ? scallingSize : transform.localScale;

         // COLOR
         //sphere.GetComponent<Renderer>().material.color = normalizedInput < normalizedThreshold ? Color.red : Color.white;

         //lerpedColor = Color.Lerp(Color.white, Color.cyan, Mathf.PingPong(normalizedInput, 1));
         //sphere.GetComponent<Renderer>().material.color = useColor ? lerpedColor : Color.white;

     */
    }
    //ToDO: Lerp
    // https://forum.unity.com/threads/lerp-between-two-materials.490161/  
  
}
