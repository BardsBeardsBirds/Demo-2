using UnityEngine;
using UnityEngine.UI;


public class SaveGameSlot : MonoBehaviour
{

    public int SlotNumber;

    public bool SlotExists = false;
    public Text GameNo;
    public Text Info;
    public Text SaveNo;

    public void SaveGame()
    {
        AudioManager.Instance.UISoundsScript.PlayClick();   // sound

        SaveAndLoadGame saver = new SaveAndLoadGame();
        saver.SaveGameData(SlotNumber);

        PauseMenu.Instance.ResumeGame();
    }

    public void ShowUsedSlot(string slotInfo, int slotNo)
    {
       /// Debug.Log(slotNo + " WorldEvents.SavedOnNoSlots[slotNo] " + WorldEvents.SavedOnNoSlots[slotNo]);
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
        Info.text = "Save on Empty Slot";
    }
}

