using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.LSL4Unity.Scripts.AbstractInlets;
using System;

public class LSLReceiver : AFloatInlet
{
    public float input;
    public float normalizedInput;
    //public float normalizedThreshold;
    private float min;
    private float max;
    private float threshold;

    protected override void Process(float[] newSample, double timeStamp)
    {
        input = newSample[0];
        //Debug.Log("Input: "+input);

        min = valueScript.min;
        max = valueScript.max;
        normalizedInput = (input - min) / (max - min);

    }

    
}
