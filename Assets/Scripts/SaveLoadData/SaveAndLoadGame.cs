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
            if (GameManager.MyGameType == GameManager.GameType.LoadFromInGame)
            {
                Debug.Log("Load game from in-game");
                LoadGameIngame(data);  
            }
            else  
            {
                Debug.Log("Load game from main menu");
                LoadGameFromMainMenu();
            }

            //when we have loaded everything, fade screen to alpha
            GameManager.Instance.UICanvas.ScreenFader.ToAlpha = true;
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

    public void IsNotNewGame()
    {
        using (StreamWriter sw = new StreamWriter("NewGame.txt"))
        {
            // Add some text to the file.
            sw.Write("This is not a new game");
        }
    }

    public void CheckSaveSlots(int loadOrSave)
    {
        // load
        if (loadOrSave == 1)
        {
            Debug.Log("Load Game SHOW SLOT INFO");

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

        //save
        else if (loadOrSave == 2)
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
        else
            Debug.LogWarning("This must be a wrong value");
    }

    public string LoadGameSlotInfo(string saveName)
    {
        Debug.Log("get save slot info");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + saveName, FileMode.Open);
        SaveGameData data = (SaveGameData)bf.Deserialize(file);
        file.Close();

        string saveDate = data.SaveDateTime.ToString("MM-dd-yyyy");
        string saveTime = data.SaveDateTime.ToString("HH:mm");
        string location = Areas.Tea_House_Cafe.ToString();
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
            Debug.Log("data 1: " + data.SavesNoSlot1 + " world events: " + WorldEvents.SavedOnSlot1);
            WorldEvents.SavedOnSlot1 = data.SavesNoSlot1;
            Debug.Log("data: " + data.SavesNoSlot1 + " world events: " + WorldEvents.SavedOnSlot1);

        }
        else if (slotNumber == 2)
        {
            Debug.Log("data 2: " + data.SavesNoSlot2 + " world events: " + WorldEvents.SavedOnSlot2);
            WorldEvents.SavedOnSlot2 = data.SavesNoSlot2;
            Debug.Log("data: " + data.SavesNoSlot2 + " world events: " + WorldEvents.SavedOnSlot2);

        }

        else if (slotNumber == 3)
        {
            Debug.Log("data 3: " + data.SavesNoSlot3 + " world events: " + WorldEvents.SavedOnSlot3);
            WorldEvents.SavedOnSlot3 = data.SavesNoSlot3;
            Debug.Log("data: " + data.SavesNoSlot3 + " world events: " + WorldEvents.SavedOnSlot3);

        }

        else if (slotNumber == 4)
        {
            Debug.Log("data 4: " + data.SavesNoSlot4 + " world events: " + WorldEvents.SavedOnSlot4);
            WorldEvents.SavedOnSlot4 = data.SavesNoSlot4;
            Debug.Log("data: " + data.SavesNoSlot4 + " world events: " + WorldEvents.SavedOnSlot4);

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
        //foreach (Item item in Inventory.Instance.Items)
        //{
        //    Debug.LogWarning("I saved " + data.Carrot + " " + item.IType);

        //    if (item.IType == ItemType.RoughneckShot)
        //    {
        //        for (int i = 0; i < item.ItemAmount; i++)
        //        {
        //            data.RoughneckShot = data.RoughneckShot + 1;
        //        }
        //        Debug.LogWarning("I saved " + data.RoughneckShot + " " + item.IType);
        //    }
        //    else if (item.IType == ItemType.Carrot)
        //    {
        //        for (int i = 0; i < item.ItemAmount; i++)
        //        {
        //            data.Carrot = data.Carrot + 1;
        //        }
        //        Debug.LogWarning("I saved " + data.Carrot + " " + item.IType);
        //    }
        //}
    }

    public void LoadInventoryItemsFromMainMenu(int slot)
    {
        //string loadSlotName = FindLoadPath(slot);

        //if (File.Exists(Application.persistentDataPath + loadSlotName))
        //{
        //    BinaryFormatter bf = new BinaryFormatter();
        //    FileStream file = File.Open(Application.persistentDataPath + loadSlotName, FileMode.Open);
        //    SaveGameData data = (SaveGameData)bf.Deserialize(file);
        //    file.Close();

        //    for (int i = 0; i < data.RoughneckShot; i++)
        //    {
        //        Inventory.Instance.InitialiseInventoryItems.Add(1);
        //    }
        //    for (int i = 0; i < data.Carrot; i++)
        //    {
        //        Inventory.Instance.InitialiseInventoryItems.Add(2);
        //        Debug.Log("added " + data.Carrot + " " + ItemType.Carrot);
        //    }
        //    for (int i = 0; i < data.MaskOfMockery; i++)
        //    {
        //        Inventory.Instance.InitialiseInventoryItems.Add(3);
        //    }

        //    Inventory.Instance.LoadItemsFromSave();
        //}
    }

    private void loadInventoryItemsInGame(SaveGameData data)
    {       
        Inventory.Instance.InitialiseInventoryItems.Clear();
        Inventory.Instance.MakeAllSlotsEmpty();

        Debug.LogWarning("load inventory stuff");

        //for (int i = 0; i < data.RoughneckShot; i++)
        //{
        //    Inventory.Instance.InitialiseInventoryItems.Add(1);
        //}
        //for (int i = 0; i < data.Carrot; i++)
        //{
        //    Inventory.Instance.InitialiseInventoryItems.Add(2);
        //    Debug.Log("added " + data.Carrot + " " + ItemType.Carrot);
        //}
        //for (int i = 0; i < data.MaskOfMockery; i++)
        //{
        //    Inventory.Instance.InitialiseInventoryItems.Add(3);
        //}

  //      Inventory.Instance.LoadItemsFromSave();
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
    }

    private void loadPlayerState(SaveGameData data)
    {
        GameManager.Instance.OverrideMoney(data.Rupee);
        Debug.Log("loaded player status:" + data.Rupee + " rupee");
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

