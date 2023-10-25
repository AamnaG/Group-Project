using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour
{
    public GameObject checkPoint; // GameObject variable needed for the checkpoint
    Vector3 spawnPoint; // one Vector3 needed to save spawn position 

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -20f) // when player falls, spawns in starting position again
        {
            gameObject.transform.position = spawnPoint;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("checkpoint")) // if the tag is "checkpoint" then the spawn will be equal to the checkpoint's position
        {
            spawnPoint = checkPoint.transform.position;
        }
    }
}
