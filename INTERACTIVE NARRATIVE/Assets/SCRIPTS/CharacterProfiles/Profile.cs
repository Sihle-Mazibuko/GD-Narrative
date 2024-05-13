using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    private Text profileText;
    private RectTransform backgroundRectTransform;

    private void Awake()
    {
        backgroundRectTransform = transform.Find("background").GetComponent<RectTransform>();
        profileText = transform.Find("text").GetComponent<Text>();

        ShowProfile("Random profile text");
    }

    private void ShowProfile(string profileString)
    {
        gameObject.SetActive(true);

        profileText.text = profileString;
        float textPaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(profileText.preferredWidth + textPaddingSize * 2f, profileText.preferredHeight + textPaddingSize * 2f);
    }

    private void HideProfile()
    {
        gameObject.SetActive(false);
    }
}
