using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch; 

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
        var touchCount = Touch.activeTouches.Count;
        var isTouching = touchCount > 0;

        if (isTouching)
        {
            var jumpVector = Vector2.up * jumpForce;
            
            rigidBody.velocity += jumpVector;
        }
    }
}
