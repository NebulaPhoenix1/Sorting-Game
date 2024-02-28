using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchingScript : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    private GameObject SelectedObject;
    public TMP_Text scoreText;
    //Timer modification variables
    private int correctInARow;
    private float averageSortTime; //Average time to sort. Will reset on bonus time granted
    private float sortTime = 0; //Current total sort time for next bonus
    public int neededForBonus; //Amount in a row needed to get time bonus
    public float maxTimeForBonus; //Max time in which time bonus can be granted
    //End Screen Stuff
    public int totalSorted; //Total correctly sorted
    public TMP_Text totalSortedUI;
    //Timer variables
    TimerScript timer;
    public GameObject timerText;
    //Spawn position of new card
    public Vector2 cardSpawnVector;
    
    //Function to pick the next object to sort
    private void SelectObject()
    {
        //Picks random number between 1 and 2 for left or right sorting
        int x = UnityEngine.Random.Range(1, 3);
        if (x == 1)
        {
            SelectedObject = Instantiate(left);
            SelectedObject.transform.position = cardSpawnVector;
        }
        else
        {
            SelectedObject = Instantiate(right);
            SelectedObject.transform.position = cardSpawnVector;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; //Resets time scale after reloading scene (makes it so timer keeps ticking)
        SelectObject(); //Selects the inital object to sort
        timer = timerText.GetComponent<TimerScript>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1) //This should prevent total sorted increasing on time up screen
        {
            //Check for left click
            if (Input.GetMouseButtonDown(0))
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
    }
        

    void incorrrectSort()
    {
        ///Decreases game time and resets bonus time variables
        Debug.Log("Wrong...");
        timer.decreaseTimer();
        correctInARow = 0;
        sortTime = 0;
        averageSortTime = 0;
    }

    void correctSort()
    {
        //Destroys current item and selects a new one to be sorted
        DestroyImmediate(SelectedObject, true); 
        SelectObject();
        //Updates total sorted and end game UI
        totalSorted += 1;
        totalSortedUI.SetText("You sorted " + totalSorted + " cards");
        scoreText.SetText("Score: " + totalSorted);
        //Bonus time variables updating 
        correctInARow += 1;
        sortTime += Time.deltaTime;
        averageSortTime = sortTime / correctInARow;
        //If average sort time for last 3 is less than maxTimeForBonus and you have sorted enough correctly in a row
        if (averageSortTime < maxTimeForBonus && correctInARow >= neededForBonus) 
        { 
            //Increase timer and reset all bonus variables
            timer.increaseTimer();
            correctInARow = 0;
            sortTime = 0;
            averageSortTime = 0;
        }
    }
}
