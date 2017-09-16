using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class PinSetter : MonoBehaviour {
      
    public Text standingDisplay;
    public GameObject PinSet;

    private bool ballOutOfPlay = false;
    private int lastSettledCount = 10;
    private int lastStandingCount = -1;
    private float lastChangeTime;

    private Ball ball;
    private Animator animator;
    private ActionMaster actionMaster = new ActionMaster(); // needs to be here, only want one instance

    // Use this for initialization
    void Start ()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateDisplay();

        if (ballOutOfPlay)
        {
            UpdateStandingCountAndSettle();
        }
	}

    public void SetBallOutOfPlay()
    {
        standingDisplay.color = Color.red;
        ballOutOfPlay = true;
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
    void UpdateStandingCountAndSettle()
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
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;
        

        ActionMaster.Action action = actionMaster.Bowl(pinFall);
        Debug.Log("Pinfall: " + pinFall + " " + action);

        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Don't know how to handle End Game yet");
        }

        lastStandingCount = -1; // indicates pins have settled and ball not back in box
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;
        Debug.Log("call to change color green");
        ball.Reset();
    }
    //void OnTriggerEnter(Collider collider)
    //{
    //    GameObject thingHit = collider.gameObject;

    //    // Ball enters pin box

    //    if (thingHit.GetComponent<Ball>())
    //    {
    //        ballOutOfPlay = true;
    //        standingDisplay.color = Color.red;
    //    }
    //}

    public void RaisePins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
            // pin.transform.rotation = Quaternion.Euler(270f, 0, 0);
        }
    }
    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }
    public void RenewPins()
    {
        Instantiate(PinSet, new Vector3(0, 80, 0), Quaternion.identity);
    }
}
