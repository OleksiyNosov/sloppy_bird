using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageExit : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        var bird = collision.GetComponent<Bird>();

        if (bird)
            FindObjectOfType<Score>().IncrementScore();
    }
}
