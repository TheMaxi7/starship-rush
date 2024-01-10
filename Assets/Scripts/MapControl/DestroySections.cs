using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySections : MonoBehaviour
{
    public string parentName;
    public float destructionLevelTime;

    private List<string> validParentNames = new List<string>
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
        "Level4e(Clone)"
    };

    void Update()
    {
        if (!UIManager.gameOver)
        {
            destructionLevelTime = GenerateLevel.creationTime * 50;
        }
        else
        {
            StopAllCoroutines();
            destructionLevelTime = 100000000f;
        }
        parentName = transform.name;
        StartCoroutine(DestroySection());
    }

    IEnumerator DestroySection()
    {
        yield return new WaitForSeconds(destructionLevelTime);

        if (IsValidParentName(parentName) && !UIManager.gameOver)
        {
            Destroy(gameObject);
        }
    }

    private bool IsValidParentName(string name)
    {
        return validParentNames.Contains(name);
    }
}
