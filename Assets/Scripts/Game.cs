using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public UI UI;
    public Sandie Sandie;
    public Sounds Sounds;

    private bool isRunning;

    public void Start()
    {
        UI.HideEndScreen();
        UI.ShowStartScreen();
        
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
        Sounds.PlayPlayButtonSound();


        Sandie.StartGame();

    }

    public bool HasGameJustEnded()
    {
        if (isRunning && Sandie.isDead == true)
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

    }

    public bool IsRunning()
    {
        return isRunning;
    }

}
