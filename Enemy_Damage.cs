//  Dominic Morales
//  12/17/2019
//  Actions that the enemie will take upon being damaged
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{
    public int Hit_Dmg = 1;

    public float Knockback;
    public float KnockbackTime;

    public bool IFrames;
    public float IFramesTime;

    private Rigidbody2D EnemyRigidbody;
    private Enemy_Movement MovementScript;

    // Start is called before the first frame update
    void Start()
    {
        EnemyRigidbody = this.GetComponent<Rigidbody2D>();
        MovementScript = this.GetComponent<Enemy_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        //The following is used to change the alpha(trasparency) of the enemy sprite
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
        if (collision.CompareTag("Attack_Box") && !IFrames)
        {
            IFrames = !IFrames;

            //Start timers for I Frames
            StartCoroutine(IFrameCountdown());
            //Knockback enemy based on whether the player is to the left or right of the enemy
            if (this.transform.position.x < collision.transform.position.x)
                EnemyRigidbody.velocity = new Vector2(-Knockback, Knockback);
            else
                EnemyRigidbody.velocity = new Vector2(Knockback, Knockback);

            //Reduce enemy health
            this.GetComponent<Enemy_Life>().Health--;
        }
    }
    
    //Timer for player's invicible state
    private IEnumerator IFrameCountdown()
    {
        yield return new WaitForSeconds(IFramesTime);
        IFrames = !IFrames;

    }
}
