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

        if(timerText != null) { timerText.text = UpdateTimerText(); }
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


                if (timerText != null) { timerText.text = UpdateTimerText(); }
                Debug.LogFormat(UpdateTimerText());
            }
            else 
            {
                remainingDiscussionTime = totalDiscussionTimeSeconds;
                GameStateActions.OnGameProgress?.Invoke(); 
            }
        }
    }

    string UpdateTimerText()
    {
        if (remainingDiscussionTime % 60 < 10) { return string.Format("{0}:0{1}", remainingDiscussionTime / 60, remainingDiscussionTime % 60); }
        else { return string.Format("{0}:{1}", remainingDiscussionTime / 60, remainingDiscussionTime % 60); }
    }
}
