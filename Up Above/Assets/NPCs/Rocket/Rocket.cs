using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    [SerializeField] float acceleration = 5f;
    [SerializeField] float timeUntilDeath = 5f;
    float velocity = 0f;
    float startTime;
    float distanceUntilTakeOff = 4f;
    bool started;
    GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (started)
        {
            transform.Translate(Vector3.up * velocity * Time.deltaTime);
            velocity += acceleration * Time.deltaTime;

            if (Time.time - startTime > timeUntilDeath)
            {
                Destroy(gameObject);
            }
        }
        else if (player.transform.position.y + distanceUntilTakeOff > transform.position.y && !started)
        {
            started = true;
            startTime = Time.time;
        }
	}
}
