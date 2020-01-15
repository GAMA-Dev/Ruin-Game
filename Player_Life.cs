//  Dominic Morales
//  11/14/2019
//  Keeps track of player's health points and displays them on the screen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Life : MonoBehaviour
{
    //Set variables
    public static int HEALTH = 5;
    public Text Health_Text;

    // Update is called once per frame
    void Update()
    {
        //Display current player health on screen
        Health_Text.text = "Health = " + Player_Life.HEALTH;
    }
}