using System.Collections;
using System.Collections.Generic;
using TMPro;  // If using TextMeshPro
using UnityEngine;
using UnityEngine.EventSystems;  // Required when using Event data

public class ThandoProfile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI hoverText;  // Reference to the TextMeshPro text
    public RectTransform backgroundRect;  // Reference to the background RectTransform
    // public Text hoverText;  // Use this if you are using the standard UI Text

    private string displayText = "THANDO:" +
        "- Prom queen nominee" +
        "- Beloved cheerleader" +
        "- Bubbly" +
        "- Infectious energy and kind heart." +
        "- Insecure & has hidden struggles.";  // Text to display

    private bool isHovering = false;  // Track if the mouse is hovering

    void Start()
    {
        hoverText.gameObject.SetActive(false);  // Initially hide the hover text
        backgroundRect.gameObject.SetActive(false);  // Initially hide the background
        hoverText.raycastTarget = false;  // Ensure hover text does not block pointer events
    }

    void Update()
    {
        if (isHovering)
        {
            UpdateHoverTextPosition();
        }
    }

    // Called when the pointer enters the area of the UI element
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        hoverText.text = displayText;  // Set the hover text
        hoverText.gameObject.SetActive(true);  // Show the text
        backgroundRect.gameObject.SetActive(true);  // Show the background
        UpdateHoverTextPosition();
    }

    // Called when the pointer exits the area of the UI element
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        hoverText.gameObject.SetActive(false);  // Hide the text
        backgroundRect.gameObject.SetActive(false);  // Hide the background
    }

    // Update the position of the hover text to follow the mouse cursor
    private void UpdateHoverTextPosition()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)hoverText.transform.parent, Input.mousePosition, null, out position);
        hoverText.rectTransform.localPosition = position;
        backgroundRect.localPosition = position;  // Match the background position with the text
    }
}
