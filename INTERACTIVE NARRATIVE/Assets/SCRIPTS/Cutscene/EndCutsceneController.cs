using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndCutsceneController : MonoBehaviour
{
    public TextAnimator textAnimator;
    public Button continueButton;
    public Image background; // Add this line to reference the background image
    public Sprite[] backgroundImages; // Add this line to reference the background images

    private string[] dialogueLines = {
        "The truth is out.",
        "Linda, driven by jealousy and a desperate need for recognition, took Xola's life on what was meant to be a night of celebration."
    };


    private int currentLineIndex = 0;

    void Start()
    {
        continueButton.onClick.AddListener(OnContinueButtonClicked);
        ShowNextDialogue();
    }

    void OnContinueButtonClicked()
    {
        if (!textAnimator.IsTyping) // Only proceed if typing is finished
        {
            if (currentLineIndex < dialogueLines.Length - 1)
            {
                currentLineIndex++;
                ShowNextDialogue();
            }
            else
            {
                // End of dialogue or transition to next scene
                Debug.Log("Cutscene finished!");
                Quit();
            }
        }
    }

    void ShowNextDialogue()
    {
        textAnimator.ResetTyping(); // Reset previous typing
        textAnimator.StartTyping(dialogueLines[currentLineIndex]);
        textAnimator.StartTyping(dialogueLines[currentLineIndex]);

        // Update the background image if it exists
        if (currentLineIndex < backgroundImages.Length)
        {
            background.sprite = backgroundImages[currentLineIndex];
        }
    }

    public void Quit()
    {
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
