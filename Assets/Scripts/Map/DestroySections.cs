using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySections : MonoBehaviour
{
    public string sectionName;
    public float destructionLevelTime;
    public Transform playerTransform;
    private List<string> validSectionNames = new List<string>
    {
        "Level1_1(Clone)",
        "Level1_2(Clone)",
        "Level1_3(Clone)",
        "Level1_4(Clone)",
        "Level2_1(Clone)",
        "Level2_2(Clone)",
        "Level2_3(Clone)",
        "Level2_4(Clone)",
        "Level3_1(Clone)",
        "Level3_2(Clone)",
        "Level3_3(Clone)",
        "Level3_4(Clone)",
        "Level4a(Clone)",
        "Level4b(Clone)",
        "Level4c(Clone)",
        "Level4d(Clone)",
        "Level4e(Clone)",
        "Level5_1(Clone)",
        "Level5_2(Clone)",
        "Level5_3(Clone)",
        "Level5_4(Clone)",
    };

    void Update()
    {
        if (!UIManager.gameOver && playerTransform.position.z > 400)
        {
            destructionLevelTime = GenerateSections.creationTime * 20;
        }
        else
        {
            StopAllCoroutines();
            destructionLevelTime = 100000000f;
        }
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            if (go.activeInHierarchy && IsValidSectionName(go.name))
            {
                StartCoroutine(DestroySection(go));
            }
        }
    }

    IEnumerator DestroySection(GameObject section)
    {
        yield return new WaitForSeconds(destructionLevelTime);

        if (!UIManager.gameOver && section.transform.position.z < playerTransform.position.z - 100)
        {
            Destroy(section);
        }
    }

    private bool IsValidSectionName(string name)
    {
        return validSectionNames.Contains(name);
    }
}
