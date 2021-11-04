using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween 
{
    // private Member Variables (Getters and Setters)
    public Transform objectTransform { get; private set; }
    public Vector3 startPos { get; private set; }
    public Vector3 endPos { get; private set; }
    public float startTime { get; private set; }
    public float duration { get; private set; }

    // Constructor
    public Tween(Transform objectTransform, Vector3 startPos, Vector3 endPos, float starttime, float duration)
    {
        this.objectTransform = objectTransform;
        this.startPos = startPos;
        this.endPos = endPos;
        this.startTime = startTime;
        this.duration = duration;
    }
}
