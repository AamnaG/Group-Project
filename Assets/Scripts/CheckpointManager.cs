using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private bool _activated = false; // Check if the checkpoint has been activated

    // Triggered when another collider enters the checkpoint's trigger collider
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_activated)
        {
            if (GameManager.Instance != null) // Check if the GameManager instance is not null
            {
                GameManager.Instance.SetCheckpoint(transform.position); // Set the checkpoint position in the GameManager
                _activated = true;
                // Add any other effects you want for the activated checkpoint
            }
            else
            {
                Debug.LogError("GameManager.Instance is null. Make sure the GameManager is initialized.");
            }
        }
    }
}

