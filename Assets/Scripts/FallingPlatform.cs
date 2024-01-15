using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 0.5f; // Time before platform begins to fall
    public float respawnDelay = 3f; // Time before platform respawns
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody rb;

    // Initially, the platform is unaffected by physics due to isKinematic being true
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    // Start the falling process if collider is player
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    // Fall after specified delay and respawn after specified respawn delay 
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.isKinematic = false;
        rb.useGravity = true;

        yield return new WaitForSeconds(respawnDelay);
        Respawn();
    }

    // Reset platform to original position and make platform static again
    void Respawn()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        rb.isKinematic = true;
        rb.useGravity = false;
    }
}
