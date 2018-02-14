using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class String : MonoBehaviour {

    Rotator parentRotatorScript;
    GameObject arrow;
    Vector3 normalScale;

    // Use this for initialization
    void Start ()
    {
        parentRotatorScript = transform.parent.gameObject.GetComponent<Rotator>();
        arrow = GameObject.Find("Arrow");
        normalScale = transform.localScale;
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        if (parentRotatorScript.Firing || parentRotatorScript.Hooked)
        {
            float newLength = (arrow.transform.position - transform.position).magnitude;
            transform.localScale = new Vector3(normalScale.x, newLength, normalScale.z);
        }
        else
        {
            transform.localScale = normalScale;
        }
	}
}
