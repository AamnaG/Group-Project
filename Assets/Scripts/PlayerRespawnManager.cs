using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnManager : MonoBehaviour
{
    private Vector3 _respawnPoint;

    void Start()
    {
        // Set the initial spawn point as the player's starting position
        _respawnPoint = transform.position;
    }

    public void RespawnPlayer()
    {
        // Respawn the player at the stored respawn point
        transform.position = _respawnPoint;
    }

    public void SetRespawnPoint(Vector3 checkpointPosition)
    {
        // Update the respawn point to the latest activated checkpoint position
        _respawnPoint = checkpointPosition;
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


