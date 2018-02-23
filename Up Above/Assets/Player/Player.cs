using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rotator rotator;                    // the rotator script that's attached to this object's rotator
    Grapple grapple;                    // the grapple script that's attached to this object's arrow
    float startingHeight;
    float height;

    // PROPERTIES
#region
    public float Height
    {
        get { return height; }
    }    

#endregion

    // Use this for initialization
    void Start ()
    {
        // Get those declared variables
        rotator = transform.GetChild(0).gameObject.GetComponent<Rotator>();
        grapple = transform.GetChild(0).GetChild(0).gameObject.GetComponent<Grapple>();

        startingHeight = transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
        height = transform.position.y - startingHeight;
	}

    // When you collide with a trigger...
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If it was hookable AND what your actual target...
        if (collision.gameObject.tag == "Hookable" && rotator.Target == collision.gameObject)
        {
            // Let the rotator know that you have no target and you're not firing/hooked to anything anymore
            rotator.Target = null;
            rotator.CurrentState = State.Normal;

            // Tell the arrow it can go back to its normal position again
            grapple.SetPositionToNormal();
        }
    }
}
