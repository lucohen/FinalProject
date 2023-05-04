using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public UI UI;
    public Sandie Sandie;

    private bool isRunning;

    public void Start()
    {
        UI.ShowStartScreen();
        UI.HideEndScreen();
    }

    public void Update()
    {
        //if (HasGameJustEnded())
          //  EndGame();
    }

    public void StartGame()
    {
        isRunning = true;

        UI.HideStartScreen();
        UI.HideEndScreen();


        Sandie.StartGame();

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
