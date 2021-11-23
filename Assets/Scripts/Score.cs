using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] Text scoreText;

    public void IncrementScore()
    {
        SetScore(score + 1);
    }

    public void Reset()
    {
        SetScore(0);
    }

    public void SaveBestScore()
    {
        if (score > GetBestScore())
        {
            PlayerPreferences.SetBestScore(score);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public int GetBestScore()
    {
        return PlayerPreferences.GetBestScore();
    }

    private void SetScore(int newScore)
    {
        score = newScore;

        SaveBestScore();

        RefreshScoreUI();
    }

    private void RefreshScoreUI()
    {
        scoreText.text = score.ToString();
    }
}
