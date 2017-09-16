using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public Vector3 launchVelocity;
    public bool inPlay = false;

    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private Vector3 ballStartPos;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        ballStartPos = transform.position;
	}

    public void Launch(Vector3 velocity)
    {
        if(inPlay == false)
        {
            inPlay = true;

            rigidBody.useGravity = true;
            GetComponent<Rigidbody>().velocity = velocity;
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        
    }
    public void Reset()
    {
        inPlay = false;
        rigidBody.useGravity = false;
        transform.position = ballStartPos;
        transform.rotation = Quaternion.identity;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
    }
}
