using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySections : MonoBehaviour
{

    public string parentName;

    // Update is called once per frame
    void Update()
    {
        parentName = transform.name;
        StartCoroutine(DestroySection());
    }

    IEnumerator DestroySection()
    {
        yield return new WaitForSeconds(10);
        if (parentName == "StartingSection(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
