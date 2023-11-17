using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Projectile projectilePrefab;
    public Transform muzzle;
    public AudioSource shootFX;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Shoot();
        }   
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, muzzle.position, transform.rotation);
        shootFX.Play();
    }
}
