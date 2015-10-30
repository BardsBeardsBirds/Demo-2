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
        AudioManager.Instance.UISoundsScript.PlayClick();   // sound

        Debug.Log("Start loading game from slot " + SlotNumber);
        GameManager.Instance.GameStateToPaused();   //?? This one??

        CharacterControllerLogic.CharacterState state = CharacterControllerLogic.Instance.GetState();
        if (state == CharacterControllerLogic.CharacterState.Talking || state == CharacterControllerLogic.CharacterState.TalkingLastLine)
            DialogueManager.EndDialogueState(DialogueManager.CurrentDialogueNPC);

        Inventory inventory = Inventory.Instance;
        inventory.InitialiseInventoryItems.Clear();
        inventory.ResetAmounts();

        Time.timeScale = 1;

    //    GameObject sceneFaderGO = GameObject.Instantiate(Resources.Load("Prefabs/UI/ScreenFaderClearToBlack")) as GameObject;
    //    sceneFaderGO.transform.SetParent(GameObject.Find("Canvas").transform);

        SaveAndLoadGame loader = new SaveAndLoadGame();
        loader.IsNotNewGame();

        GameManager.Instance.UICanvas.ScreenFader.ToBlack = true;
        GameManager.Instance.UICanvas.ScreenFader.LoadingSlot = SlotNumber;

        //SceneFader fader = sceneFaderGO.GetComponent<SceneFader>();
        //fader.BlackFader = SceneFader.ToBlack.LoadFromInGame;
        //fader.IsFadingToBlack = true;
        //SceneFader.HasLoadedGame = false;

        PauseMenu.Instance.ResumeGame();
        //   ClosePanel();

     //   PauseMenu.Instance.ResumeGame();
    }

    public void ShowUsedSlot(string slotInfo, int slotNo)
    {
        this.GetComponent<Image>().color = new Color(1f, 1f, 1f);
        this.GetComponent<Button>().interactable = true;

        Info.text = slotInfo;


        if (slotNo == 0)
        {
            Debug.Log("SAVE SLOT 0: " + WorldEvents.SavedOnSlot1);
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

