using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
using System;

// Don't forget the Namespace import
using Assets.LSL4Unity.Scripts;

public class RandomMarker : MonoBehaviour {

	public LSLMarkerStream markerStream;
    public int markers;

    void Start () {

        Debug.Log("Start");
        Assert.IsNotNull(markerStream, "You forgot to assign the reference to a marker stream implementation!");

		if (markerStream != null) {
			StartCoroutine(WriteContinouslyMarkerEachSecond());
            
        }
    }

    IEnumerator WriteContinouslyMarkerEachSecond()
    {
        while (true)
        {
            markerStream.Write(markers);
            Debug.Log("Marker: " + markers);

            yield return new WaitForSecondsRealtime(1f);
        }
    }
    /*
	IEnumerator WriteContinouslyMarkerEachSecond()
	{
		while (true)
		{
			// an example for demonstrating the usage of marker stream
			var currentMarker = GetARandomMarker();
			//markerStream.Write(currentMarker.ToString());
			//Debug.Log("currentMarker " + currentMarker);
			markerStream.Write(currentMarker);
            Debug.Log("currentMarker " + currentMarker);
            yield return new WaitForSecondsRealtime(1f);
		}
	}
/*
	private string GetARandomMarker()
	{
		return UnityEngine.Random.value > 0.5 ? "A" : "B";
    }

    private int GetARandomMarker()
    {
        //return UnityEngine.Random.value > 0.5 ? "A" : "B";
        //return UnityEngine.Random.value > 0.5 ? 111 : 000;
		//Debug.Log("marker");
		return 1;
    }
    */
}
