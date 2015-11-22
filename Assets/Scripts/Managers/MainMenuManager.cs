using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour
{
    public MainMenu CurrentMenu;
    private static LoadingScreen _loadingScreen;

     public void Start()
    {
        _loadingScreen = GameObject.Find("LoadingScreen").GetComponent<LoadingScreen>();

        if (_loadingScreen == null)
            Debug.LogWarning("cannot find loading screen go");

        ShowMenu(CurrentMenu);
    }

     public void ShowMenu(MainMenu menu)
     {
         if (CurrentMenu != null)
             CurrentMenu.IsOpen = false;

         CurrentMenu = menu;
         CurrentMenu.IsOpen = true;
     }

    public void StartNewGame()
    {
        SaveAndLoadGame loader = new SaveAndLoadGame();

        loader.ThisIsANewGame();
        Debug.Log("starting a new game");
        MainMenuManager.LoadLevel();

        MainMenuSound.FadeOut = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public static void LoadLevel()
    {
        _loadingScreen.LoadLevel("Demo");
    }

    public void CheckLoadGameSlots()
    {
        SaveAndLoadGame games = new SaveAndLoadGame();
        games.CheckSaveSlots(GameType.LoadFromMainMenu);
    }
}
