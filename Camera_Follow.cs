//  Dominic Morales
//  12/18/2019
//  Camera follows the player via script at specific speeds
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public float FollowSpeed = 5;
    private float FastSpeed;
    private float SlowSpeed;
    public float SlowRange = 1;

    public float ZoomTimeOffset;
    private bool IsZoomed = false;

    public Transform PlayerPos;
    // Start is called before the first frame update
    void Start()
    {
        //Find the Player object and define speeds
        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        FastSpeed = FollowSpeed / 30;
        SlowSpeed = FollowSpeed / 60;
    }

    // Update is called once per frame
    void Update()
    {
        //Define the 'slow range' which will slow the camera follow speed to feel a bit more 'natural'
        float Range = Vector2.Distance(this.transform.position, PlayerPos.position);
        //If the player moves to the right, move the camera right. 
        if (this.transform.position.x < PlayerPos.position.x)
        {
            if(Range <= SlowRange)
            {
                this.transform.Translate(SlowSpeed, 0, 0);
            }
            else
            {
                this.transform.Translate(FastSpeed, 0, 0);
            }
            
        }
        //If the player moves to the left, move the camera left. 
        if (this.transform.position.x > PlayerPos.position.x)
        {
            if (Range <= SlowRange)
            {
                this.transform.Translate(-SlowSpeed, 0, 0);
            }
            else
            {
                this.transform.Translate(-FastSpeed, 0, 0);
            }
        }
        //If the player moves to the up, move the camera up. 
        if (this.transform.position.y < PlayerPos.position.y)
        {
            if (Range <= SlowRange)
            {
                this.transform.Translate(0, SlowSpeed, 0);
            }
            else
            {
                this.transform.Translate(0, FastSpeed, 0);
            }
        }
        //If the player moves to the down, move the camera down. 
        if (this.transform.position.y > PlayerPos.position.y)
        {
            if (Range <= SlowRange)
            {
                this.transform.Translate(0, -SlowSpeed, 0);
            }
            else
            {
                this.transform.Translate(0, -FastSpeed, 0);
            }
        }

        if (Day_Night_Timer.IS_NIGHT && !IsZoomed)
        {
            if (this.GetComponent<Camera>().orthographicSize < 10)
                this.GetComponent<Camera>().orthographicSize += (Time.deltaTime / ZoomTimeOffset);
            else
                IsZoomed = true;
        }
        if (!Day_Night_Timer.IS_NIGHT && IsZoomed)
        {
            if (this.GetComponent<Camera>().orthographicSize > 5)
                this.GetComponent<Camera>().orthographicSize -= (Time.deltaTime / ZoomTimeOffset);
            else
                IsZoomed = false;
        }
    }
}
