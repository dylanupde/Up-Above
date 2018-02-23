using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class String : MonoBehaviour {

    Rotator parentRotatorScript;                // holds the rotator script from the rotator gameobject
    GameObject arrow;                           // holds the arrow gameobject
    Vector3 normalScale;                        // holds what the scale should be when it's not really doing stuff

    // Use this for initialization
    void Start ()
    {
        // Make all the declared variables be what they're supposed to be
        parentRotatorScript = transform.parent.gameObject.GetComponent<Rotator>();
        arrow = GameObject.Find("Arrow");
        normalScale = transform.localScale;
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        // If the arrow is being fired or is hooked to something...
        if (parentRotatorScript.CurrentState != State.Normal)
        {
            // ...stretch as far as the arrow is
            float newLength = (arrow.transform.position - transform.position).magnitude;
            transform.localScale = new Vector3(normalScale.x, newLength, normalScale.z);
        }
        // Otherwise...
        else
        {
            // ...just be your normal non-stretched self
            transform.localScale = normalScale;
        }
	}
}
