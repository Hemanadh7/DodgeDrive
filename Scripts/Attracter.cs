using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attracter : MonoBehaviour {

    public float gravitationalConstant = -9.8f;

    private Rigidbody rb;

    public void Gravity(Transform body)
    {
        rb = body.GetComponent<Rigidbody>();
        Vector3 forceDirection = (body.transform.position - transform.position).normalized;
        Vector3 bodyUp = body.up;
        rb.AddForce(forceDirection * gravitationalConstant);

        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, forceDirection) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
