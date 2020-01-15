//  Dominic Morales
//  12/17/2019
//  Spawns enemies within a certain area of the player
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public float SpawnTime;
    private float SpawnTimetmp;

    //public GameObject Player;
    public GameObject EnemyPrefab;
    
    private Transform SpawnPoint;
    public Transform OBJSave;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTimetmp = SpawnTime;
        SpawnPoint = this.transform;
        var SpawnPosition = new Vector3(SpawnPoint.position.x, SpawnPoint.position.y, 0);
        OBJSave.SetPositionAndRotation(SpawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimetmp -= Time.deltaTime;

        if(SpawnTimetmp < 0 && Day_Night_Timer.IS_NIGHT)
        {
            //Generate a random number for RNG enemy spawn distance
            float pos_randomizer = UnityEngine.Random.Range(-15, 15);

            pos_randomizer = RangeCheck(pos_randomizer);

            SpawnEnemy(pos_randomizer);
            
            //Reset the clock for the next spawn
            SpawnTimetmp = SpawnTime;
        }
        else if(SpawnTimetmp < 0)
        {
            SpawnTimetmp = SpawnTime;
        }
    }

    /// Methods ////////////////////////////////////////////////////////////////////////

    //We dont want enemies spawning too close to the Player. So if it's between -5 and 5, we round to the nearest.
    private float RangeCheck(float num)
    {
        if (num < 0 && num > -5)
            num = -5;
        if (num < 5 && num > 0)
            num = 5;

        return num;
    }

    //Spawn the enemy utilizing the transform of the Player and a random number
    private void SpawnEnemy(float random_num)
    {
        var SpawnPosition = new Vector3(SpawnPoint.position.x, SpawnPoint.position.y, 0);
        OBJSave.SetPositionAndRotation(SpawnPosition, Quaternion.identity);

        OBJSave.Translate(random_num * 2, 3, 0);

        var SpawnLocation = new Vector3(OBJSave.position.x, OBJSave.position.y, 0);

        Instantiate(EnemyPrefab, SpawnLocation, Quaternion.identity);
    }
}
