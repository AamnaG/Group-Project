using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    
    // Index of current waypoint the platform is moving towards
    int currentWaypointIndex = 0; 
    
    [SerializeField] float speed = .1f;

    void FixedUpdate()
    {
        // Check if the distance between the platform and the current waypoint is less than 0.1 units
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        
        // Move the platform towards the current waypoint at a constant speed
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Set the platform as the parent of the object that triggered the collider
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove the platform as the parent of the object that triggered the collider
        other.transform.SetParent(null);
    }
}
