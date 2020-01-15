//  Dominic Morales
//  12/20/2019
//  Handles Enemy health and spawns orb upon death
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Life : MonoBehaviour
{
    //Set variables
    public int Health = 1;

    public int OrbCount = 1;
    public GameObject OrbPrefab;

    // Update is called once per frame
    void Update()
    {
        //Kill enemy if health < 0
        if(Health <= 0)
        {
            var SpawnLocation = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, 0);
            for(int i = 0; i < OrbCount; i++)
            {
                Instantiate(OrbPrefab, SpawnLocation, Quaternion.identity);
            }
            
            Destroy(gameObject);
        }
    }
}
