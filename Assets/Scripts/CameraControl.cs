﻿using UnityEngine;
using System.Collections;


public class CameraControl : MonoBehaviour {

    public Ball ball;
    private Vector3 offset ;

    // Use this for initialization
    void Start ()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        offset = transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.z <= 1775f)
        {
            transform.position = ball.transform.position + offset;
        }
	}
}