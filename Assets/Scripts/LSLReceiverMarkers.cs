using Assets.LSL4Unity.Scripts.AbstractInlets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LSLReceiverMarkers : AIntInlet
{
    private int marker; 
    
    public bool trial; //use this to stop FB in other scripts. if(trial)feedbackOn,else feedbackOff 
    public bool experimentEnd = false;
    //private const int startTrial = 32769;
    //private const int endTrial = 32770;
    private const int startTrial = 33282;    
    private const int endTrial = 33283;
    private const int experimentStop = 32770;


    protected override void AdditionalStart()
    {
        trial = false;
        //trial = true;
    }

    protected override void Process(int[] newSample, double timeStamp)
    {
        marker = newSample[0];
        //Debug.Log("Marker:" + marker);

        if (marker == startTrial)
        {
            trial = true;
        }
        else if (marker == endTrial)
        {
            trial = false;
        }
        else if (marker == experimentStop)
        {
            experimentEnd = true;
        }
        Debug.Log("Trial: " + trial);
    }
}
