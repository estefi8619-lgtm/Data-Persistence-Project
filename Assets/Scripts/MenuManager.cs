using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    // Reference to the TMP_InputField for player name input
    [SerializeField] private TMP_InputField nameInput;
    public void StartNewGame()
    {
        // Get the player name from the input field and trim any whitespace
        string playerName = nameInput.text.Trim();

        // Check if the player name is empty or null
        if (string.IsNullOrEmpty(playerName))
        {
            nameInput.ActivateInputField();
            return;
        }

        // Save the player name to PlayerPrefs for later use
        PlayerPrefs.SetString("CurrentPlayerName", playerName);
        PlayerPrefs.Save();

        // Load the main game scene
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        // Exit the application. In the Unity Editor, this will stop play mode.
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
// Quit the application when running as a standalone build
        Application.Quit();
#endif
    }

    public void ResetScore()
    {
        HighScore.ResetScore();
    }
}
