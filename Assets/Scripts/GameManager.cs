using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float resetGameDelay = 3f;

    private BarrierSpawner barrierSpawner;
    private BirdSpawner birdSpawner;
    private Score score;

    private void Start()
    {
        barrierSpawner = GetComponent<BarrierSpawner>();
        birdSpawner = GetComponent<BirdSpawner>();
        score = GetComponent<Score>();
    }

    public void RestartGame()
    {
        barrierSpawner.Stop();

        Invoke(nameof(Reset), resetGameDelay);
    }

    private void Reset()
    {
        barrierSpawner.Reset();
        birdSpawner.Reset();
        score.Reset();
    }
}
