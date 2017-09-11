﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class PinSetter : MonoBehaviour {

    public int lastStandingCount = -1;    
    public Text standingDisplay;
    public float distanceToRaise = 40f;

    private float lastChangeTime;
    private bool ballEnteredBox = false;
    private Ball ball;

    // Use this for initialization
    void Start ()
    {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateDisplay();

        if (ballEnteredBox)
        {
            CheckStanding();
        }
	}

    int CountStanding()
    {
        int standing = 0;
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }
        return standing;
    }
    void UpdateDisplay()
    {
        standingDisplay.text = CountStanding().ToString();
    }
    void CheckStanding()
    {
        // Update the lastStandingCount
        int currentStanding = CountStanding();

        if(currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }
        float settleTime = 3f; // how long to wait to consider pins settled
        if ((Time.time - lastChangeTime) > settleTime) // if last changes > 3s ago
        {
            PinsHaveSettled();
        }       
    }
    void PinsHaveSettled()
    {
        lastStandingCount = -1; // indicates pins have settled and ball not back in box
        ballEnteredBox = false;
        standingDisplay.color = Color.green;
        ball.Reset();
    }
    void OnTriggerEnter(Collider collider)
    {
        GameObject thingHit = collider.gameObject;

        // Ball enters pin box

        if (thingHit.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        GameObject thingExit = collider.gameObject;

        // Pin exits pin box
        if (thingExit.GetComponent<Pin>())
        {
            Destroy(thingExit);
        }
    }
    public void RaisePins()
    {
        // raise standing pins only by distanceToRaise
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
        }
        Debug.Log("Raising Pins");
    }
    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
        Debug.Log("Lowering Pins");
    }
    public void RenewPins()
    {
        Debug.Log("Renewing Pins");
    }
}
