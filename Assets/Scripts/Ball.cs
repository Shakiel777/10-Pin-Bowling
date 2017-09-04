using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private AudioSource audioSource;
    private Rigidbody rigidBody;

    private bool hasStarted = false;
    public Vector3 launchVelocity;


	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
        Launch();

    }

    private void Launch()
    {
        if (!hasStarted)
        {
            // waiting for mouse click to launch
            if (Input.GetMouseButtonDown(0))
            {
                print(" Mouse Clicked, launch ball");
                hasStarted = true;
                this.GetComponent<Rigidbody>().velocity = launchVelocity;
                audioSource.Play();
            }
        }
    }
}
