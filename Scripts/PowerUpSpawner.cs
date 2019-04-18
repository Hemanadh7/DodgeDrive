using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    public GameObject fuelPowerUp;
    public float fuelSpawnRate;

    //private int timer;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Release", 0.0f ,fuelSpawnRate);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void Release()
    {
        Vector3 pos = Random.onUnitSphere * 25f;
        GameObject go = Instantiate(fuelPowerUp, pos, Quaternion.identity) as GameObject;
        Debug.Log(go.transform.name);
    }
}
