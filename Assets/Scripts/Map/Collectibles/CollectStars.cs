using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStars : MonoBehaviour
{
    public AudioSource starsFX;

    private void OnTriggerEnter(Collider other)
    {
        starsFX.Play();
        uiController.starCount++;
        this.gameObject.SetActive(false);
    }
}
