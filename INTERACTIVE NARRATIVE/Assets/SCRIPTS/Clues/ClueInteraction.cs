using UnityEngine;
using Yarn.Unity;

public class ClueInteraction : MonoBehaviour
{
    public string yarnNode;

    private DialogueRunner dialogueRunner;

    void Start()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        if (dialogueRunner == null)
        {
            Debug.LogError("DialogueRunner not found in the scene.");
        }
    }

    void OnMouseDown()
    {
        if (dialogueRunner != null && !string.IsNullOrEmpty(yarnNode))
        {
            dialogueRunner.StartDialogue(yarnNode);
        }
    }
}


