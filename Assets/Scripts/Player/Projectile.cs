using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float launchForce = 10000f;

    public Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent < Rigidbody>();
    }

    private void OnEnable()
    {
        rigidbody.AddForce(launchForce * transform.forward);
    }

}
