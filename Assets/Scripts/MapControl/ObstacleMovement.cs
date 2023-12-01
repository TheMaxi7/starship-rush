using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    x,
    y,
    z
};

public class Scripts : MonoBehaviour
{
    public float MaxDistance = 1f;
    public float speed = 1f;
    private float currentDistance = 0f;
    public Direction direction;
    private Transform platformTransform;
    [HideInInspector]
    public Vector3 platformDir;
    [HideInInspector]
    public Vector3 currentPosition;
    [HideInInspector]
    public Vector3 startPosition;
    private bool movingForward = true;
    void Start()
    {

        platformTransform = GetComponent<Transform>();

        startPosition = platformTransform.position;

        if (direction == Direction.x)
            platformDir = new Vector3(1f, 0f, 0f);
        if (direction == Direction.y)
            platformDir = new Vector3(0f, 1f, 0f);
        if (direction == Direction.z)
            platformDir = new Vector3(0f, 0f, 1f);
    }

    void Update()
    {
        currentPosition = platformTransform.position;
        currentDistance = Vector3.Distance(startPosition, currentPosition);

        if (currentDistance >= MaxDistance && movingForward)
        {
            movingForward = false;
        }
        else if (currentDistance >= MaxDistance && !movingForward)
        {
            movingForward = true;
        }

        if (movingForward)
        {
            platformTransform.position += platformDir * Time.deltaTime * speed;
        }
        else if (!movingForward)
        {
            platformTransform.position -= platformDir * Time.deltaTime * speed;
        }

        //Debug.Log("Current distance: " + currentDistance);
    }
}