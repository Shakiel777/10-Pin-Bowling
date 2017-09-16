using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinCounter : MonoBehaviour {

    public Text standingDisplay;

    private GameManager gameManager;
    private bool ballOutOfPlay = false;
    private int lastSettledCount = 10;
    private int lastStandingCount = -1;
    private float lastChangeTime;

    // Use this for initialization
    void Start ()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateDisplay();

        if (ballOutOfPlay)
        {
            UpdateStandingCountAndSettle();
            // standingDisplay.color = Color.red;
        }
    }

    public void Reset()
    {
        lastSettledCount = 10;
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            ballOutOfPlay = true;
        }
    }
    public void SetBallOutOfPlay()
    {
        ballOutOfPlay = true;
    }
    void UpdateDisplay()
    {
        standingDisplay.text = CountStanding().ToString();
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

    void UpdateStandingCountAndSettle()
    {
        standingDisplay.color = Color.red;
        // Update the lastStandingCount
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
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

        gameManager.Bowl(pinFall);

        lastStandingCount = -1; // indicates pins have settled and ball not back in box
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;
    }
}
