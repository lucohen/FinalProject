using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup EndScreenCanvasGroup;
    public Text KillshotsText;
    public Text MinesText;
    public Text PowerText;


    
    public void Update()
    {
        ShowKillshots();
        ShowMines();
        
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

    public void ShowKillshots()
    {
        KillshotsText.text = "Killshots -  " + NumbersKeeper.GetKillshots();
    }

    public void ShowMines()
    {
        MinesText.text = "Mines - " + NumbersKeeper.GetMines();
    }

}
