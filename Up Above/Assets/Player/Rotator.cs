﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotator : MonoBehaviour {


    State currentState;
    GameObject target;                      // holds the gameobject that we're hooked to
    Rigidbody2D playerRB2D;
    Vector3 targetPositionOffset;

    [SerializeField] float flySpeed = 10;

    // ::::::PROPERTIES::::::
    #region
    /// <summary>
    /// All this shit just holds the variables we want to be public, but if we actually call it public then it's gonna show up in the inspector, which would look stupid.
    /// </summary>
    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }

    public State CurrentState
    {
        get { return currentState; }
        set { currentState = value; }
    }

    public Vector3 TargetPositionOffset
    {
        get { return targetPositionOffset; }
        set { targetPositionOffset = value; }
    }
    #endregion

    // Use this for initialization
    void Start ()
    {
        // Grab hold of the player's rigidbody so we can control it from here
        playerRB2D = transform.parent.gameObject.GetComponent<Rigidbody2D>();

        currentState = State.Normal;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // If you're hooked to something...
        if (currentState == State.Hooked)
        {
            // ...point the hookshot to it (taking into account the offset) and sling yourself in its direction
            RotateToPointTo(target.transform.position + targetPositionOffset);
            Vector2 flingDirection = (target.transform.position - transform.position).normalized;
            playerRB2D.velocity = flingDirection * flySpeed * Time.deltaTime;
        }
        // Otherwise, if you're not hooked or firing...
        else if (currentState == State.Normal)
        {
            // ...rotate the hookshot to point to the mouse
            RotateToPointTo(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }






    // :::::METHODS:::::
    /// <summary>
    /// Makes the gun point to whatever vector you give it
    /// </summary>
    /// <param name="inputVector"></param>
    void RotateToPointTo(Vector3 inputVector)
    {
        // Get the difference in position and make its magnitude 1
        Vector3 positionDifference = inputVector - transform.position;
        positionDifference.Normalize();

        // Do some basic trig to find out what angle to point to
        float zRotation = Mathf.Atan2(positionDifference.y, positionDifference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, zRotation - 90);

        // Clamp the hookshot gun to only point upwards, long story short.
        if (zRotation - 90 > -270 && zRotation - 90 < -180)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else if (zRotation - 90f < -90f && zRotation - 90 > -180)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
    }
}
