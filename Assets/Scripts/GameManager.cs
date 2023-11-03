using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Ensure there is only one instance of the GameManager

    private PlayerRespawnManager _playerRespawnManager; // Reference to the PlayerRespawnManager

    void Awake()
    {
        if (Instance == null)
            Instance = this; // Set the GameManager instance to this if no instance exists
        else
            Destroy(gameObject); // Destroy the duplicate GameManager instance

        _playerRespawnManager = FindObjectOfType<PlayerRespawnManager>(); // Find the PlayerRespawnManager in the scene
    }

    // Call this method from the CheckpointManager to set the respawn point to the latest activated checkpoint
    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        _playerRespawnManager.SetRespawnPoint(checkpointPosition); // Set the respawn point in the PlayerRespawnManager
    }

    // Call this method when the player dies to respawn at the latest checkpoint
    public void RespawnPlayer()
    {
        _playerRespawnManager.RespawnPlayer(); // Respawn the player using the PlayerRespawnManager
    }
}


