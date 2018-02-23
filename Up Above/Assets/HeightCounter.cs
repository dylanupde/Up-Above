using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightCounter : MonoBehaviour {

    Text textComponent;
    Player playerScript;
    float height;

	// Use this for initialization
	void Start ()
    {
        textComponent = GetComponent<Text>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        height = playerScript.Height;
        int approximateHeight = (int)height;

        textComponent.text = approximateHeight.ToString();
	}
}
