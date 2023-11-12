using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - target.position;   
    }

    void FixedUpdate()
    {

        //To keep it in the center
        //Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);

        Vector3 newPosition = new Vector3(offset.x + target.position.x, offset.y + target.position.y, offset.z + target.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 10* Time.deltaTime);
    
    }
}
