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

    private Color lerpedColor;

    public float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;

    // public GameObject sphere;
    //public List<Sprite> Sprites;
    public GameObject[] spritesGO;

    private float scallingFactor = 3.4f;

    void Start()
    {

        //Sprites
        initSprites();
        spritesGO[0].GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log("Start");

    }

    void initSprites()
    {
        for (int i = 1; i < 10; i++)
        {
          spritesGO[i].GetComponent<SpriteRenderer>().enabled = false;

        }
    }

    void disableSprites(GameObject[] a,int now)
    {
        for (int i = 0; i < 10; i++)
        {
            if (i!=now)
                spritesGO[i].GetComponent<SpriteRenderer>().enabled = false;

        }
    }

    void Update()
    {
        normalizedInput = receiver.normalizedInput;
        normalizedThreshold = valueScript.normalizedThreshold;
        Debug.Log(normalizedInput);

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


        //ToDO: Lerp
        // https://forum.unity.com/threads/lerp-between-two-materials.490161/
    }
}
