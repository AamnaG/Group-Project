using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private PlayerRespawnManager _playerRespawnManager;

    void Awake()
    {
        if (Instance == null)
            Instance = this; // Set the GameManager instance to this if no instance exists
        else
            Destroy(gameObject); // Destroy duplicate GameManager instance

        _playerRespawnManager = FindObjectOfType<PlayerRespawnManager>(); // Find the PlayerRespawnManager in the scene
    }

    // This method is called from CheckpointManager to set the respawn point to the latest activated checkpoint
    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        _playerRespawnManager.SetRespawnPoint(checkpointPosition);
    }

    // This method is called when the player dies to respawn at the latest checkpoint
    public void RespawnPlayer()
    {
        _playerRespawnManager.RespawnPlayer();
    }
}


