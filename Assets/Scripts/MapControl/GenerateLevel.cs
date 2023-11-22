using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;

    public float zPos = 25;
    public bool creatingSection = false;
    public int sectionNum;
    public static float creationTime;
    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection= true;
            StartCoroutine(GenerateSection());
        }

    }

    IEnumerator GenerateSection()
    {
        creationTime = 25 / PlayerController.forwardSpeed;
        if (zPos < 200)
        {
            sectionNum = Random.Range(0, 3);
        }
        if (zPos > 200)
        {
            sectionNum = Random.Range(4, 7);
        }
        
        Instantiate(section[sectionNum], new Vector3(0,0,zPos), Quaternion.identity);
        zPos += 25;
        yield return new WaitForSeconds(creationTime);
        creatingSection= false;
    }
}
