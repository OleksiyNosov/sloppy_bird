using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] float speed = 5;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void Stop()
    {
        speed = 0;
    }
}
