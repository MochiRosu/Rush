using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public Text scoreText;
    public Text highScoreText;
    private float survivalTime = 0f;
    private int currentScore = 0;
    private int highScore = 0;

    void Start()
    {
        Time.timeScale = 1;

        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText(); // Update the high score UI text
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {
            survivalTime += Time.deltaTime;
            currentScore = Mathf.FloorToInt(survivalTime);
            scoreText.text = "Survival Time: " + currentScore.ToString();

            // Update the high score if the current score is higher
            if (currentScore > highScore)
            {
                highScore = currentScore;

                // Save the new high score to PlayerPrefs
                PlayerPrefs.SetInt("HighScore", highScore);
                PlayerPrefs.Save();

                UpdateHighScoreText(); // Update the high score UI text
            }
        }
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    // Update the high score UI text
    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}
