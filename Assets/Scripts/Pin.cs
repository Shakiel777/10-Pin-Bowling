﻿using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour
{

    public float standingThreshold = 3f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsStanding()
    {
        float tiltX = (transform.eulerAngles.x < 180f) ? transform.eulerAngles.x : 360 - transform.eulerAngles.x;
        float tiltZ = (transform.eulerAngles.z < 180f) ? transform.eulerAngles.z : 360 - transform.eulerAngles.z;
        if (tiltX > standingThreshold || tiltZ > standingThreshold)
        {
            return false;
        }
        return true;
    }
}
