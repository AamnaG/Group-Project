using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{ 
    public void RestartGame()
    {
        // loads the game scene
        SceneManager.LoadScene("Main Menu");
    }
}
