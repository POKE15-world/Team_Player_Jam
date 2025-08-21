using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60f; // Set your desired countdown time
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText; // Optional: assign in Inspector for UI display

    void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                GameObject.Find("Player_1").GetComponent<PlayerMovement>().enabled = false;
                GameObject.Find("Player_2").GetComponent<PlayerMovement>().enabled = false;
                Debug.Log("Time's up!");
                timeRemaining = 0;
                timerIsRunning = false;
                // Trigger your event here (e.g., end game, show results)
            }
        }

    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // Optional: rounds up to nearest second
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        if (timeText != null)
        {
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}

