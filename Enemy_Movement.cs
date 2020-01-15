//  Dominic Morales
//  12/16/2019
//  Enemies move back and forth until Player gets within range
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float Move_Speed;
    private float Move_RNG;
    private bool Move_Right;


    public GameObject Player;
    public float Chase_Range = 10f;
    public bool Is_Chasing = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Move_Speed /= 60;
        Move_RNG = Random.Range(4, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //If the Player is not within range, just move back and forth
        if (!Is_Chasing)
        {
            if (Move_Right)
                this.transform.Translate(Move_Speed, 0, 0);
            else
                this.transform.Translate(-Move_Speed, 0, 0);
            Move_RNG -= Time.deltaTime;
            //After enough time going in one direction, we turn around and go the other way
            if (Move_RNG < 0)
            {
                Move_RNG = Random.Range(2, 5);
                Move_Right = !Move_Right;
            }
        }
        //If the Player is in range, chase them
        else
        {
            if (Player.transform.position.x > this.transform.position.x)
                this.transform.Translate(Move_Speed, 0, 0);
            else
                this.transform.Translate(-Move_Speed, 0, 0);
        }

        //Detecting whether or not the Player is within chasing range
        float Range = Vector2.Distance(this.transform.position, Player.transform.position);
        if (Chase_Range > Range)
            Is_Chasing = true;
        else
            Is_Chasing = false;       
    }
}
