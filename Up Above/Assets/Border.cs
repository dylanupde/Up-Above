using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour {

    bool imLeft = false;
    GameObject leftBorder;
    GameObject rightBorder;
    float distanceToTeleport;
    Vector3 positionToChangeTeleport;
    float distanceToTarget;

    GameObject target;

	// Use this for initialization
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        if (transform.position.x < target.transform.position.x)
        {
            imLeft = true;
        }

        leftBorder = GameObject.Find("Border left");
        rightBorder = GameObject.Find("Border right");

        distanceToTeleport = Mathf.Abs(rightBorder.transform.position.x - leftBorder.transform.position.x) - GetComponent<BoxCollider2D>().size.x - 5f;
        positionToChangeTeleport = new Vector3(distanceToTeleport, 0, 0);

        distanceToTarget = transform.position.x - target.transform.position.x;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(target.transform.position.x + distanceToTarget, transform.position.y, transform.position.z);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hookable" || collision.gameObject.tag == "Decoration")
        {
            if (imLeft)
            {
                collision.gameObject.transform.position += positionToChangeTeleport;
            }
            else
            {
                collision.gameObject.transform.position -= positionToChangeTeleport;
            }
        }
    }
}
