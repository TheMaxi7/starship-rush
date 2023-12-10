using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public AudioSource collisionFX;

    private void OnTriggerEnter(Collider other)
    {
        collisionFX.Play();
        
    }
}
