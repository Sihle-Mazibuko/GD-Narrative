using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateTimer : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        FindAndSetTimerText();
    }

    void FindAndSetTimerText()
    {
        GameObject timerTextObject = GameObject.FindWithTag("Timer");
        if (timerTextObject != null)
        {
            TextMeshProUGUI timerText = timerTextObject.GetComponent<TextMeshProUGUI>();
            if (Timer.Instance != null)
            {
                Timer.Instance.SetTimerText(timerText);
            }
        }
        else
        {
            Debug.LogWarning("TimerText object with tag 'TimerText' not found.");
        }
    }
}
