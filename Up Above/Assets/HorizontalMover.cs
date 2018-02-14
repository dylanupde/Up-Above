using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover : MonoBehaviour {

    [SerializeField] bool movingRight;              // tells if the bird should be moving right or not
    [SerializeField] float speed = 3f;              // holds the speed

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // If the bird is supposed to be moving right...
        if (movingRight)
        {
            // ...move it right
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        // Otherwise...
        else
        {
            // ...move it left
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
	}
}
