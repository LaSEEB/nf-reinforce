using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayScript : MonoBehaviour
{
	void Start ()
    {
        Debug.Log("Displays: "+Display.displays.Length);
        if (Display.displays.Length > 1)
        {
            Display.displays[1].Activate();
            values.displays = 2;
            
        }
    }
}
