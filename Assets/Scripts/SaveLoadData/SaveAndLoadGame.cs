using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveAndLoadGame
{
    public void SaveGameData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/demo1Progress.dat");

        SaveGameData data = new SaveGameData();

        savePlayerState(data);
        saveWorldEvents(data);
        saveInGameObjects(data);
        saveInventoryData(data);

        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadGameData()
    {
        if (File.Exists(Application.persistentDataPath + "/demo1Progress.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/demo1Progress.dat", FileMode.Open);
            SaveGameData data = (SaveGameData)bf.Deserialize(file);
            file.Close();

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

    public void LoadInventoryItemsFromMainMenu()
    {
        if (File.Exists(Application.persistentDataPath + "/demo1Progress.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/demo1Progress.dat", FileMode.Open);
            SaveGameData data = (SaveGameData)bf.Deserialize(file);
            file.Close();

            for (int i = 0; i < data.RoughneckShot; i++)
            {
                Inventory.Instance.InitialiseInventoryItems.Add(1);
            }
            for (int i = 0; i < data.Carrot; i++)
            {
                Inventory.Instance.InitialiseInventoryItems.Add(2);
                Debug.Log("added " + data.Carrot + " " + ItemType.Carrot);
            }
            for (int i = 0; i < data.MaskOfMockery; i++)
            {
                Inventory.Instance.InitialiseInventoryItems.Add(3);
            }

            Inventory.Instance.LoadItemsFromSave();
        }
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

    }

    private void loadWorldEvents(SaveGameData data)
    {
        Debug.Log("loading world events");

    }

    private void saveInGameObjects(SaveGameData data)
    {
        data.PickedUpCarrot = InGameObjectManager.PickedUpCarrot;
        data.PickedUpMaskOfMockery = InGameObjectManager.PickedUpMaskOfMockery;
    }

    private void loadInGameObjects(SaveGameData data)
    {
        InGameObjectManager.PickedUpCarrot = data.PickedUpCarrot;
        InGameObjectManager.PickedUpMaskOfMockery = data.PickedUpMaskOfMockery;
    }

    private void savePlayerState(SaveGameData data)
    {
        Debug.Log("saving player status");
        data.Rupee = GameManager.Instance.RupeeHeld;
    }

    private void loadPlayerState(SaveGameData data)
    {
        GameManager.Instance.OverrideMoney(data.Rupee);
        Debug.Log("loaded player status:" + data.Rupee + " rupee");

    }
}

