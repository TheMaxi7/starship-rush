using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Transform playerTransform;
    private Rigidbody rb;  
    private Vector3 direction;
    public static float forwardSpeed = 10f;
    public float maxSpeed = 40f;
    public float horizontalSpeed;
    public float verticalSpeed;
    public ParticleSystem explosionParticle;
    public AudioSource explosionFX;
    float horizontal;
    float vertical;
    private Animator animator;
    public float minY = 0.8f;
    public float maxY = 7f;
    public float minX = -10f;
    public float maxX = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
        animator = GetComponent<Animator>();
        float clampedVertical = Mathf.Clamp(rb.position.y, minY, maxY);
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (forwardSpeed < maxSpeed)
            forwardSpeed += 0.2f * Time.deltaTime;

        direction = new Vector3(horizontal * horizontalSpeed, vertical * verticalSpeed, forwardSpeed);
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
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Up", true);
        }
        else
        {
            animator.SetBool("Up", false);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Down", true);
        }
        else
        {
            animator.SetBool("Down", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            if (gameObject.tag == "Player")
            {
                gameObject.SetActive(false);
            }
            PlayExplosion();
            PlayerManager.gameOver = true;
        }
    }

    private void FixedUpdate()
    {
        
        float clampedVertical = Mathf.Clamp(rb.position.y, minY, maxY);
        float clampedHorizontal = Mathf.Clamp(rb.position.x, minX, maxX);
        rb.position = new Vector3(clampedHorizontal, clampedVertical, rb.position.z);

        direction = new Vector3(horizontal * horizontalSpeed, vertical * verticalSpeed, forwardSpeed);

        rb.velocity = direction;
    }

    void PlayExplosion()
    {
        explosionFX.Play();
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
    }
}
