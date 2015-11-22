using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveAndLoadGame
{
    public void SaveGameData(int slot)
    {
        BinaryFormatter bf = new BinaryFormatter();

        string saveSlotName = FindSavePath(slot);
        FileStream file = File.Create(Application.persistentDataPath + saveSlotName);

        SaveGameData data = new SaveGameData();
        saveGameSlotData(data, slot);
        savePlayerState(data);
        saveWorldEvents(data);
        saveInGameObjects(data);
        saveInventoryData(data);

        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadGameData(int slot)
    {
        string loadSlotName = FindLoadPath(slot);
        if (File.Exists(Application.persistentDataPath + loadSlotName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + loadSlotName, FileMode.Open);
            SaveGameData data = (SaveGameData)bf.Deserialize(file);
            file.Close();

            loadGameSlotData(data);
            loadPlayerState(data);
            loadWorldEvents(data);
            loadInGameObjects(data);
            if (GameManager.MyGameType == GameType.LoadFromInGame)
            {
                Debug.Log("Load game from in-game");
                LoadGameIngame(data);  
            }
            else  
            {
                Debug.Log("Load game from main menu");
                LoadGameFromMainMenu();
            }
        }
        else
            Debug.Log("There is no game saved");
    }

    public void LoadGameIngame(SaveGameData data)
    {
        GameManager.Instance.SetPlayerPosition();
        ThirdPersonCamera.Instance.LoadGameCameraPosition();
        loadInventoryItemsInGame(data);
        InGameObjectManager.Instance.LoadInGameObjectsInfo();   //see what objects should be turned off
        GameManager.Instance.LoadEventConsequences();           //load the consequences of any world event

        GameManager.Instance.GameStateToRunning();
    }

    public void LoadGameFromMainMenu()
    {
        GameManager.Instance.LoadEventConsequences();           //load the consequences of any world event

        GameManager.Instance.GameStateToRunning();
    }

    public void ThisIsANewGame()
    {
        using (StreamWriter sw = new StreamWriter("NewGame.txt"))
        {
            // Add some text to the file.
            sw.Write("This is a new game");
        }
    }

    public void IsNotNewGame(int gameSlotNo)
    {
        using (StreamWriter sw = new StreamWriter("NewGame.txt"))
        {
            // Add some text to the file.
            sw.Write("This is not a new game. Game slot " + gameSlotNo);
        }
    }

    public void CheckSaveSlots(GameType loadOrSave)
    {
        // load game from Pause Menu
        if (loadOrSave == GameType.LoadFromInGame)
        {
            LoadGamePanel loadGamePanel = PauseMenuScreenManager.Instance.PauseLoadGameWindow.GetComponent<LoadGamePanel>();

            for (int i = 0; i < loadGamePanel.GameSlots.Count; i++)
            {
                string saveSlotName = FindSavePath(i + 1);

                if (File.Exists(Application.persistentDataPath + saveSlotName))
                {
                    LoadTimesSavedOnSlot(saveSlotName, i + 1);

                        string slotInfo = LoadGameSlotInfo(saveSlotName);

                        loadGamePanel.GameSlots[i].SlotExists = true;
                        loadGamePanel.GameSlots[i].ShowUsedSlot(slotInfo, i);
                }
                else
                {
                    loadGamePanel.GameSlots[i].ShowEmptySlowText();
                }
            }
        }

        //save game from Pause Menu
        else if (loadOrSave == GameType.None)
        {
            SaveGamePanel saveGamePanel = PauseMenuScreenManager.Instance.PauseSaveGameWindow.GetComponent<SaveGamePanel>();

            for (int i = 0; i < saveGamePanel.GameSlots.Count; i++)
            {
                string saveSlotName = FindSavePath(i + 1);

                if (File.Exists(Application.persistentDataPath + saveSlotName))
                {
                    LoadTimesSavedOnSlot(saveSlotName, i + 1);

                        string slotInfo = LoadGameSlotInfo(saveSlotName);

                        saveGamePanel.GameSlots[i].SlotExists = true;
                        saveGamePanel.GameSlots[i].ShowUsedSlot(slotInfo, i);
                }
                else
                {
                    saveGamePanel.GameSlots[i].ShowEmptySlowText();
                }
            }
        }
            //load game from Main Menu
        else if(loadOrSave == GameType.LoadFromMainMenu)
        {
            LoadGamePanel loadGamePanel = GameObject.Find("LoadGameMenu").GetComponent<LoadGamePanel>();

            for (int i = 0; i < loadGamePanel.GameSlots.Count; i++)
            {
                string saveSlotName = FindSavePath(i + 1);

                if (File.Exists(Application.persistentDataPath + saveSlotName))
                {
                    LoadTimesSavedOnSlot(saveSlotName, i + 1);

                    string slotInfo = LoadGameSlotInfo(saveSlotName);

                    loadGamePanel.GameSlots[i].SlotExists = true;
                    loadGamePanel.GameSlots[i].ShowUsedSlot(slotInfo, i);
                }
                else
                {
                    loadGamePanel.GameSlots[i].ShowEmptySlowText();
                }
            }
        }
        else
            Debug.LogWarning("This must be a wrong value");
    }

    public string LoadGameSlotInfo(string saveName)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + saveName, FileMode.Open);
        SaveGameData data = (SaveGameData)bf.Deserialize(file);
        file.Close();

        string saveDate = data.SaveDateTime.ToString("MM-dd-yyyy");
        string saveTime = data.SaveDateTime.ToString("HH:mm");
        string location = data.CurrentArea.ToString();
        TextAdjustment.ReplaceUnderscores(location);
        int level = 1;



        string s = "Saved on " + saveDate + " at " + saveTime + "\n" + location + ". Level " + level;
        return s;
    }

    public void LoadTimesSavedOnSlot(string saveName, int slotNumber)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + saveName, FileMode.Open);
        SaveGameData data = (SaveGameData)bf.Deserialize(file);
        file.Close();

        if (slotNumber == 1)
        {
            WorldEvents.SavedOnSlot1 = data.SavesNoSlot1;

        }
        else if (slotNumber == 2)
        {
            WorldEvents.SavedOnSlot2 = data.SavesNoSlot2;
        }

        else if (slotNumber == 3)
        {
            WorldEvents.SavedOnSlot3 = data.SavesNoSlot3;

        }

        else if (slotNumber == 4)
        {
       //     Debug.Log("data 4: " + data.SavesNoSlot4 + " world events: " + WorldEvents.SavedOnSlot4);
            WorldEvents.SavedOnSlot4 = data.SavesNoSlot4;
//            Debug.Log("data: " + data.SavesNoSlot4 + " world events: " + WorldEvents.SavedOnSlot4);

        }
    }

    public string FindSavePath(int slot)
    {
        string saveSlotName = "";
        if (slot == 1)
            saveSlotName = "/demo2Slot1.dat";
        else if (slot == 2)
            saveSlotName = "/demo2Slot2.dat";
        else if (slot == 3)
            saveSlotName = "/demo2Slot3.dat";
        else if (slot == 4)
            saveSlotName = "/demo2Slot4.dat";
        else
            Debug.Log("Trying to save to unknown slot " + slot);

        return saveSlotName;
    }

    public string FindLoadPath(int slot)
    {
        string loadSlotName = "";
        if (slot == 1)
            loadSlotName = "/demo2Slot1.dat";
        else if (slot == 2)
            loadSlotName = "/demo2Slot2.dat";
        else if (slot == 3)
            loadSlotName = "/demo2Slot3.dat";
        else if (slot == 4)
            loadSlotName = "/demo2Slot4.dat";
        else
            Debug.Log("Trying to load unknown slot " + slot);

        return loadSlotName;
    }
    
    private void saveInventoryData(SaveGameData data)
    {
        SaveInventoryData saveInventory = new SaveInventoryData();

        saveInventory.SaveInventory(data);
    }

    public void LoadInventoryItemsFromMainMenu(int slot)
    {
        string loadSlotName = FindLoadPath(slot);

        if (File.Exists(Application.persistentDataPath + loadSlotName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + loadSlotName, FileMode.Open);
            SaveGameData data = (SaveGameData)bf.Deserialize(file);
            file.Close();

            Debug.LogWarning("load inventory stuff");

            LoadInventoryData loadInventory = new LoadInventoryData();
            loadInventory.LoadInventory(data);
        }
    }

    private void loadInventoryItemsInGame(SaveGameData data)
    {       
        Inventory.Instance.MakeAllSlotsEmpty();

        Debug.LogWarning("load inventory stuff");

        LoadInventoryData loadInventory = new LoadInventoryData();
        loadInventory.LoadInventory(data);
    }

    private void saveWorldEvents(SaveGameData data)
    {
        Debug.Log("saving world events");

        //spoke to characters
        data.PassedIntroduction = WorldEvents.PassedIntroduction ;
        data.SpokeToAy = WorldEvents.SpokeToAy;
        data.SpokeToMrB = WorldEvents.SpokeToMrB;
        data.SpokeToObstructor = WorldEvents.SpokeToObstructor;
        data.SpokeToOpposita = WorldEvents.SpokeToOpposita;

        //after golden screech
        data.IsAfterGoldenScreech = WorldEvents.IsAfterGoldenScreech;
        data.NeedsToKnowWhatSacrificeIs = WorldEvents.NeedsToKnowWhatSacrificeIs;
        data.KnowsWhatSacrificeIs = WorldEvents.KnowsWhatSacrificeIs;

        //opposita and getting the gallery key
        data.BlewUpMisterB = WorldEvents.BlewUpMisterB;
        data.OppositaIsCrying = WorldEvents.OppositaIsCrying;
        data.OppositaRevealedScissors = WorldEvents.OppositaRevealedScissors;

        //gallery
        data.LookingForGalleryVisitors = WorldEvents.LookingForGalleryVisitors;
        data.PeopleNotGoingToGallery = WorldEvents.PeopleNotGoingToGallery;

        data.OpenedGate = WorldEvents.OpenedGate;

        data.AskedAyAboutGallery = WorldEvents.AskedAyAboutGallery;

        //Side Quests
        data.DecipheredSentinelsMessage = WorldEvents.DecipheredSentinelsMessage;
    
        //Items
        data.ReceivedBookOfMusicalWildlife = WorldEvents.ReceivedBookOfMusicalWildlife;
    }

    private void loadWorldEvents(SaveGameData data)
    {
        Debug.Log("loading world events");

        //spoke to characters
        WorldEvents.PassedIntroduction = data.PassedIntroduction;
        WorldEvents.SpokeToAy = data.SpokeToAy;
        WorldEvents.SpokeToMrB = data.SpokeToMrB;
        WorldEvents.SpokeToObstructor = data.SpokeToObstructor;
        WorldEvents.SpokeToOpposita = data.SpokeToOpposita;

        //after golden screech
        WorldEvents.IsAfterGoldenScreech = data.IsAfterGoldenScreech;
        WorldEvents.NeedsToKnowWhatSacrificeIs = data.NeedsToKnowWhatSacrificeIs;
        WorldEvents.KnowsWhatSacrificeIs = data.KnowsWhatSacrificeIs;


        //opposita and getting the gallery key
        WorldEvents.BlewUpMisterB = data.BlewUpMisterB;
        WorldEvents.OppositaIsCrying = data.OppositaIsCrying;
        WorldEvents.OppositaRevealedScissors = data.OppositaRevealedScissors;

        //gallery
        WorldEvents.LookingForGalleryVisitors = data.LookingForGalleryVisitors;
        WorldEvents.PeopleNotGoingToGallery = data.PeopleNotGoingToGallery;

        WorldEvents.OpenedGate = data.OpenedGate;

        WorldEvents.AskedAyAboutGallery = data.AskedAyAboutGallery;

        //Side Quests
        WorldEvents.DecipheredSentinelsMessage = data.DecipheredSentinelsMessage;

        //Items
        WorldEvents.ReceivedBookOfMusicalWildlife = data.ReceivedBookOfMusicalWildlife;

    }

    private void saveInGameObjects(SaveGameData data)
    {
   //     data.PickedUpCarrot = InGameObjectManager.PickedUpCarrot;
   //     data.PickedUpMaskOfMockery = InGameObjectManager.PickedUpMaskOfMockery;
    }

    private void loadInGameObjects(SaveGameData data)
    {
    //    InGameObjectManager.PickedUpCarrot = data.PickedUpCarrot;
    //    InGameObjectManager.PickedUpMaskOfMockery = data.PickedUpMaskOfMockery;
    }

    private void savePlayerState(SaveGameData data)
    {
        Debug.Log("saving player status");
        data.Rupee = GameManager.Instance.RupeeHeld;
        data.SaveDateTime = DateTime.Now;
        data.CurrentArea = AreaManager.CurrentArea;
    }

    private void loadPlayerState(SaveGameData data)
    {
        GameManager.Instance.OverrideMoney(data.Rupee);

        AreaManager.CurrentArea = data.CurrentArea;//TODO AREA DETERMINES THE LOCATION THE PLAYER REVIVES;

        Debug.Log("loaded player status: we have " + data.Rupee + " rupee");
    }

    private void saveGameSlotData(SaveGameData data, int slotNo)
    {
        if (slotNo == 1)
        {
            if ((WorldEvents.SavedOnSlot1 < 1))
                WorldEvents.SavedOnSlot1 = 1;
            else
            {
                WorldEvents.SavedOnSlot1 = WorldEvents.SavedOnSlot1 + 1;
            }

            data.SavesNoSlot1 = WorldEvents.SavedOnSlot1;
        }

        else if (slotNo == 2)
        {
            if ((WorldEvents.SavedOnSlot2 < 1))
                WorldEvents.SavedOnSlot2 = 1;
            else
            {
                WorldEvents.SavedOnSlot2 = WorldEvents.SavedOnSlot2 + 1;
            }

            data.SavesNoSlot2 = WorldEvents.SavedOnSlot2;
        }

        else if (slotNo == 3)
        {
            if ((WorldEvents.SavedOnSlot3 < 1))
                WorldEvents.SavedOnSlot3 = 1;
            else
            {
                WorldEvents.SavedOnSlot3 = WorldEvents.SavedOnSlot3 + 1;
            }

            data.SavesNoSlot3 = WorldEvents.SavedOnSlot3;
        }

        else if (slotNo == 4)
        {
            if ((WorldEvents.SavedOnSlot4 < 1))
                WorldEvents.SavedOnSlot4 = 1;
            else
            {
                WorldEvents.SavedOnSlot4 = WorldEvents.SavedOnSlot4 + 1;
            }

            data.SavesNoSlot4 = WorldEvents.SavedOnSlot4;
        }
    }

    private void loadGameSlotData(SaveGameData data)
    {
        WorldEvents.SavedOnSlot1 = data.SavesNoSlot1;
        WorldEvents.SavedOnSlot2 = data.SavesNoSlot2;
        WorldEvents.SavedOnSlot3 = data.SavesNoSlot3;
        WorldEvents.SavedOnSlot4 = data.SavesNoSlot4;
    }
}

