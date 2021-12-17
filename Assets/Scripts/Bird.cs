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
    private BirdAutopilot autopilot;

    private bool isReadyForJump = true;
    private bool isHit = false;

    private float jumpVerticalVelovity = 0f;

    private GameManager gameManager;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        autopilot = GetComponent<BirdAutopilot>();

        gameManager = FindObjectOfType<GameManager>();
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

    public float GetJumpForce() => jumpForce;

    public void Reset()
    {
        isHit = false;
        animator.SetBool(IS_HIT, false);
        jumpVerticalVelovity = 0f;
        transform.rotation = Quaternion.identity;
        rigidBody.velocity = Vector2.zero;
        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
    }

    private void Jump()
    {
        if (!gameManager.IsPlaying()) 
            return;

        if (isHit)
            return;

        var isTouching = Touchscreen.current.primaryTouch.press.isPressed;
        var autoJump = autopilot.ShouldJump();

        var shouldJump = isTouching || autoJump;

        if (!isTouching && !isReadyForJump)
        {
            isReadyForJump = true;

            return;
        }

        if (shouldJump && isReadyForJump)
        {
            isReadyForJump = false;

            var jumpVector = Vector2.up * jumpForce;

            Debug.Log($"{transform.position} - {rigidBody.velocity}");

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
