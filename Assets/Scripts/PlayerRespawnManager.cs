using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnManager : MonoBehaviour
{
    private Vector3 _respawnPoint; // Store the respawn point for the player

    void Start()
    {
        _respawnPoint = transform.position; // Set the initial spawn point as the player's starting position
    }

    // Call this method to respawn the player at the last checkpoint position
    public void RespawnPlayer()
    {
        transform.position = _respawnPoint; // Respawn the player at the stored respawn point
    }

    // Call this method to set the respawn point to the latest activated checkpoint
    public void SetRespawnPoint(Vector3 checkpointPosition)
    {
        _respawnPoint = checkpointPosition; // Update the respawn point to the latest activated checkpoint position
        Debug.Log("Respawn point set to: " + _respawnPoint); // Add a debug message to check if the respawn point is being updated correctly
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player has fallen below the specified y-coordinate (e.g., y=0)
        if (transform.position.y < -10)
        {
            RespawnPlayer(); // Respawn the player if they have fallen below the specified y-coordinate
        }
    }
}


