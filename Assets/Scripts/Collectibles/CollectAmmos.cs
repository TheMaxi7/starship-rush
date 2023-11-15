using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAmmos : MonoBehaviour
{
    public AudioSource ammoFX;

    private void OnTriggerEnter(Collider other)
    {
        ammoFX.Play();
        this.gameObject.SetActive(false);
    }
}
