using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSpawner : MonoBehaviour {

    public GameObject redOrb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Instantiate(redOrb, transform.position, Quaternion.identity);
	}
}
