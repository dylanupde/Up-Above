using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    GameObject target;             // holds the target to follow

	// Use this for initialization
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Make your position their position, with some offset
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 5.5f, transform.position.z);
	}
}
