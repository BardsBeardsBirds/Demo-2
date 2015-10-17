using UnityEngine;


public class LoadGameSlot : MonoBehaviour
{
    public void LoadGame()
    {
        AudioManager.Instance.UISoundsScript.PlayClick();   // sound

        Debug.Log("Start loading game");
        GameManager.Instance.GameStateToPaused();   //?? This one??

        CharacterControllerLogic.CharacterState state = CharacterControllerLogic.Instance.GetState();
        if (state == CharacterControllerLogic.CharacterState.Talking || state == CharacterControllerLogic.CharacterState.TalkingLastLine)
            DialogueManager.EndDialogueState(DialogueManager.CurrentDialogueNPC);

        Inventory inventory = Inventory.Instance;
        inventory.InitialiseInventoryItems.Clear();
        inventory.ResetAmounts();

        Time.timeScale = 1;

        GameObject sceneFaderGO = GameObject.Instantiate(Resources.Load("Prefabs/UI/ScreenFaderClearToBlack")) as GameObject;
        sceneFaderGO.transform.SetParent(GameObject.Find("Canvas").transform);

        SaveAndLoadGame loader = new SaveAndLoadGame();
        loader.IsNotNewGame();

        SceneFader fader = sceneFaderGO.GetComponent<SceneFader>();
        fader.BlackFader = SceneFader.ToBlack.LoadFromInGame;
        fader.IsFadingToBlack = true;
        SceneFader.HasLoadedGame = false;

        PauseMenu.Instance.MenuState = PauseMenuStates.Main;
     //   ClosePanel();

     //   PauseMenu.Instance.ResumeGame();

    }

    //private void ClosePanel()
    //{
    //    PauseMenuScreenManager.Instance.HideLoadGameMenu();

    //    if (InventoryCanvas.InventoryIsOpen)
    //        GameManager.Instance.UICanvas.ShowInventory();
    //}
}

