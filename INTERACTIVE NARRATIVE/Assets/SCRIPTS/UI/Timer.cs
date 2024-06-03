using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    [SerializeField] float totalTime = 15 * 60;

    float currentTime;
    bool isRunning;
    TextMeshProUGUI timerText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            currentTime = totalTime;
            isRunning = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Find the timer text component by tag
        FindTimerText();
    }

    void Update()
    {
        if (isRunning)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                currentTime = 0;
                isRunning = false;
                UpdateTimerDisplay();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        if (timerText == null) return;

        if (currentTime <= 60)
        {
            timerText.color = Color.red;
            timerText.fontSize = 60;
            timerText.text = currentTime.ToString("F2") + "s";
        }
        else if (currentTime <= 5 * 60)
        {
            timerText.color = new Color(1.0f, 0.64f, 0.0f);
            timerText.fontSize = 50;
            int minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = currentTime % 60;
            timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        }
        else
        {
            timerText.color = Color.white;
            timerText.fontSize = 40;
            int minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = currentTime % 60;
            timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        }
    }

    public void SetTimerText(TextMeshProUGUI newTimerText)
    {
        timerText = newTimerText;
        UpdateTimerDisplay();
    }

    void FindTimerText()
    {
        GameObject timerTextObject = GameObject.FindWithTag("Timer");
        if (timerTextObject != null)
        {
            timerText = timerTextObject.GetComponent<TextMeshProUGUI>();
            UpdateTimerDisplay();
        }
        else
        {
            Debug.LogWarning("TimerText object with tag 'TimerText' not found.");
        }
    }
}
