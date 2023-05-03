using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public UI UI;
    public GameTimer GameTimer;
    public Corgi Corgi;

    private bool isRunning;

    public void Start()
    {
        UI.ShowStartScreen();
        UI.HideEndScreen();
    }

    public void Update()
    {
        if (HasGameJustEnded())
            EndGame();
    }

    public void StartGame()
    {
        isRunning = true;

        UI.HideStartScreen();
        UI.HideEndScreen();

        GameTimer.StartTimer(5);

        Corgi.StartGame();

    }

    public bool HasGameJustEnded()
    {
        if (isRunning && !GameTimer.IsRunning())
        {
            return true;
        }

        return false;
    }

    public void EndGame()
    {
        isRunning = false;

        UI.HideStartScreen();
        UI.ShowEndScreen();

        GameTimer.StopTimer();
    }

    public bool IsRunning()
    {
        return isRunning;
    }

}
