using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    
    bool firing = false;
    bool hooked = false;
    GameObject target;
    Rigidbody2D playerRB2D;

    [SerializeField] float flySpeed = 10;

    // ::::::PROPERTIES::::::
    #region
    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }

    public bool Firing
    {
        get { return firing; }
        set { firing = value; }
    }

    public bool Hooked
    {
        get { return hooked; }
        set { hooked = value; }
    }
    #endregion

    // Use this for initialization
    void Start ()
    {
        playerRB2D = transform.parent.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hooked)
        {
            RotateToPointTo(target.transform.position);
            Vector2 flingDirection = (target.transform.position - transform.position).normalized;
            playerRB2D.velocity = flingDirection * flySpeed * Time.deltaTime;
        }

        if (!hooked && !firing)
        {
            RotateToPointTo(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }






    // :::::METHODS:::::
    void RotateToPointTo(Vector3 inputVector)
    {
        Vector3 positionDifference = inputVector - transform.position;
        positionDifference.Normalize();

        float zRotation = Mathf.Atan2(positionDifference.y, positionDifference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, zRotation - 90);

        if (zRotation - 90 > -270 && zRotation - 90 < -180)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else if (zRotation - 90f < -90f && zRotation - 90 > -180)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
    }
}
