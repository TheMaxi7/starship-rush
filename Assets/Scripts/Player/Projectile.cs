using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float launchForce = 7000f;
    public GameObject explosionEffectPrefab;

    private void OnEnable()
    {
        StartCoroutine(DestroyAfterDelay(2.0f));
    }


    public void HandleCollision(GameObject collidedObject, Vector3 collisionPoint)
    {
        if (collidedObject.CompareTag("BreakableObstacle"))
        {
            DeactivateObstacle(collidedObject);
            PlayExplosionEffect(collisionPoint);
            Destroy(gameObject);
        }
        else if (collidedObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

    private void DeactivateObstacle(GameObject obstacle)
    {
        obstacle.SetActive(false);
    }

    private void PlayExplosionEffect(Vector3 position)
    {
        if (explosionEffectPrefab != null)
        {
            GameObject explosionEffect = Instantiate(explosionEffectPrefab, position, Quaternion.identity);
            Destroy(explosionEffect, 2.0f);
        }
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}