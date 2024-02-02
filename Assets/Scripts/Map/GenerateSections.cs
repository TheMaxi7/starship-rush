using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSections : MonoBehaviour
{
    public GameObject[] section;
    public static float zPos = 200;
    public bool creatingSection = false;
    public int sectionNum;
    public static float creationTime;
    public Transform playerTransform;
    public static Color lv2FogColor;
    bool converted1 = ColorUtility.TryParseHtmlString("#C38052", out lv2FogColor);
    public static Color lv3FogColor;
    bool converted2 = ColorUtility.TryParseHtmlString("#8A1890", out lv3FogColor);
    public static Color lv4FogColor;
    bool converted3 = ColorUtility.TryParseHtmlString("#5E8778", out lv4FogColor);
    public static Color lv5FogColor;
    bool converted4 = ColorUtility.TryParseHtmlString("#BAA685", out lv5FogColor);
    void Update()
    {
        if (!UIManager.gameOver && creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
        if (playerTransform.position.z > 200 && playerTransform.position.z < 400 && converted1)
        {
            RenderSettings.fogColor = lv2FogColor;
        }
        if (playerTransform.position.z > 425 && playerTransform.position.z < 725 && converted2)
        {
            RenderSettings.fogColor = lv3FogColor;
        }
        if (playerTransform.position.z > 725 && playerTransform.position.z < 1125 && converted3)
        {
            RenderSettings.fogColor = lv4FogColor; 
        }
        if (playerTransform.position.z > 1125 && playerTransform.position.z < 1625 && converted4)
        {
            RenderSettings.fogColor = lv5FogColor; 
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
        if (zPos > 1100 && zPos < 1600)
        {
            sectionNum = Random.Range(13, 16);
        }
        if (zPos > 1600) 
        {
            sectionNum = Random.Range(0, 16);
        }

        Instantiate(section[sectionNum], new Vector3(0,0,zPos), Quaternion.identity);
        zPos += 25;
        yield return new WaitForSeconds(creationTime);
        creatingSection= false;
    }
}
