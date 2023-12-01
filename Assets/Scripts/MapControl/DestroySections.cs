using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroySections : MonoBehaviour
{

    public string parentName;
    void Update()
    {
        parentName = transform.name;
        StartCoroutine(DestroySection());

    }

    IEnumerator DestroySection()
    {
        yield return new WaitForSeconds(GenerateLevel.creationTime*10);
        if ((parentName == "Level1_1(Clone)") || (parentName == "Level1_2(Clone)") || (parentName == "Level1_3(Clone)") || (parentName == "Level1_4(Clone)"))
        {
            if (PlayerManager.gameOver == false)
            {
                Destroy(gameObject); ;
            }
        }
    }
}
