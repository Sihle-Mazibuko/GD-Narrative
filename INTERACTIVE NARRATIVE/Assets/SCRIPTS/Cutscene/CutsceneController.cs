using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    public TextAnimator textAnimator;
    public Button continueButton;
    public Image background; // Add this line to reference the background image
    public Sprite[] backgroundImages; // Add this line to reference the background images
    public string nextSceneName; // Name of the scene to load after cutscene

    private string[] dialogueLines = {
        "It's Prom night at Pretoria High School! And all the Matriculants are looking lavish",
        "But wait...",
        "Xola, one of the prom queen nominees has been...",
        "MURDERED.",
        "As you�ve been assigned to investigate this case, you�ve heard rumours that you are next in line to get a promotion and be ranked a Police Corporal at your station",
        "so you deem solving this case as your one shot to solidify that promotion by unravelling the mystery.",
        "Bring the culprit to justice before the night is over."
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
                LoadNextScene();
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

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }


}

