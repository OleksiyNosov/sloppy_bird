using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject restartGamePanel;

    [SerializeField] float stopGameDelay = 3f;

    private BarrierSpawner barrierSpawner;
    private BirdSpawner birdSpawner;
    private Score score;

    private void Start()
    {
        barrierSpawner = GetComponent<BarrierSpawner>();
        birdSpawner = GetComponent<BirdSpawner>();
        score = GetComponent<Score>();
    }

    public void EndGame()
    {
        Invoke(nameof(StopGame), stopGameDelay);
    }

    public void StartGame()
    {
        barrierSpawner.Reset();
        birdSpawner.Reset();
        score.Reset();

        StartTime();
    }

    private void StartTime()
    {
        Time.timeScale = 1;
    }

    private void StopTime()
    {
        Time.timeScale = 0;
    }

    private void StopGame()
    {
        StopTime();

        restartGamePanel.SetActive(true);
    }
}
