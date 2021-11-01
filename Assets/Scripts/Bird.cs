using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    const string FLAP_TRIGGER = "Flap";

    [SerializeField] float jumpForce = 5f;

    [SerializeField] float maxPositiveRoatation = 45f;
    [SerializeField] float maxNegativeRoatation = -45f;

    private Rigidbody2D rigidBody;
    private Animator animator;

    private bool isReadyForJump = true;
    private float kumpVerticalVelovity = 0f;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Jump();
        Rotate();
    }

    private void Jump()
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

            kumpVerticalVelovity = rigidBody.velocity.y;

            animator.SetTrigger(FLAP_TRIGGER);

            return;
        }
    }
    private void Rotate()
    {
        if (kumpVerticalVelovity <= Mathf.Epsilon)
            return;

        var velocityPercentage = rigidBody.velocity.y / kumpVerticalVelovity;

        var angle = velocityPercentage * maxPositiveRoatation;
        var angleClamp = Mathf.Clamp(angle, maxNegativeRoatation, maxPositiveRoatation);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angleClamp);
    }

}
