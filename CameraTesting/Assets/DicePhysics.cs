using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePhysics : MonoBehaviour {
    public Vector3 incomingForce;



    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        incomingForce = collision.impulse;
        incomingForce.x *= Mathf.Min(1, -incomingForce.y);
        incomingForce.z *= Mathf.Min(1, -incomingForce.y);
        incomingForce.y /= 50;
        GetComponent<Rigidbody>().AddForce(incomingForce);
    }
}
