using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);

        var barrier = collision.GetComponent<Barrier>();

        if (barrier)
            PerishObject(barrier);
    }

    private void PerishObject(Barrier barrier)
    {
        barrier.gameObject.SetActive(false);
        Destroy(barrier);
    }
}
