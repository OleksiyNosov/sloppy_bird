using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreferences : MonoBehaviour
{
    const string BEST_SCORE_KEY = "best_score";

    public static void SetBestScore(int score)
    {
        PlayerPrefs.SetInt(BEST_SCORE_KEY, score);
    }

    public static int GetBestScore()
    {
        return PlayerPrefs.GetInt(BEST_SCORE_KEY);
    }
}
