using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAutopilot : MonoBehaviour
{
    [SerializeField] bool autopilot = false;

    private Bird bird;
    private Rigidbody2D rigidBody;

    private Vector3 initialPosition;

    private void Start()
    {
        bird = GetComponent<Bird>();
        rigidBody = GetComponent<Rigidbody2D>();

        initialPosition = transform.position;
    }

    public bool ShouldJump()
    {
        return autopilot && rigidBody.velocity.y <= -bird.GetJumpForce() / 2;
    }
}
