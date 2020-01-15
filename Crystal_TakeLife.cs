//  Dominic Morales
//  12/18/2019
//  Main crystal/game mechanic. When touching, the player can press 'Q' to drop off extra lives
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crystal_TakeLife : MonoBehaviour
{
    public float Taken_Cooldown = 0.2f;
    private bool CanTake = true;

    public static int CRYSTAL_HEALTH = 0;
    public Text Crystal_Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Only allow crystal interaction when within range and if the player can actually take it
        if (Input.GetKey(KeyCode.Q) && CanTake)
        {
            //Remove a player life and add one to the crystal life pool. Only if the player has more than 5 lives.
            if(Player_Life.HEALTH > 5)
            {
                Player_Life.HEALTH--;
                Crystal_TakeLife.CRYSTAL_HEALTH++;
            }

            CanTake = false;
            StartCoroutine(TakeBuffer());
        }
        //Display current crystal health on screen
        Crystal_Text.text = "Crystal = " + Crystal_TakeLife.CRYSTAL_HEALTH;
    }

    //Only allow the player to interact with the crystal when touching it.
    void OnTriggerEnter2D(Collider2D collision)
    {
        CanTake = true;
    }

    //Don't let the player use the crystals when they leave.
    void OnTriggerExit2D(Collider2D collision)
    {
        CanTake = false;
    }

    //Timer so the player gives lives in a timely manner
    IEnumerator TakeBuffer()
    {
        yield return new WaitForSeconds(Taken_Cooldown);
        CanTake = true;
    }
}
