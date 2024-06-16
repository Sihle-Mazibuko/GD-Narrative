using UnityEngine;
using UnityEngine.UI;

public class NotebookController : MonoBehaviour
{
    public GameObject notebookPanel;
    public Button notebookButton;
    public InputField notebookInputField;

    private bool isNotebookOpen = false;
    private const string NotebookKey = "PlayerNotes"; // Key for storing notes in PlayerPrefs

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
}
