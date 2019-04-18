using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorRotate : MonoBehaviour {

    //public GameObject particles;
    
    private Transform planet;
    //private Player player;
    private Vector3 directionToRotate;

	// Use this for initialization
	void Start () {
        planet = GameObject.FindGameObjectWithTag("Planet").transform;
        //player = GameObject.FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!planet)
        {
            Debug.LogWarning("Planet not found!!");
        }
        if (planet)
        {
            directionToRotate = planet.position - transform.position;
            Quaternion newRotation = Quaternion.LookRotation(directionToRotate);
            transform.rotation = newRotation;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (!player)
        {
            Debug.Log("Player Not Found!");
        }
        if (player)
        {
            if (!player.playerHit && other.tag == "Player")
            {
                player.DestroyPlayer();
            }
        }
    }
}
