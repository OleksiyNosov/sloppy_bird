using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var bird = collision.collider.GetComponent<Bird>();

        if (bird)
        {
            bird.Hit();

            FindObjectOfType<GameManager>().RestartGame();
        }
    }
}
