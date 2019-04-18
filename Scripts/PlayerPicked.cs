using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPicked : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject, 0.3f);
        } 
    }
}
