using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover : MonoBehaviour {

    [SerializeField] bool movingRight;              // tells if the bird should be moving right or not
    [SerializeField] float speed = 1f;              // holds the speed
    [SerializeField] bool randomizeMovementSpeed = true;
    [SerializeField] float randomSpeedRange = 0.5f;

	// Use this for initialization
	void Start ()
    {
        if (!movingRight)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        if (randomizeMovementSpeed)
        {
            speed += Random.Range(-randomSpeedRange, randomSpeedRange);
        }
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
