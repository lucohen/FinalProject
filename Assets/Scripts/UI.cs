using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup EndScreenCanvasGroup;
    public Text ScoreText;
    public Text TimeText;
    public GameTimer GameTimer;

    public void Update()
    {
        ShowTime();
        ShowScore();
    }


    public void HideStartScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }

    public void ShowStartScreen()
    {
        CanvasGroupDisplayer.Show(StartScreenCanvasGroup);
    }

    public void HideEndScreen()
    {
        CanvasGroupDisplayer.Hide(EndScreenCanvasGroup);
    }

    public void ShowEndScreen()
    {
        CanvasGroupDisplayer.Show(EndScreenCanvasGroup);
    }

    public void ShowScore()
    {
        ScoreText.text = "Score: " + ScoreKeeper.GetScore();
    }

    public void ShowTime()
    {
        TimeText.text = GameTimer.GetTimeAsString();
    }
}
