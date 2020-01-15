//  Dominic Morales
//  12/16/2019
//  Timer for player to see that also controls the background so it gets darker.
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day_Night_Timer : MonoBehaviour
{
    public static bool IS_NIGHT;
    public float minute = 0;
    public float hour = 0;

    public Text timerText;

    public GameObject Background;
    public Color CLR_night;
    private Color CLR_night_tmp;
    public float Day_Night_Offset;

    private bool BG_Is_Changing = false;
    // Start is called before the first frame update
    void Start()
    {
        //Starts the game duringt the day
        Day_Night_Timer.IS_NIGHT = false;
        CLR_night_tmp = CLR_night;
        CLR_night_tmp.a = 0f;
        Background.GetComponent<SpriteRenderer>().color = CLR_night_tmp;
    }

    // Update is called once per frame
    void Update()
    {
        //Change darker background's opacity based on whether it's day or not
        if(!Day_Night_Timer.IS_NIGHT && CLR_night_tmp.a != 0)
            NightToDay();

        if(Day_Night_Timer.IS_NIGHT && CLR_night_tmp.a != 1)
            DayToNight();

        //Apply color changes to background
        Background.GetComponent<SpriteRenderer>().color = CLR_night_tmp;

        //Timer for text on screen (one second is one minute)
        minute += Time.deltaTime;

        FormatTime();
        

        //At 0700 and 1900, change from day to night or vise versa
        if((hour == 7 && Mathf.Round(minute % 60) == 0 && !BG_Is_Changing) || (hour == 19 && Mathf.Round(minute % 60) == 0 && !BG_Is_Changing))
        {
            Day_Night_Timer.IS_NIGHT = !Day_Night_Timer.IS_NIGHT;
            BG_Is_Changing = true;
            //Delay the change so it won't happen before minute 00 ends
            StartCoroutine(BGChangeDelay());
        }

        SetText();
    }

    /// Methods ////////////////////////////////////////////////////////////////////////
    
    private void SetText()
    {
        //If minutes is less than 10, put zero in front of minutes on timer
        if (Mathf.Round(minute % 60) < 10)
        {
            //If hours is less than 10, put zero in front of hour on timer
            if (hour < 10)
                timerText.text = "0" + hour + ":0" + Mathf.Round(minute % 60);
            else
                timerText.text = "" + hour + ":0" + Mathf.Round(minute % 60);
        }

        //If minutes is greater than 10, do nothing to minutes
        else
        {
            //If hours is less than 10, put zero in front of hour on timer
            if (hour < 10)
                timerText.text = "0" + hour + ":" + Mathf.Round(minute % 60);
            else
                timerText.text = "" + hour + ":" + Mathf.Round(minute % 60);
        }
    }

    //Make timer look pretty
    private void FormatTime()
    {
        //Never reach the 60th minute, we go straight to 00 and count the hour up
        if (minute > 59)
        {
            minute -= 59;
            hour++;
        }

        //Using 24 hour clock, never reach hour 24, reset to 00
        if (hour > 23)
        {
            hour = 0;
        }
    }

    //Slowly make the background opaque
    private void DayToNight()
    {
        CLR_night_tmp.a += (Time.deltaTime / Day_Night_Offset);
        if (CLR_night_tmp.a > 1)
            CLR_night_tmp.a = 1;
    }

    //Slowly make the background transparent
    private void NightToDay()
    {
        CLR_night_tmp.a -= (Time.deltaTime / Day_Night_Offset);
        if (CLR_night_tmp.a < 0)
            CLR_night_tmp.a = 0;
    }

    IEnumerator BGChangeDelay()
    {
        yield return new WaitForSeconds(2);
        BG_Is_Changing = false;
    }
}
