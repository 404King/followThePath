﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Ball : MonoBehaviour
{
    public float speed = 500;
    public float maxSpeed = 1500;

    [HideInInspector]
    public Rigidbody RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.acceleration.x, 0.0f, Input.acceleration.y);

#if UNITY_EDITOR
        // Allow other input controls in editor onlyz
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
#endif

        if(RB.velocity.magnitude < maxSpeed)
        {
            RB.AddForce(movement * speed * Time.deltaTime);
        }    
    }
}
