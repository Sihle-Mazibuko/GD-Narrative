using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimator : MonoBehaviour
{
    public Text dialogueText;
    public float typingSpeed = 0.05f;
    private string currentText = "";
    private bool isTyping = false;

    public bool IsTyping => isTyping; // Public read-only property

    public void StartTyping(string text)
    {
        if (!isTyping)
        {
            currentText = text;
            isTyping = true;
            StartCoroutine(TypeText());
        }
    }

    IEnumerator TypeText()
    {
        dialogueText.text = "";
        foreach (char letter in currentText.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false; // Typing finished
    }

    public void ResetTyping()
    {
        StopAllCoroutines();
        dialogueText.text = "";
        isTyping = false;
    }
}
