using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    [SerializeField] float jumpForce = 5f;

    private Rigidbody2D rigidBody;

    private bool isReadyForJump = true;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var isTouching = Touchscreen.current.primaryTouch.press.isPressed;

        if (!isTouching && !isReadyForJump)
        {
            isReadyForJump = true;

            return;
        }

        if (isTouching && isReadyForJump)
        {
            isReadyForJump = false;

            var jumpVector = Vector2.up * jumpForce;

            rigidBody.velocity += jumpVector;

            return;
        }
    }
}
