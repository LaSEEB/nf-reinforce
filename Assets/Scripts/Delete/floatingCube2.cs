using Assets.LSL4Unity.Scripts.AbstractInlets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* floatingCube and floatingCube2 are two alternative behaviours for the Cube. 
 * Set active only one at a time */

public class floatingCube2 : AFloatInlet {

	public float min;
	public float max;
	public float threshold;
    public float maxHeight;

	private float force = 80f;

	protected override void Process(float[] newSample, double timeStamp)
	{
		float inputdata = newSample[0];

		float normalizedinput = (inputdata - min) / (max - min);
		//Debug.Log ("Normalized Input: " + normalizedinput);

		if(normalizedinput > threshold && transform.position.y < maxHeight)
		{
			gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * force);
            transform.rotation = Random.rotation;
            //Debug.Log ("Normalized Input: " + normalizedinput);
        }


	}


}
