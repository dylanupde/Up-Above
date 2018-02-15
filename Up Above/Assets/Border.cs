using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour {

    Vector3 positionToChange;                   

	// Use this for initialization
	void Start ()
    {
        positionToChange = new Vector3(76f, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hookable")
        {
            if (transform.position.x > 0f)
            {
                collision.gameObject.transform.position = collision.gameObject.transform.position - positionToChange;
            }
            else
            {
                collision.gameObject.transform.position = collision.gameObject.transform.position + positionToChange;
            }
        }
    }
}
