using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    [SerializeField] GameObject birdPrefab;
    [SerializeField] Vector2 startPosition;

    public void Reset()
    {
        var bird = FindObjectOfType<Bird>();
        
        if (bird)
        {
            bird.Reset();
            bird.transform.position = startPosition;
        }
        else
        {
            Instantiate(birdPrefab, startPosition, Quaternion.identity);
        }
    }
}
