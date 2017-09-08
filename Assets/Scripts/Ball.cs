﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public Vector3 launchVelocity;

    public bool inPlay = false;
    private Rigidbody rigidBody;
    private AudioSource audioSource;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
	}

    public void Launch(Vector3 velocity)
    {
        inPlay = true;

        rigidBody.useGravity = true;
        GetComponent<Rigidbody>().velocity = velocity;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
