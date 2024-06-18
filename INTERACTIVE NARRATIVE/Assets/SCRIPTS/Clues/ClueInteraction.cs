using TMPro;
using UnityEngine;
using Yarn.Unity;

public class ClueInteraction : MonoBehaviour
{
    public Clue clue; // Reference to the Clue scriptable object
    private TextMeshProUGUI tooltipText;
    private bool isHovered = false;

    public string yarnNode; // Yarn node to start dialogue
    private DialogueRunner dialogueRunner;
    public string playerTag = "Player"; // Ensure your player GameObject is tagged as "Player"

    void Start()
    {
        tooltipText = GameObject.FindWithTag("ToolTip").GetComponent<TextMeshProUGUI>();

        dialogueRunner = FindObjectOfType<DialogueRunner>();
        if (dialogueRunner == null)
        {
            Debug.LogError("DialogueRunner not found in the scene.");
        }

        // Ensure this GameObject has a Collider set to be a trigger
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
        else
        {
            Debug.LogError("No Collider found on the GameObject. Please add a Collider and set it as a trigger.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (dialogueRunner != null && !string.IsNullOrEmpty(yarnNode))
            {
                dialogueRunner.StartDialogue(yarnNode);
            }
        }
    }

    void OnMouseDown()
    {
        if (dialogueRunner != null && !string.IsNullOrEmpty(yarnNode))
        {
            dialogueRunner.StartDialogue(yarnNode);
        }
    }

    void Update()
    {
        if (isHovered)
        {
            if (Input.GetMouseButtonDown(1))
            {
                ConfirmationDialogue.Instance.ShowDialogue(clue, gameObject);
            }
        }
    }

    void OnMouseEnter()
    {
        isHovered = true;
        tooltipText.text = clue.clueName;
        tooltipText.gameObject.SetActive(true);
    }

    void OnMouseExit()
    {
        isHovered = false;
        tooltipText.gameObject.SetActive(false);
    }
}



