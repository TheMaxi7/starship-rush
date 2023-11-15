using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;

    public float zPos = 25;
    public bool creatingSection = false;
    public int sectionNum;
    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection= true;
            StartCoroutine(GenerateSection());
        }
        else
        {

        }
    }

    IEnumerator GenerateSection()
    {
        sectionNum = Random.Range(0, 3);
        Instantiate(section[0], new Vector3(0,0,zPos), Quaternion.identity);
        zPos += 25;
        yield return new WaitForSeconds(2);
        creatingSection= false;
    }
}
