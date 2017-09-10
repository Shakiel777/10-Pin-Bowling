using UnityEngine;
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
        float newX = 270f - transform.rotation.eulerAngles.x;
        float tiltX = (newX < 180f) ? newX : 360 - newX;
        float tiltZ = (transform.rotation.eulerAngles.z < 180f) ? transform.eulerAngles.z : 360 - transform.rotation.eulerAngles.z;
        if (tiltX > standingThreshold || tiltZ > standingThreshold)
        {
            return false;
        }
        return true;
    }
}
