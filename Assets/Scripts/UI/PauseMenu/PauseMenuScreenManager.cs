using UnityEngine;
using UnityEngine.UI;


public class PauseMenuScreenManager : MonoBehaviour
{
    public static PauseMenuScreenManager Instance;

    public GameObject PauseMenuCanvas;
    public GameObject PauseMenuMainWindow;
    public GameObject PauseMenuHelpWindow;
    public GameObject PauseSaveGameWindow;
    public GameObject PauseLoadGameWindow;
    
    public void Awake()
    {
        Instance = this;

        if (PauseMenuCanvas == null)
            PauseMenuCanvas = this.gameObject;
    
        PauseMenuMainWindow = PauseMenuCanvas.transform.FindChild("MainPanel").gameObject;
        PauseMenuHelpWindow = PauseMenuCanvas.transform.FindChild("HelpPanel").gameObject;
        PauseSaveGameWindow = PauseMenuCanvas.transform.FindChild("SaveGamePanel").gameObject;
        PauseLoadGameWindow = PauseMenuCanvas.transform.FindChild("LoadGamePanel").gameObject;

    }

    public void ShowPauseMainMenu()
    {
        PauseMenuMainWindow.GetComponent<PauseMainPanel>().PanelOpen = true;
    }

    public void HidePauseMainMenu()
    {
        PauseMenuMainWindow.GetComponent<PauseMainPanel>().PanelOpen = false;
    }

    public void ShowHelpMenu()
    {
        PauseMenuHelpWindow.GetComponent<PauseHelpPanel>().PanelOpen = true;
    }

    public void HideHelpMenu()
    {
        PauseMenuHelpWindow.GetComponent<PauseHelpPanel>().PanelOpen = false;
    }

    public void ShowSaveGameMenu()
    {
        PauseSaveGameWindow.GetComponent<SaveGamePanel>().PanelOpen = true;
    }

    public void HideSaveGameMenu()
    {
        PauseSaveGameWindow.GetComponent<SaveGamePanel>().PanelOpen = false;
    }

    public void ShowLoadGameMenu()
    {
        PauseLoadGameWindow.GetComponent<LoadGamePanel>().PanelOpen = true;
    }

    public void HideLoadGameMenu()
    {
        PauseLoadGameWindow.GetComponent<LoadGamePanel>().PanelOpen = false;
    }
}
