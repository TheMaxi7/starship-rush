using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float launchForce = 7000f;

    public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent < Rigidbody>();
    }

    private void OnEnable()
    {
        rb.AddForce(launchForce * transform.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //destroyAsteroid();
    }
}
