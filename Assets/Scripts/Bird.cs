using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    const string FLAP_TRIGGER = "Flap";
    const string IS_HIT = "IsHit";

    [SerializeField] float jumpForce = 5f;

    [SerializeField] float maxPositiveRoatation = 45f;
    [SerializeField] float maxNegativeRoatation = -45f;

    private Rigidbody2D rigidBody;
    private Animator animator;

    private bool isReadyForJump = true;
    private bool isHit = false;
    private float jumpVerticalVelovity = 0f;

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
    public void Hit()
    {
        isHit = true;
        jumpVerticalVelovity = 0f;
        animator.SetBool(IS_HIT, true);
        rigidBody.constraints = RigidbodyConstraints2D.None;
    }

    public void Reset()
    {
        isHit = false;
        animator.SetBool(IS_HIT, false);
        jumpVerticalVelovity = 0f;
        transform.rotation = Quaternion.identity;
        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
    }

    private void Jump()
    {
        if (isHit)
            return;

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

            jumpVerticalVelovity = rigidBody.velocity.y;

            animator.SetTrigger(FLAP_TRIGGER);

            return;
        }
    }
    private void Rotate()
    {
        if (jumpVerticalVelovity <= Mathf.Epsilon)
            return;

        var velocityPercentage = rigidBody.velocity.y / jumpVerticalVelovity;

        var angle = velocityPercentage * maxPositiveRoatation;
        var angleClamp = Mathf.Clamp(angle, maxNegativeRoatation, maxPositiveRoatation);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angleClamp);
    }

}
