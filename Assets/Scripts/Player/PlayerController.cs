using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform orientation;
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed = 10f;
    public float maxSpeed = 40f;
    public float horizontalSpeed;
    
    float horizontal;
    private Animator animator;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        // Set the direction based on input
        if (forwardSpeed < maxSpeed)
            forwardSpeed += 0.2f * Time.deltaTime;

        direction = new Vector3(horizontal * horizontalSpeed, 0f, forwardSpeed);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Left", true);
        } else
        {
            animator.SetBool("Left", false);
        }
        
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Right", true);
        } else
        {
            animator.SetBool("Right", false);
        }

       

    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
}
