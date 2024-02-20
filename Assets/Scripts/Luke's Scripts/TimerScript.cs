using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float startTime = 60.0f; //Start match time

    // Update is called once per frame
    void Update()
    {
        startTime -= Time.deltaTime;
        if (startTime <= 0.0f)
        {
            timerEnded();
        }
    }

    void timerEnded()
    {
        Debug.Log("Timer Ended.");
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
