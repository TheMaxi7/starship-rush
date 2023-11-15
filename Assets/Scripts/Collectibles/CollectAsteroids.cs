using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAsteroids : MonoBehaviour
{
    public AudioSource asteroidsFX;

    private void OnTriggerEnter(Collider other)
    {
        asteroidsFX.Play();
        this.gameObject.SetActive(false);
    }
}
