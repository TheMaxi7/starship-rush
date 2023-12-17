using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    private Transform player;
    public float activationDistance = 25.0f;
    private float fallSpeed;

    private bool activated = false;
    private Vector3 fallDirection;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        fallSpeed = PlayerController.forwardSpeed;
        float zDistanceToPlayer = Mathf.Abs(transform.position.z - player.position.z);

        if (!activated && zDistanceToPlayer < activationDistance)
        {
            ActivateObstacle();
        }

        if (activated)
        {
            MoveTowardsPlayer();
        }
    }

    void ActivateObstacle()
    {
        StartCoroutine(DestroyAfterDelay(8.0f));
        gameObject.SetActive(true);
        activated = true;

        
        fallDirection = (player.position - transform.position).normalized;
    }

    void MoveTowardsPlayer()
    {
        transform.Translate(fallDirection * fallSpeed * Time.deltaTime);
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}