﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour {

    [SerializeField] float launchSpeed = 5f;                    // holds the speed at which the "bullet" will fly
    [SerializeField] float maxTimeBeforeReturn = 1f;            // holds the maximum time the hookshot will fly off before returning

    Rotator parentRotatorScript;                                // holds the rotator script on your parent
    Vector3 normalPosition;                                     // holds the position that the object normally sits at
    float fireStartTime;                                        // holds the time that you most recently fired


	// Use this for initialization
	void Start ()
    {
        // Set those declared variables
        parentRotatorScript = transform.parent.gameObject.GetComponent<Rotator>();
        normalPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // HANDLES CLICKING TO FIRE:
        // If the mousebutton is pressed...
        if (Input.GetMouseButtonDown(0))
        {
            // ...if you're not already hooked and firing...
            if (!parentRotatorScript.Hooked && !parentRotatorScript.Firing)
            {
                // ...mark that you're firing and record the time
                parentRotatorScript.Firing = true;
                fireStartTime = Time.time;
            }
        }

        // HANDLES FIRING
        // If you're firing...
        if (parentRotatorScript.Firing)
        {
            // ...move yourself up in your own local axis
            transform.Translate(Vector3.up * launchSpeed * Time.deltaTime);

            // If your shot has been fired for longer than allowed...
            if (Time.time - fireStartTime > maxTimeBeforeReturn)
            {
                // ...return to normal position and flag that you're not firing anymore
                SetPositionToNormal();
                parentRotatorScript.Firing = false;
            }
        }

        // HANDLES IF YOU'RE HOOKED TO A THING
        // Otherwise, if you're hooked to a legitimate target...
        else if (parentRotatorScript.Hooked)
        {
            // ...find out how far you should be extended, and be there
            float extensionLength = (parentRotatorScript.Target.transform.position - parentRotatorScript.transform.position).magnitude;
            transform.localPosition = Vector3.up * extensionLength;
        }
	}
    
    // Handles hen you hit another gameobject's trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the object was hookable and you're in the middle of a shot being fired...
        if (collision.gameObject.tag == "Hookable" && parentRotatorScript.Firing)
        {
            // Assign that object as your target, and flag that you're hooked and no longer firing
            parentRotatorScript.Target = collision.gameObject;
            parentRotatorScript.Firing = false;
            parentRotatorScript.Hooked = true;
        }
    }


    /// <summary>
    /// Just puts you back in your normal, unfired place
    /// </summary>
    public void SetPositionToNormal()
    {
        transform.localPosition = normalPosition;
    }
}
