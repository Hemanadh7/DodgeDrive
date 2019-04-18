using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour {

    Attracter attracter;

    private Transform myTransform;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        myTransform = transform;
        attracter = GameObject.FindObjectOfType<Attracter>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        attracter.Gravity(myTransform);
	}
}
