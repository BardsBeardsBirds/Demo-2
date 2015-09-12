using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCombinations
{
    public static int LastLineID = 0;
    public static int CurrentID = 0;

    private static bool _canMakeCombination = false;

    public static List<int> CurrentDialogueIDs = new List<int>();

    int[] randomNos = new int[] { 9001, 9002, 9003, 9004, 9005 };

    public bool CombineItems(Item inventoryItem, ObjectsInLevel worldObject)    //inventory items with world
    {
        _canMakeCombination = false;

        Debug.Log("try to use " + inventoryItem.ItemName + " with " + worldObject);
        DialoguePlayback.Instance.PlaybackCombineItemsWithWorld(inventoryItem, worldObject);
        _canMakeCombination = TryMakeComination(inventoryItem, worldObject);

        return _canMakeCombination;
    }

    private bool TryMakeComination(Item inventoryItem, ObjectsInLevel worldObject)  //inventory items with world
    {
        //if (inventoryItem.IType == ItemType.RoughneckShot)
        //{
        //    if (worldObject == ObjectsInLevel.Sentinel)
        //        _canMakeCombination = true;
        //}
        return _canMakeCombination;
    }

    public bool CombineItems(Item inventoryItem, Item subjectedItem)            //inventory items with other inventory items
    {
        _canMakeCombination = false;
        Debug.Log("try to use " + inventoryItem.ItemName + " with " + subjectedItem.ItemName);
        DialoguePlayback.Instance.PlaybackCombineItemsInventory(inventoryItem, subjectedItem);
        TryMakeComination(inventoryItem, subjectedItem);

        return _canMakeCombination;
    }

    private bool TryMakeComination(Item inventoryItem, Item subjectedItem)
    {
        return _canMakeCombination;
    }

    public IEnumerator CombineItemRoutine(Item inventoryItem, ObjectsInLevel worldObject)    //inventory items with world
    {
        DialogueManager.ThisDialogueType = DialogueType.ItemWorldCombination;    //the tiype of dialogue will be overwritten later if the combination triggers the start of an npc dialogue
        bool isRandomNo = FindLines(inventoryItem, worldObject);
        CharacterControllerLogic.Instance.GoToTalkingState();

        for (int i = 0; i < CurrentDialogueIDs.Count; i++)
        {
            var id = CurrentDialogueIDs[i];
            CurrentID = id;
            if (isRandomNo)
            {
                DialoguePlayback.Instance.SetCurrentDialogueLine(GameManager.RandomNoDialogue[id].Text);
            }
            else
            {
                DialoguePlayback.Instance.SetCurrentDialogueLine(GameManager.ItemWorldCombinationDialogue[id].Text);
            }

            DialoguePlayback.Instance.ShowDialogueLines();

            int audioId = CheckUniqueAudio(id);
            string audioFile = "ObjectInteraction/" + audioId;
            Debug.Log(audioFile);
            AudioManager.Instance.PlayDialogueAudio(audioFile);

            if (i + 1 == CurrentDialogueIDs.Count)
            {
                CharacterControllerLogic.Instance.GoToTalkingLastLineState();
                LastLineID = id;
                ClearDialogueList();
            }

            float timerLength = (float)ObjectInteractionTimer.AudioClipLength;
            yield return new WaitForSeconds(timerLength);
        }
    }

    public IEnumerator CombineItemRoutine(Item inventoryItem, Item subjectedItem)    //inventory items with other inventory items
    {
        DialogueManager.ThisDialogueType = DialogueType.InventoryCombination;
        bool isRandomNo = FindLines(inventoryItem, subjectedItem);
        CharacterControllerLogic.Instance.GoToTalkingState();

        for (int i = 0; i < CurrentDialogueIDs.Count; i++)
        {
            var id = CurrentDialogueIDs[i];
            CurrentID = id;

            if (isRandomNo)
            {
                Debug.Log("is random " + id);
                DialoguePlayback.Instance.SetCurrentDialogueLine(GameManager.RandomNoDialogue[id].Text);
            }
            else
            {
                DialoguePlayback.Instance.SetCurrentDialogueLine(GameManager.InventoryCombinationDialogue[id].Text);
            }

            DialoguePlayback.Instance.ShowDialogueLines();

            int audioId = CheckUniqueAudio(id);
            string audioFile = "ObjectInteraction/" + audioId;
            AudioManager.Instance.PlayDialogueAudio(audioFile);

            if (i + 1 == CurrentDialogueIDs.Count)
            {
                CharacterControllerLogic.Instance.GoToTalkingLastLineState();
                LastLineID = id;
                ClearDialogueList();
            }

            float timerLength = (float)ObjectInteractionTimer.AudioClipLength;
            yield return new WaitForSeconds(timerLength);
        }   
    }

    private bool FindLines(Item inventoryItem, ObjectsInLevel worldObject) // inventory with world
    {
        bool isRandomNo = false;
        switch (inventoryItem.IType)
        {
            
            default:
                break;
        }
        return isRandomNo;
    }

    private bool FindLines(Item inventoryItem, Item subjectedItem)  //inventory with inventory
    {
        bool isRandomNo = false;

        switch (inventoryItem.IType)
        {
            default:
                break;
        }
        return isRandomNo;
    }

    private void ClearDialogueList()
    {
        CurrentDialogueIDs.Clear();
    }

    public int CheckUniqueAudio(int id)
    {
        return id;
    }

    private void GetRandomNo()
    {
        int randomNo = RandomNo();

        DialogueManager.ThisDialogueType = DialogueType.RandomNo;
        CurrentDialogueIDs.Add(randomNo);
    }

    private int RandomNo()
    {
        int random = UnityEngine.Random.Range(0, randomNos.Length);
        return randomNos[random];
    }
}
