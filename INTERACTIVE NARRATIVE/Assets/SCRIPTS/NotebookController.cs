using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NotebookController : MonoBehaviour
{
    public GameObject notebookPanel;
    public Button notebookButton;
    public InputField notebookInputField;
    public InputField guessInputField; // Input field for guessing the killer
    public Text feedbackText; // Text to display feedback to the player
    public Button submitGuessButton; // Button to submit the guess

    private bool isNotebookOpen = false;
    private const string NotebookKey = "PlayerNotes"; // Key for storing notes in PlayerPrefs
    private const string CorrectKillerName = "Linda"; // Correct killer name

    private static NotebookController instance;

    void Awake()
    {
        // Ensure only one instance of NotebookController exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist the notebook across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Initialize the notebook panel to be closed
        notebookPanel.SetActive(isNotebookOpen);

        // Add listener to the notebook button
        notebookButton.onClick.AddListener(ToggleNotebook);

        // Add listener to the submit guess button
        submitGuessButton.onClick.AddListener(CheckGuess);

        // Load notes from PlayerPrefs
        LoadNotes();
    }

    void ToggleNotebook()
    {
        isNotebookOpen = !isNotebookOpen;
        notebookPanel.SetActive(isNotebookOpen);

        if (!isNotebookOpen)
        {
            SaveNotes(); // Save notes when the notebook is closed
        }
    }

    void SaveNotes()
    {
        // Save the notes to PlayerPrefs
        PlayerPrefs.SetString(NotebookKey, notebookInputField.text);
        PlayerPrefs.Save();
    }

    void LoadNotes()
    {
        // Load the notes from PlayerPrefs
        if (PlayerPrefs.HasKey(NotebookKey))
        {
            notebookInputField.text = PlayerPrefs.GetString(NotebookKey);
        }
    }

    void CheckGuess()
    {
        string playerGuess = guessInputField.text.Trim();

        // Add debugging statements
        Debug.Log("Player guessed: " + playerGuess);
        Debug.Log("Correct name is: " + CorrectKillerName);

        if (string.Equals(playerGuess, CorrectKillerName, System.StringComparison.OrdinalIgnoreCase))
        {
            feedbackText.text = "Congratulations! You guessed correctly. Linda is the killer.";
            feedbackText.color = Color.green;
            
            SceneManager.LoadScene("WinScene");
            
        }
        else
        {
            feedbackText.text = "Incorrect guess. Please try again.";
            feedbackText.color = Color.red;
        }
    }
}
