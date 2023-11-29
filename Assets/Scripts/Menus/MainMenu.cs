using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 
    public void StartGame()
    {
        // loads the game scene
        SceneManager.LoadScene("Main Scene");
    }
}
