using Assets.LSL4Unity.Scripts.AbstractInlets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* floatingCube and floatingCube2 are two alternative behaviours for the Cube. 
 * Set active only one at a time */

public class floatingCube : AFloatInlet {

	public float min;
	public float max;
	public float maxHeight;

	private Vector3 startPosition;
	private Vector3 finalPosition;

    private Vector3 currentPosition;
    //private Vector3 velocity = Vector3.zero;

    //public float maximum = 0;

    protected override void AdditionalStart() 
	{
		startPosition = transform.position;
	}


	protected override void Process(float[] newSample, double timeStamp)
	{
		float inputdata = newSample[0];
        /*
        if (inputdata > maximum)
        {
            maximum = inputdata; 
        }
        */    

		float normalizedinput = (inputdata - min) / (max - min);
		Debug.Log ("Normalized Input: " + normalizedinput);

        currentPosition = transform.position;

        finalPosition = startPosition;
		finalPosition.y += normalizedinput * maxHeight;

        //finalPosition = Vector3.SmoothDamp(currentPosition, finalPosition, ref velocity, 0.1f);
        
        //gameObject.GetComponent<Rigidbody> ().MovePosition (finalPosition);

        //gameObject.GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(startPosition, finalPosition, 0.5f));
        gameObject.GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(currentPosition, finalPosition, 0.1f));

    }


}
