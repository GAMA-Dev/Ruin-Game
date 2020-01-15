//  Dominic Morales
//  12/14/2019
//  Knocks the player back when colliding with the enemy, and removes a life
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Player_Hurt : MonoBehaviour
{
    private Rigidbody2D PlayerRigidbody;
    private Player_Movement Player_Movement;

    public int IFramesTime;
    public bool IFrames;

    public float Knockback;
    public float KnockbackCounter;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = this.GetComponent<Rigidbody2D>();
        Player_Movement = this.GetComponent<Player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        //The following is used to change the alpha(trasparency) of the player sprite
        Color tmp = this.GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        this.GetComponent<SpriteRenderer>().color = tmp;
        if (IFrames)
        {
            tmp.a = 0.5f;
            this.GetComponent<SpriteRenderer>().color = tmp;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Make sure only enemies activate these scripts
        if (collision.CompareTag("Enemy") && !IFrames)
        {
            IFrames = !IFrames;
            //Turn off scripts that allow control of player
            Player_Movement.enabled = !Player_Movement.enabled;
            //Start timers for knockback and I Frames
            StartCoroutine(KnockBackTimer());
            StartCoroutine(IFrameCountdown());
            //Knockback player based on whether the player is to the left or right of the enemy
            if(this.transform.position.x < collision.transform.position.x)
                PlayerRigidbody.velocity = new Vector2(-Knockback, Knockback);
            else
                PlayerRigidbody.velocity = new Vector2(Knockback, Knockback);
            Player_Life.HEALTH--;
            if(Player_Life.HEALTH <= 0)
            {
                Debug.Log("GameOver");
            }
        }
    }

    //Timer for the knockback and re-enables the player movement scripts
    private IEnumerator KnockBackTimer()
    {
        yield return new WaitForSeconds(KnockbackCounter);
        Player_Movement.enabled = !Player_Movement.enabled;

    }
    //Timer for player's invicible state
    private IEnumerator IFrameCountdown()
    {
        yield return new WaitForSeconds(IFramesTime);
        IFrames = !IFrames;

    }
}
