using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float jumpForce = 5f;

    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var jumpPressed = Input.GetButtonDown("Jump");

        if (jumpPressed)
        {
            var jumpVector = Vector2.up * jumpForce;
            
            rigidBody.velocity += jumpVector;
        }
    }
}
