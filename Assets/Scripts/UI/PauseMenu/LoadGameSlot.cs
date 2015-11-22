using UnityEngine;
using UnityEngine.UI;

public class LoadGameSlot : MonoBehaviour
{
    public int SlotNumber;
    public bool SlotExists = false;
    public Text GameNo;
    public Text Info;
    public Text SaveNo;
    
    public void Awake()
    {
        if(!SlotExists)
        {
            this.GetComponent<Image>().color = new Color(0.72f, 0.72f, 0.72f);
            this.GetComponent<Button>().interactable = false;
        }
    }

    public void LoadGame()
    {
        GameManager.MyGameType = GameType.LoadFromInGame; //after we implement the main menu we can get rid of this line.

        Debug.Log("Start loading game from slot " + SlotNumber);
        GameManager.Instance.GameStateToPaused();   //?? This one??

        CharacterControllerLogic.CharacterState state = CharacterControllerLogic.Instance.GetState();
        if (state == CharacterControllerLogic.CharacterState.Talking || state == CharacterControllerLogic.CharacterState.TalkingLastLine)
            DialogueManager.EndDialogueState(DialogueManager.CurrentDialogueNPC);

        Inventory inventory = Inventory.Instance;

        inventory.ResetAmounts();

        Time.timeScale = 1;

        SaveAndLoadGame loader = new SaveAndLoadGame();
        loader.IsNotNewGame(SlotNumber);

        GameManager.Instance.UICanvas.ScreenFader.StartToBlack(SlotNumber);

        PauseMenu.Instance.ResumeGame();
    }

    public void LoadGameFromMainMenu()
    {
        SaveAndLoadGame loader = new SaveAndLoadGame();
        loader.IsNotNewGame(SlotNumber);

        MainMenuManager.LoadLevel();

        MainMenuSound.FadeOut = true;
    }

    public void ShowUsedSlot(string slotInfo, int slotNo)
    {
        this.GetComponent<Image>().color = new Color(1f, 1f, 1f);
        this.GetComponent<Button>().interactable = true;

        Info.text = slotInfo;


        if (slotNo == 0)
        {
            SaveNo.text = "Save No.\n" + "" + WorldEvents.SavedOnSlot1;
        }
        else if (slotNo == 1)
        {
            SaveNo.text = "Save No.\n" + "" + WorldEvents.SavedOnSlot2;
        }
        else if (slotNo == 2)
        {
            SaveNo.text = "Save No.\n" + "" + WorldEvents.SavedOnSlot3;
        }
        else if (slotNo == 3)
        {
            SaveNo.text = "Save No.\n" + "" + WorldEvents.SavedOnSlot4;
        }
    }

    public void ShowEmptySlowText()
    {
        Info.text = "Empty Slot";
    }
}

