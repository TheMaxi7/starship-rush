using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform orientation;
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float horizontalSpeed;
    float horizontal;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

   
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        // Set the direction based on input
        direction = new Vector3(horizontal * horizontalSpeed, 0f, forwardSpeed);



    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
}
