using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;
    public static float forwardSpeed = 10f;
    public static bool canMove = false;
    public float maxSpeed = 30f;
    public static float horizontalSpeed = 5f;
    public static float verticalSpeed = 5f;
    public ParticleSystem explosionParticle;
    public AudioSource explosionFX;
    float horizontal;
    float vertical;
    private Animator animator;
    public float minY = 0.8f;
    public float maxY = 7f;
    public float minX = -6f;
    public float maxX = 6f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  
        animator = GetComponent<Animator>();
        float clampedVertical = Mathf.Clamp(rb.position.y, minY, maxY);
        StartCoroutine(StartForward());
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //Debug.Log(forwardSpeed);
        if (forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.1f * Time.deltaTime;
            horizontalSpeed += 0.1f * Time.deltaTime;
            verticalSpeed += 0.1f * Time.deltaTime;

        }
            
        direction = new Vector3(horizontal * horizontalSpeed, vertical * verticalSpeed, forwardSpeed);

   
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && canMove == true)
        {
            animator.SetBool("Left", true);
        }
        else
        {
            animator.SetBool("Left", false);
        }

        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && canMove == true)
        {
            animator.SetBool("Right", true);
        }
        else
        {
            animator.SetBool("Right", false);
        }
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && canMove == true)
        {
            animator.SetBool("Up", true);
        }
        else
        {
            animator.SetBool("Up", false);
        }

        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && canMove == true)
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
        if ((collision.gameObject.tag == "Obstacle") || (collision.gameObject.tag == "BreakableObstacle"))
        {
            if (gameObject.tag == "Player")
            {
                gameObject.SetActive(false);
            }
            PlayExplosion();
            UIManager.gameOver = true;

        }
    }

    private void FixedUpdate()
    {
        
        float clampedVertical = Mathf.Clamp(rb.position.y, minY, maxY);
        float clampedHorizontal = Mathf.Clamp(rb.position.x, minX, maxX);
        rb.position = new Vector3(clampedHorizontal, clampedVertical, rb.position.z);
        if (canMove == true)
        {
            direction = new Vector3(horizontal * horizontalSpeed, vertical * verticalSpeed, forwardSpeed);
            rb.velocity = direction;
        }

    }

    void PlayExplosion()
    {
        explosionFX.Play();
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
    }

    IEnumerator StartForward()
    {
        yield return new WaitForSeconds(4f);
        forwardSpeed = 10f;
        horizontalSpeed = 5f;
        verticalSpeed = 5f;
    }
}
