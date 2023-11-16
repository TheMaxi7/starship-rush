using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStars : MonoBehaviour
{
    public AudioSource starsFX;

    private void OnTriggerEnter(Collider other)
    {
        starsFX.Play();
        CollectibleControl.starCount++;
        this.gameObject.SetActive(false);
    }
}
