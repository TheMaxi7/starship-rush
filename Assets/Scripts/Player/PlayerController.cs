using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform orientation;
    private Rigidbody rb;  
    private Vector3 direction;
    public float forwardSpeed = 10f;
    public float maxSpeed = 40f;
    public float horizontalSpeed;
    public ParticleSystem explosionParticle;
    public AudioSource explosionFX;

    float horizontal;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    
        if (forwardSpeed < maxSpeed)
            forwardSpeed += 0.2f * Time.deltaTime;

        direction = new Vector3(horizontal * horizontalSpeed, 0f, forwardSpeed);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Left", true);
        }
        else
        {
            animator.SetBool("Left", false);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Right", true);
        }
        else
        {
            animator.SetBool("Right", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            if (gameObject.tag == "Player")
                gameObject.SetActive(false);
            
            PlayExplosion();
            PlayerManager.gameOver = true;
        }
    }

    private void FixedUpdate()
    {
   
        rb.velocity = direction;
    }

    void PlayExplosion()
    {
        explosionFX.Play();
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
    }
}
