using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class PinSetter : MonoBehaviour {
      
    public GameObject PinSet;

    private Animator animator;
    private PinCounter pinCounter;

    // private ActionMaster actionMaster = new ActionMaster(); // needs to be here, only want one instance

    // Use this for initialization
    void Start ()
    {
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
        animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void RaisePins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
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

    public void PerformAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Don't know how to handle End Game yet");
        }
    }
}
