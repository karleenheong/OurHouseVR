﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{


    public float jumpAngleInDegrees;
    public float speed;
    private CardboardHead head;
    private Rigidbody rb;
    private bool onFloor;

    // Use this for initialization
    void Start()
    {
        Cardboard.SDK.OnTrigger += PullTrigger;
        head = GameObject.FindObjectOfType<CardboardHead>();
        rb = GetComponent<Rigidbody>();

    }

    private void PullTrigger()
    {
        if (onFloor)
        {
            float jumpAngleInRadians = jumpAngleInDegrees * Mathf.Deg2Rad;
            Vector3 projectedVector = Vector3.ProjectOnPlane(head.Gaze.direction, Vector3.up);
            Vector3 jumpVector = Vector3.RotateTowards(projectedVector, Vector3.up, jumpAngleInRadians, 0);
            rb.velocity = jumpVector * speed;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        onFloor = true;
    }

    void OnCollisionExit(Collision collision)
    {
        onFloor = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
