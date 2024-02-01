using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ShootingController : MonoBehaviour
{
    [Header("Game Objects")]
    public Projectile projectilePrefab;
    public Transform muzzle;
    public AudioSource shootFX;
    public AudioSource noAmmoFX; 
    public GameObject crosshair;

    [Header("Variables")]
    public float projectileForce = 20f;
    private Vector3 target;
    public static bool canShoot = false;
    void Start() 
    {
        Cursor.visible= false;
    }



    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        target = target = Input.mousePosition;
        crosshair.transform.position = new Vector2(target.x, target.y);  
        muzzle.transform.rotation = crosshair.transform.rotation;
        Debug.DrawRay(muzzle.position, ray.direction * 10f, Color.red);
        if (canShoot && Input.GetButtonDown("Fire1"))
        {
            if (uiController.ammoCount > 0)
            {
                Shoot();
                uiController.ammoCount--;
            }
            else
            {
                noAmmoFX.Play();
            }
            
        }   
    }

    void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float maxRaycastDistance = 200f;
        int layerMask = ~LayerMask.GetMask("Player");

        if (Physics.Raycast(ray, out hit, maxRaycastDistance, layerMask))
        {
            Vector3 shootDirection = hit.point - muzzle.position;

            Projectile newProjectile = Instantiate(projectilePrefab, muzzle.position, Quaternion.identity);
            newProjectile.transform.rotation = Quaternion.LookRotation(shootDirection);

            Rigidbody projectileRb = newProjectile.GetComponent<Rigidbody>();
            projectileRb.AddForce(shootDirection.normalized * projectileForce, ForceMode.Impulse);
            
        }
        else
        {
            Vector3 defaultShootDirection = ray.direction * maxRaycastDistance;
            Projectile newProjectile = Instantiate(projectilePrefab, muzzle.position, Quaternion.identity);
            newProjectile.transform.rotation = Quaternion.LookRotation(defaultShootDirection);

            Rigidbody projectileRb = newProjectile.GetComponent<Rigidbody>();
            projectileRb.AddForce(defaultShootDirection.normalized * projectileForce, ForceMode.Impulse);
        }

        shootFX.Play();
    }

}