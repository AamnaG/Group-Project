using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Loads the game scene
        SceneManager.LoadScene("Main Scene");
    }
}
