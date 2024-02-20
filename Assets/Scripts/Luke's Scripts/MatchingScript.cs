using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingScript : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    private GameObject SelectedObject;
    //Timer modification variables
    private int correctInARow;
    private float averageSortTime; //Average time to sort. Will reset on bonus time granted
    private float sortTime = 0; //Current total sort time for next bonus
    public int neededForBonus; //Amount in a row needed to get time bonus
    public float maxTimeForBonus; //Max time in which time bonus can be granted
    //Timer variables
    TimerScript timer;
    public GameObject timerText;
    
    //Function to pick the next object to sort
    private void SelectObject()
    {
        //Picks random number between 1 and 2 for left or right sorting
        int x = UnityEngine.Random.Range(1, 3);
        if (x == 1)
        {
            SelectedObject = Instantiate(left);
            SelectedObject.transform.position = new Vector2(0, 0);
        }
        else
        {
            SelectedObject = Instantiate(right);
            SelectedObject.transform.position = new Vector2(0, 0);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SelectObject(); //Selects the inital object to sort
        timer = timerText.GetComponent<TimerScript>();
    }
    // Update is called once per frame
    void Update()
    {
        //Check for left click
        if(Input.GetMouseButtonDown(0))
        {
            //If matching object has correct tag
            if (SelectedObject.tag == "Left")
            {
                correctSort();
            }
            //If matching object is wrong
            else
            {
                incorrrectSort();
            }
        }
        //Check for right click
        if (Input.GetMouseButtonDown(1))
        {
            //If matching object has correct tag
            if (SelectedObject.tag == "Right")
            {
                correctSort();
            }
            //If matching object is wrong
            else
            {
                incorrrectSort();
            }
        }
    }

    void incorrrectSort()
    {
        Debug.Log("Wrong...");
        timer.decreaseTimer();
        correctInARow = 0;
        sortTime = 0;
        averageSortTime = 0;
    }

    void correctSort()
    {
        DestroyImmediate(SelectedObject, true);
        SelectObject();
        correctInARow += 1;
        sortTime += Time.deltaTime;
        averageSortTime = sortTime / correctInARow;
        if (averageSortTime < maxTimeForBonus && correctInARow >= neededForBonus) 
        { 
            timer.increaseTimer();
            correctInARow = 0;
            sortTime = 0;
            averageSortTime = 0;
        }
    }
}
