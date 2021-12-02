using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageExit : MonoBehaviour
{
    private bool haveBeenTriggered = false;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (haveBeenTriggered) { return; }

        var bird = collision.GetComponent<Bird>();
        
        if (bird && havePassed(bird))
            IncrementScore();

    }

    private void IncrementScore()
    {
        haveBeenTriggered = true;

        FindObjectOfType<Score>().IncrementScore();
    }

    private bool havePassed(Bird bird)
    {
        return transform.position.x < bird.transform.position.x;
    }
}
