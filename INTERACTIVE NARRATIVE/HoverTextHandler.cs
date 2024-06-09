using System.Collections;
using System.Collections.Generic;
using TMPro;  // Use this if you are using TextMeshPro
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;  // Required when using Event data

public class HoverTextHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI hoverText;  // Reference to the TextMeshPro text
    // public Text hoverText;  // Use this if you are using the standard UI Text

    private string displayText = "Hovering over the image!";  // Text to display
    private bool isHovering = false;  // Track if the mouse is hovering

    void Start()
    {
        hoverText.gameObject.SetActive(false);  // Initially hide the hover text
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
        UpdateHoverTextPosition();
    }

    // Called when the pointer exits the area of the UI element
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        hoverText.gameObject.SetActive(false);  // Hide the text
    }

    // Update the position of the hover text to follow the mouse cursor
    private void UpdateHoverTextPosition()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)hoverText.transform.parent, Input.mousePosition, null, out position);
        hoverText.rectTransform.localPosition = position;
    }
}



