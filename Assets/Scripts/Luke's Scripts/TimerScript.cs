using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public float startTime = 60.0f; //Start match time
    public TMP_Text timer;
    

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
    }

    void timerEnded()
    {
        Debug.Log("Timer Ended.");
        SceneManager.LoadScene("Menu");
    }

    public void decreaseTimer()
    {
        startTime -= 5.0f;
    }

    public void increaseTimer()
    {
        startTime += 5.0f;

    }
}
