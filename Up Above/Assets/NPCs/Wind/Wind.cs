using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

    [SerializeField] bool blowingRight = true;
    [SerializeField] float blowingForce = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (blowingRight)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * blowingForce * Time.deltaTime, ForceMode2D.Impulse);
            }
            else
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * blowingForce * Time.deltaTime, ForceMode2D.Impulse);
            }
        }
    }
}
