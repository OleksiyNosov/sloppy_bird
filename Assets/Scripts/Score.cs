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
        score++;

        RefreshScoreUI();
    }

    private void RefreshScoreUI()
    {
        scoreText.text = score.ToString();
    }
}
