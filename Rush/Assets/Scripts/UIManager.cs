using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public InputField nameInputField; // Assign the Input Field in the Inspector
    public Text highScoreText; // Assign the Text element for displaying high score

    private int highScore;
    private string playerName;

    void Start()
    {
        // Initialize your UI components
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        playerName = PlayerPrefs.GetString("PlayerName", "");

        // Set the UI elements
        nameInputField.text = playerName;
        highScoreText.text = "High Score: " + playerName + " - " + highScore.ToString();

        // Disable the input field initially
        nameInputField.interactable = false;
    }

    void SubmitName(string submittedName)
    {
        // Capture the player's name from the input field
        playerName = submittedName;

        // Save the player's name to PlayerPrefs
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();

        // Update the high score display with the player's name
        highScoreText.text = "High Score: " + playerName + " - " + highScore.ToString();

        // Disable the input field after submission
        nameInputField.interactable = false;
    }

    // Call this function to enable the input field when a high score is achieved
    public void EnableInputField()
    {
        nameInputField.interactable = true;
        nameInputField.Select(); // Optionally, focus on the input field
    }
}
