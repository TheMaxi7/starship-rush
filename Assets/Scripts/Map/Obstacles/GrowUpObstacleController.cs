using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowUpObstacleController : MonoBehaviour
{
    public Transform obstacleTrans;
    private Transform player;
    public float activationDistance = 12f;
    public float growthSpeed = 6.5f; 
    public float maxYScale = 260; 

    private MeshCollider meshCollider; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        meshCollider = GetComponent<MeshCollider>(); 
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < activationDistance)
        {
            
            float newYScale = Mathf.Min(transform.localScale.y + PlayerController.forwardSpeed* growthSpeed * Time.deltaTime, maxYScale);

           
            transform.localScale = new Vector3(transform.localScale.x, newYScale, transform.localScale.z);

            
            if (meshCollider != null)
            {
                meshCollider.transform.localScale = transform.localScale;
            }
        }
    }
}
