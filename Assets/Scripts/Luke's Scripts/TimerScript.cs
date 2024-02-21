using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public float startTime = 60.0f; //Start match time
    public TMP_Text timer;
    public GameObject gameplayUI;
    public GameObject timerUpUI;
    //Paused logic
    public GameObject pausedUI;
    bool paused = false;
    // Update is called once per frame
    void Update()
    {
        startTime -= Time.deltaTime;
        string startTimeString;
        startTimeString = startTime.ToString();
        timer.SetText(startTimeString);
        if (startTime <= 0.0f)
        {
            timerEnded();
        }
        //If escape pressed and there is time remaining, pause game
        if (Input.GetKeyDown(KeyCode.Escape) && startTime > 0.0f)
        {
            gamePaused();
        }
    }

    void timerEnded()
    {
        Debug.Log("Timer Ended.");
        gameplayUI.SetActive(false);
        Time.timeScale = 0;
        timerUpUI.SetActive(true);
    }

    public void decreaseTimer()
    {
        startTime -= 5.0f;
    }

    public void increaseTimer()
    {
        startTime += 5.0f;

    }

    void gamePaused()
    {
        if(paused == false)
        {
            Time.timeScale = 0;
            paused = true;
            pausedUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            paused = false;
            pausedUI.SetActive(false);
        }
    }
}
