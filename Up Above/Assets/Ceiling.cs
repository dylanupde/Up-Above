using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ceiling : MonoBehaviour {

    GameObject player;
    float playerColliderHalfHeight;
    float myColliderHalfHeight;
    bool activated;
    Text finTextComponent;

	// Use this for initialization
	void Start ()
    {
        finTextComponent = GameObject.Find("FIN").GetComponent<Text>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerColliderHalfHeight = player.GetComponent<BoxCollider2D>().size.y * player.transform.localScale.y / 2;
        myColliderHalfHeight = GetComponent<BoxCollider2D>().size.y * transform.localScale.y / 2;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (activated)
        {
            if (player.transform.position.y - playerColliderHalfHeight > transform.position.y + myColliderHalfHeight)
            {
                GetComponent<BoxCollider2D>().isTrigger = false;
                finTextComponent.text = "FIN";
                activated = false;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        activated = true;
    }
}


