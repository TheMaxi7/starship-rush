using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public static float zPos = 200;
    public bool creatingSection = false;
    public int sectionNum;
    public static float creationTime;
    void Update()
    {
        if (!UIManager.gameOver && creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }

    }

    IEnumerator GenerateSection()
    {
        if (PlayerController.forwardSpeed > 9)
            creationTime = 25 / PlayerController.forwardSpeed;
        else 
            creationTime = 2.5f;

        if (zPos < 400)
        {
            sectionNum = Random.Range(0, 3);
        }
        if (zPos > 400 && zPos < 700)
        {
            sectionNum = Random.Range(4, 7);
        }
        if (zPos > 700 && zPos < 1100)
        {
            sectionNum = Random.Range(8, 12);
        }
        if (zPos > 1100)
        {
            sectionNum = Random.Range(0, 12);
        }

        Instantiate(section[sectionNum], new Vector3(0,0,zPos), Quaternion.identity);
        zPos += 25;
        yield return new WaitForSeconds(creationTime);
        creatingSection= false;
    }
}
