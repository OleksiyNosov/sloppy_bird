using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] float stopGameDelay = 3f;

    enum GameState
    {
        Playing,
        EndGameMenu,
    }

    private ResultMenuHandler resultMenu;
    private BarrierSpawner barrierSpawner;
    private BirdSpawner birdSpawner;
    private Score score;
    private GameState gameState;

    private void Start()
    {
        gameState = GameState.Playing;

        barrierSpawner = GetComponent<BarrierSpawner>();
        birdSpawner = GetComponent<BirdSpawner>();
        score = GetComponent<Score>();
        resultMenu = GetComponent<ResultMenuHandler>();
    }

    public void EndGame()
    {
        if (gameState == GameState.EndGameMenu) return;

        gameState = GameState.EndGameMenu;

        Invoke(nameof(StopGame), stopGameDelay);
    }

    public void StartGame()
    {
        gameState = GameState.Playing;

        resultMenu.Hide();

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

        resultMenu.UpdateScore(score);
        resultMenu.Show();
    }
}
