using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rotator rotator;
    Grapple grapple;

	// Use this for initialization
	void Start ()
    {
        rotator = transform.GetChild(0).gameObject.GetComponent<Rotator>();
        grapple = transform.GetChild(0).GetChild(0).gameObject.GetComponent<Grapple>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hookable" && rotator.Target == collision.gameObject)
        {
            rotator.Target = null;
            rotator.Firing = false;
            rotator.Hooked = false;
            grapple.SetPositionToNormal();
        }
    }
}
