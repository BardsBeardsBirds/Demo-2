using System;
using System.Collections.Generic;
using UnityEngine;

public enum PauseMenuStates {Main, Help, SaveGame, LoadGame, None};

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;
    public PauseMenuStates MenuState;

    public void Start()
    {
        Instance = this;
    }

    public void ToMainPauseMenu()
    {
        PauseMenuScreenManager.Instance.ShowPauseMainMenu();      

        if (InventoryCanvas.InventoryIsOpen)
            GameManager.Instance.UICanvas.HideInventory();

        GameManager.Instance.UICanvas.HideScreenButtonWidget();

        MenuState = PauseMenuStates.Main;

        GameManager.Instance.GameStateToPaused();

        AudioListener.pause = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        AudioManager.Instance.UISoundsScript.PlayClick();   // sound
        GameManager.Instance.GameStateToRunning();/////

        ClosePanel();
        ShowInGamePanels();
        MenuState = PauseMenuStates.None;

        AudioListener.pause = false;
        Time.timeScale = 1;
    }

    public void ToHelp()
    {
        PauseMenuScreenManager.Instance.HidePauseMainMenu();
        PauseMenuScreenManager.Instance.ShowHelpMenu();

        MenuState = PauseMenuStates.Help;
    }

    public void ToSaveGame()
    {
        SaveAndLoadGame games = new SaveAndLoadGame();
        games.CheckSaveSlots(2);

        PauseMenuScreenManager.Instance.HidePauseMainMenu();
        PauseMenuScreenManager.Instance.ShowSaveGameMenu(); 
        
        MenuState = PauseMenuStates.SaveGame;
    }

    public void ToLoadGame()
    {
        SaveAndLoadGame games = new SaveAndLoadGame();
        games.CheckSaveSlots(1);

        PauseMenuScreenManager.Instance.HidePauseMainMenu();
        PauseMenuScreenManager.Instance.ShowLoadGameMenu(); 
        
        MenuState = PauseMenuStates.LoadGame;
    }

    public void ToQuitGame()
    {
        AudioManager.Instance.UISoundsScript.PlayDrumRoll();   // sound
        StartCoroutine(TimeManager.WaitUntilEndOfClip(2f));
        MyConsole.WriteToConsole("We quit the game");
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        switch (MenuState)
        {
            case PauseMenuStates.Help:
                PauseMenuScreenManager.Instance.HideHelpMenu();
                break;
            case PauseMenuStates.SaveGame:
                PauseMenuScreenManager.Instance.HideSaveGameMenu();
                break;
            case PauseMenuStates.LoadGame:
                PauseMenuScreenManager.Instance.HideLoadGameMenu();

                break;
        }
        PauseMenuScreenManager.Instance.ShowPauseMainMenu();
        MenuState = PauseMenuStates.Main;
    }

    private void ClosePanel()
    {
        if (MenuState == PauseMenuStates.Main)
        {
            PauseMenuScreenManager.Instance.HidePauseMainMenu();
        }
        else if (MenuState == PauseMenuStates.Help)
        {
            PauseMenuScreenManager.Instance.HideHelpMenu();
        }
        else if (MenuState == PauseMenuStates.SaveGame)
        {
            PauseMenuScreenManager.Instance.HideSaveGameMenu();
        }
        else if (MenuState == PauseMenuStates.LoadGame)
        {
            PauseMenuScreenManager.Instance.HideLoadGameMenu();
        }

        if (InventoryCanvas.InventoryIsOpen)
            GameManager.Instance.UICanvas.ShowInventory();
    }

    private void ShowInGamePanels()
    {
        GameManager.Instance.UICanvas.ShowScreenButtonWidget();
    }

}