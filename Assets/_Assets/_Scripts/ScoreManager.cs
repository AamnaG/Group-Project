using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int scoreValue;
    public TextMeshProUGUI Score;
    public static ScoreManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        updateScore();
    }
    private void updateScore()
    {
        Score.text ="Score: " + PlayerPrefs.GetInt("Score");
    }
    public void addScore()
    {
        PlayerPrefs.SetInt("Score", (PlayerPrefs.GetInt("Score") + scoreValue));
        updateScore();
    }
}