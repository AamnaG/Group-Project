using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string sceneName;

    // Once the player touches the portal
    // the scene will transition to the new scene
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(sceneName);
        }
    }

}
