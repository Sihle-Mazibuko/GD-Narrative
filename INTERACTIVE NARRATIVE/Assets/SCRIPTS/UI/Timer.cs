using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    [SerializeField] float totalTime = 15 * 1;

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
                OnTimerEnd();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        if (timerText == null) return;

        int minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = currentTime % 60;
        int milliseconds = Mathf.FloorToInt((currentTime % 1) * 1000);

        if (currentTime <= 60)
        {
            timerText.color = Color.red;
            timerText.fontSize = 60;
            timerText.text = string.Format("{0:00}:{1:00}.{2:000}", minutes, Mathf.Floor(seconds), milliseconds);
        }
        else if (currentTime <= 5 * 60)
        {
            timerText.color = new Color(1.0f, 0.64f, 0.0f);
            timerText.fontSize = 50;
            timerText.text = string.Format("{0:00}:{1:00}.{2:000}", minutes, Mathf.Floor(seconds), milliseconds);
        }
        else
        {
            timerText.color = Color.black;
            timerText.fontSize = 40;
            timerText.text = string.Format("{0:00}:{1:00}.{2:000}", minutes, Mathf.Floor(seconds), milliseconds);
        }

        timerText.text = timerText.text.Replace("." + milliseconds.ToString("000"), "<size=20>" + "." + milliseconds.ToString("000") + "</size>");
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

    void OnTimerEnd()
    {
        Debug.Log("Timer has reached 0!");
        SceneManager.LoadScene("GameOver"); 
    }
}


