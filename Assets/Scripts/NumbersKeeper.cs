using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NumbersKeeper
{
    private static int killshots;
    private static int mines = 2;

    public static int GetKillshots()
    {
        return killshots;
    }

    public static int GetMines()
    {
        return mines;
    }

    public static void AddToKillshots()
    {
        killshots++;
    }

    public static void LoseKillshot()
    {
        killshots--;
    }

    public static void AddToMines()
    {
        mines++;
    }
    public static void LoseMine()
    {
        mines--;
    }
}