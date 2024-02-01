using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHearts : MonoBehaviour
{
    public AudioSource heartsFX;

    private void OnTriggerEnter(Collider other)
    {
        heartsFX.Play();
        if (uiController.heartCount < 3)
        {
            uiController.heartCount++;
        }
        this.gameObject.SetActive(false);
    }
}
