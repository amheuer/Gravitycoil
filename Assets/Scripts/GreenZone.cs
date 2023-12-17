using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenZone : MonoBehaviour
{
    public GameObject redZone;
    public float checkRadius = 1f; // set this to an appropriate value for your game
    public LayerMask whatIsObject; // set this to the layer(s) that your objects are on
    public Array colliders;

    private void FixedUpdate()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, checkRadius, whatIsObject);
        if (colliders.Length == 0)
        {
            // no other objects in green zone, so instantiate a new red zone
            Instantiate(redZone, transform.position, Quaternion.identity);
            Destroy(gameObject, 0f);
        }
    }
}
