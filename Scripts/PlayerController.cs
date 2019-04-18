using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 10f;
    public float rotationSpeed = 10f;
    

    public ParticleSystem[] carExplosionParticles;

    private float rotation;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rotation = Input.GetAxisRaw("Horizontal");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Meteor")
        {
            Debug.Log("Player Exploded!!");
            moveSpeed = 0f;
            carExplosionParticles[0].Play();
            carExplosionParticles[1].Play();
            carExplosionParticles[2].Play();
            Destroy(transform.gameObject, 3f);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
        Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(yRotation);
        Quaternion targetRotation = rb.rotation * deltaRotation;
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.fixedDeltaTime));
        //transform.Rotate(0f, rotation * rotationSpeed * Time.fixedDeltaTime, 0f, Space.Self);
    }
}
