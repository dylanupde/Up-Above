using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour {

    [SerializeField] float launchSpeed = 5f;

    Rotator parentRotatorScript;
    Vector3 normalPosition;
    float fireStartTime;

    [SerializeField] float maxTimeBeforeReturn = 1f;

	// Use this for initialization
	void Start ()
    {
        parentRotatorScript = transform.parent.gameObject.GetComponent<Rotator>();
        normalPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!parentRotatorScript.Hooked && !parentRotatorScript.Firing)
            {
                parentRotatorScript.Firing = true;
                fireStartTime = Time.time;
            }
        }

        if (parentRotatorScript.Firing)
        {
            transform.Translate(Vector3.up * launchSpeed * Time.deltaTime);
            if (Time.time - fireStartTime > maxTimeBeforeReturn)
            {
                SetPositionToNormal();
                parentRotatorScript.Firing = false;
            }
        }
        else if (parentRotatorScript.Hooked)
        {
            float extensionLength = (parentRotatorScript.Target.transform.position - parentRotatorScript.transform.position).magnitude;
            transform.localPosition = Vector3.up * extensionLength;
        }
	}
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hookable" && parentRotatorScript.Firing)
        {
            parentRotatorScript.Target = collision.gameObject;
            parentRotatorScript.Firing = false;
            parentRotatorScript.Hooked = true;
        }
    }



    public void SetPositionToNormal()
    {
        transform.localPosition = normalPosition;
    }
}
