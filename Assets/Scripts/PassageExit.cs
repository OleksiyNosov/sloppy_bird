using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageExit : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<Score>().IncrementScore();
    }
}
