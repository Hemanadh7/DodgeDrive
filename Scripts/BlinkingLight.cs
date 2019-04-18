using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour {

    public GameObject headLight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Random.Range(1, 50) == 45)
        {
            headLight.SetActive(false);
        }
        else
            headLight.SetActive(true);
	}
}
