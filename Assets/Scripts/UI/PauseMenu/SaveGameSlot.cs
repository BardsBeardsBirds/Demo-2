using UnityEngine;
using UnityEngine.UI;


public class SaveGameSlot : MonoBehaviour
{
    public int SlotNumber;

    public bool SlotExists = false;
    public Text GameNo;
    public Text Info;

    public void SaveGame()
    {
        AudioManager.Instance.UISoundsScript.PlayClick();   // sound

        SaveAndLoadGame saver = new SaveAndLoadGame();
        saver.SaveGameData(SlotNumber);

        PauseMenu.Instance.ResumeGame();
    }

    public void ShowUsedSlot(string slotInfo)
    {
        Info.text = slotInfo;
    }

    public void ShowEmptySlowText()
    {
        Info.text = "Save on Empty Slot";
    }
}

