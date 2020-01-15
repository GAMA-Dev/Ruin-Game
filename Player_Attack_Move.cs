//  Dominic Morales
//  12/17/2019
//  Simple script that always has the attack box in the right position
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack_Move : MonoBehaviour
{
    public Transform AttackPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = AttackPos.transform.position;
    }
}
