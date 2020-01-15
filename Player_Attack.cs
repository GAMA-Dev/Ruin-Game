//  Dominic Morales
//  12/14/2019
//  Spawns a hit box that eventually goes away after a certain amount of time
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public GameObject HitBox;
    public float HitCooldown;
    public float HitTime;
    public bool CanAttack;
    // Start is called before the first frame update
    void Start()
    {
        HitBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Only allows the player to attack after a certain amount of time
        if (CanAttack)
        {
            //Push E to attack
            if (Input.GetKey(KeyCode.E))
            {
                HitBox.SetActive(true);
                CanAttack = !CanAttack;
                StartCoroutine(AttackTime());
                StartCoroutine(AttackCooldown());
            }
        }
    }
    //Turns off attack hitbox after a short time
    IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(HitTime);
        HitBox.SetActive(false);
    }
    //Prevents multi attacks by making the player wait for the next one
    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(HitCooldown);
        CanAttack = !CanAttack;
    }
}
