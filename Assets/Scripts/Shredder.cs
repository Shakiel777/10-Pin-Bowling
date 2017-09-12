using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

    void OnTriggerExit(Collider collider)
    {
        GameObject thingExit = collider.gameObject;

        // Pin exits pin box
        if (thingExit.GetComponent<Pin>())
        {
            Destroy(thingExit);
        }
    }
}
