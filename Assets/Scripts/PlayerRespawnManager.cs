using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnManager : MonoBehaviour
{
    private Vector3 _respawnPoint;

    void Start()
    {
        _respawnPoint = transform.position; // Set the initial spawn point as the player's starting position
    }

    public void RespawnPlayer()
    {
        transform.position = _respawnPoint; // Respawn the player at the stored respawn point
    }

    public void SetRespawnPoint(Vector3 checkpointPosition)
    {
        _respawnPoint = checkpointPosition; // Update the respawn point to the latest activated checkpoint position
        Debug.Log("Respawn point set to: " + _respawnPoint);
    }

    void Update()
    {
        // Check if the player has fallen below y=-10 and if so, respawn
        if (transform.position.y < -10)
        {
            RespawnPlayer();
        }
    }
}


