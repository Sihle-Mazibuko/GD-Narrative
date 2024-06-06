using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverTextDisplay : MonoBehaviour
{
    public GameObject hoverText; // Assign in Inspector

    private void Start()
    {
        // Ensure the hover text is initially hidden
        hoverText.SetActive(false);
    }

    private void OnMouseEnter()
    {
        // Show the text when mouse enters the object's collider
        hoverText.SetActive(true);
    }

    private void OnMouseExit()
    {
        // Hide the text when mouse exits the object's collider
        hoverText.SetActive(false);
    }
}

