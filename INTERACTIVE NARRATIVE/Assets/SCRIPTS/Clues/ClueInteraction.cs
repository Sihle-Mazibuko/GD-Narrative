using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClueInteraction : MonoBehaviour
{
    public Clue clue; 
    private TextMeshProUGUI tooltipText;
    private bool isHovered = false;

    void Start()
    {
        tooltipText = GameObject.FindWithTag("ToolTip").GetComponent<TextMeshProUGUI>(); 
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