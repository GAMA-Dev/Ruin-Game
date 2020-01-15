//  Dominic Morales
//  12/20/2019
//  Throws the orb up when it spawns
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_SpawnMvmt : MonoBehaviour
{
    public float VerticalSpeed;
    public float HorizontalSpeed;

    private Rigidbody2D OrbRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        OrbRigidbody = this.GetComponent<Rigidbody2D>();
        HorizontalSpeed = Random.Range(-5, 5);
        OrbRigidbody.velocity = new Vector2(HorizontalSpeed, VerticalSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
