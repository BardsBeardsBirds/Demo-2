using UnityEngine;


public class SaveGameSlot : MonoBehaviour
{
    public void SaveGame()
    {
        AudioManager.Instance.UISoundsScript.PlayClick();   // sound

        SaveAndLoadGame saver = new SaveAndLoadGame();
        saver.SaveGameData();

        PauseMenu.Instance.ResumeGame();
    }
}

