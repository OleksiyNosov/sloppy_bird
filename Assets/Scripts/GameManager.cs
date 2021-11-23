using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] float stopGameDelay = 3f;

    enum GameState
    {
        Initial,
        Playing,
        EndGameMenu,
    }

    private StartOverlayHandler startOverlay;
    private ResultMenuHandler resultMenu;
    private GameInfoHandler gameOverlay;

    private BarrierSpawner barrierSpawner;
    private BirdSpawner birdSpawner;
    private Score score;
    private GameState gameState;

    private void Start()
    {
        gameState = GameState.Initial;
        StopTime();

        barrierSpawner = GetComponent<BarrierSpawner>();
        birdSpawner = GetComponent<BirdSpawner>();
        score = GetComponent<Score>();

        resultMenu = GetComponent<ResultMenuHandler>();
        startOverlay = GetComponent<StartOverlayHandler>();
        gameOverlay = GetComponent<GameInfoHandler>();

        startOverlay.Show();
        gameOverlay.Hide();
        resultMenu.Hide();
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

        startOverlay.Hide();
        gameOverlay.Show();

        StartTime();
    }

    public void RestartGame()
    {
        gameState = GameState.Playing;

        resultMenu.Hide();
        gameOverlay.Show();

        barrierSpawner.Reset();
        birdSpawner.Reset();
        score.Reset();

        StartTime();
    }

    public bool IsPlaying()
    {
        return gameState == GameState.Playing;
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
        gameOverlay.Hide();
    }
}
