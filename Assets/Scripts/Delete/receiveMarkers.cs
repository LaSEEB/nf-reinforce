using Assets.LSL4Unity.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class receiveMarkers : MonoBehaviour {

    public LSLMarkerStream markerStream;
    private int markers;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        markerStream.Write(markers);
        Debug.Log("Marker: "+markers);
		
	}
}
