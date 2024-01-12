using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothTime = 0.3f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    
    void Start()
    {
        
    }

    void Update()
    {
        // Check if the target is not null (i.e. if there is a target to follow)
        if(target != null)
        {
            // Calculate the target position by adding the offset to the target's position
            Vector3 targetPosition = target.position + offset;
            // Move the camera smoothly towards the target position using SmoothDamp
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
