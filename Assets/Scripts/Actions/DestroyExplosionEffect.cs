using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosionEffect : MonoBehaviour
{

    public string parentName;
    void Update()
    {
        parentName = transform.name;
        StartCoroutine(DestroyExplEffect());
    }

    IEnumerator DestroyExplEffect()
    {
        yield return new WaitForSeconds(3);
        if (parentName == "BigExplosionEffect(Clone)")
            Destroy(gameObject);
    }
}

