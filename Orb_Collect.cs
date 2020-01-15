//  Dominic Morales
//  12/20/2019
//  Collect the orbs and add it to life
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_Collect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_Life.HEALTH++;
            Destroy(gameObject);
        }
    }
}
