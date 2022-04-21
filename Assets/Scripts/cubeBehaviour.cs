using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeBehaviour : MonoBehaviour
{
    public LSLReceiver receiver;
    private float normalizedInput;

    public bool floatOn;

    public float maxHeight;
    private Vector3 position;


    void Start ()
    {
        position = transform.position; //position = startPosition
	}

    void FixedUpdate()
    {
        normalizedInput = receiver.normalizedInput;

        if (floatOn)
        {
            
            position.y = normalizedInput * maxHeight; //new position
            gameObject.GetComponent<Rigidbody>().MovePosition(position);
            
        }

    }
}