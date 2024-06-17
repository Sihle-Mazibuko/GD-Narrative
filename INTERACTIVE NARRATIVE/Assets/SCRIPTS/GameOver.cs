using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TextAnimator textAnimator;
    public Button continueButton;
    public Image background; // Reference to the background image
    public Sprite[] backgroundImages; // Reference to the background images
    public GameObject OptionsPanel; // Reference to the options panel
    public Button RestartButton; // Reference to the restart button
    public Button QuitButton; // Reference to the quit button

    private string[] dialogueLines = {
        "GAME OVER",
        "You have failed to find the culprit in time. The case is in the process of being handed over to someone else."
    };

    private int currentLineIndex = 0;

    void Start()
    {
        Debug.Log("Start method called");
        continueButton.onClick.AddListener(OnContinueButtonClicked);
        RestartButton.onClick.AddListener(RestartGame);
        QuitButton.onClick.AddListener(Quit);
        OptionsPanel.SetActive(false); // Hide the options panel initially
        Debug.Log("Options panel set to inactive initially");
        ShowNextDialogue();
    }

    void OnContinueButtonClicked()
    {
        Debug.Log("Continue button clicked, checking if typing is finished.");
        if (!textAnimator.IsTyping) // Only proceed if typing is finished
        {
            Debug.Log("Text typing finished, moving to next line or showing options panel.");
            if (currentLineIndex < dialogueLines.Length - 1)
            {
                currentLineIndex++;
                ShowNextDialogue();
            }
            else
            {
                // End of dialogue, show the options panel
                Debug.Log("Cutscene finished, showing options panel.");
                continueButton.gameObject.SetActive(false); // Hide the continue button
                OptionsPanel.SetActive(true); // Show the options panel
                Debug.Log("Options panel should now be visible");
            }
        }
        else
        {
            Debug.Log("Text typing not finished, waiting.");
        }
    }

    void ShowNextDialogue()
    {
        Debug.Log("Showing next dialogue: " + dialogueLines[currentLineIndex]);
        textAnimator.ResetTyping(); // Reset previous typing
        textAnimator.StartTyping(dialogueLines[currentLineIndex]);

        // Update the background image if it exists
        if (currentLineIndex < backgroundImages.Length)
        {
            background.sprite = backgroundImages[currentLineIndex];
            Debug.Log("Updated background image to: " + backgroundImages[currentLineIndex].name);
        }
        else
        {
            Debug.Log("No background image available for index: " + currentLineIndex);
        }
    }

    public void RestartGame()
    {
        Debug.Log("Restarting game.");
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Debug.Log("Quitting game.");
        // If we are running in a standalone build of the game
#if UNITY_STANDALONE
        // Quit the application
        Application.Quit();
#endif

        // If we are running in the editor
#if UNITY_EDITOR
        // Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
