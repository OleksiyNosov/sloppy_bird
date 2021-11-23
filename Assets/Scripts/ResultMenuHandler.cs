using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultMenuHandler : MonoBehaviour
{
    public void Play()
    {
        FindObjectOfType<GameManager>().EndGame();
    }
}
