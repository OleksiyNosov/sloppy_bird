using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultMenuHandler : MonoBehaviour
{
    public GameObject resultMenu;
    public Text currentScoreText;
    public Text bestScoreText;

    public void Show()
    {
        resultMenu.SetActive(true);
    }

    public void Hide()
    {
        resultMenu.SetActive(false);
    }

    public void UpdateScore(Score score)
    {
        currentScoreText.text = score.GetScore().ToString();
        bestScoreText.text = score.GetBestScore().ToString();
    }

    public void Play()
    {
        FindObjectOfType<GameManager>().RestartGame();
    }
}
