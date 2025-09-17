using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI timerText;
    [SerializeField] int totalDiscussionTimeSeconds = 300;
    int remainingDiscussionTime;
    float lastUpdateTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        remainingDiscussionTime = totalDiscussionTimeSeconds;
        lastUpdateTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastUpdateTime > 1)
        {
            if (remainingDiscussionTime > 0)
            { 
                remainingDiscussionTime--;
                lastUpdateTime = Time.time;
                string displayedTimerText = "";

                if(remainingDiscussionTime % 60 < 10) { displayedTimerText = string.Format("{0}:0{1}", remainingDiscussionTime / 60, remainingDiscussionTime % 60); }
                else { displayedTimerText = string.Format("{0}:{1}", remainingDiscussionTime / 60, remainingDiscussionTime % 60); }

                if (timerText != null) { timerText.text = displayedTimerText; }
                Debug.LogFormat(displayedTimerText);
            }
            else { GameStateActions.OnGameProgress?.Invoke(); }
        }
    }
}
