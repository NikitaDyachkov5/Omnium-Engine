using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem 
{
    private const string SAVE_NAME = "MaxScore";

    public int Score {  get; private set; }

    public int MaxScore { get; private set; }

    public bool InNewScoreRecord { get; private set; }

    public void StartGame()
    {
        Score = 0;
        MaxScore = PlayerPrefs.GetInt(SAVE_NAME, 0);
        InNewScoreRecord = false;
    }

    public void EndGame()
    {
        if(Score > MaxScore)
        {
            MaxScore = Score;
            PlayerPrefs.SetInt(SAVE_NAME, MaxScore);
            InNewScoreRecord = true;
        }
    }

    public void AddScore(int earnedScore)
    {
        Score += earnedScore;
    }

}
