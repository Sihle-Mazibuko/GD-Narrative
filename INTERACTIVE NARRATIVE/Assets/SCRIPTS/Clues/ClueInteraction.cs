using TMPro;
using UnityEngine;
using Yarn.Unity;

public class ClueInteraction : MonoBehaviour
{
    public Clue clue;
    private TextMeshProUGUI tooltipText;
    private bool isHovered = false;


    public string yarnNode;

    private DialogueRunner dialogueRunner;



    void Start()
    {

        tooltipText = GameObject.FindWithTag("ToolTip").GetComponent<TextMeshProUGUI>();

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


