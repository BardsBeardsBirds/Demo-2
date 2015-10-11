using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCombinations
{
    public static int LastLineID = 0;
    public static int CurrentID = 0;

    private static bool _putItemBack = false;   // this bool should be set to true if we make a combination that triggers a special reaction, which makes us loose our dragged item and put it back in the inventory. Should not be used when we loose the item in the combination.

    public static List<int> CurrentDialogueIDs = new List<int>();

    int[] randomNos = new int[] { 9001, 9002, 9003, 9004, 9005 };

    public bool CombineItems(Item inventoryItem, InWorldObject worldObject)    //inventory items with world
    {
        _putItemBack = false;

        Debug.Log("try to use " + inventoryItem.ItemName + " with " + worldObject);
        DialoguePlayback.Instance.PlaybackCombineItemsWithWorld(inventoryItem, worldObject);

        return _putItemBack;
    }

    public bool CombineItems(Item inventoryItem, Item subjectedItem)            //inventory items with other inventory items
    {
        _putItemBack = false;
        Debug.Log("try to use " + inventoryItem.ItemName + " with " + subjectedItem.ItemName);
        DialoguePlayback.Instance.PlaybackCombineItemsInventory(inventoryItem, subjectedItem);

        return _putItemBack;
    }


    public IEnumerator CombineItemRoutine(Item inventoryItem, InWorldObject worldObject)    //inventory items with world
    {
        DialogueManager.ThisDialogueType = DialogueType.ItemWorldCombination;    //the tiype of dialogue will be overwritten later if the combination triggers the start of an npc dialogue
        bool isRandomNo = FindLines(inventoryItem, worldObject);
        CharacterControllerLogic.Instance.GoToTalkingState();

        if (CurrentDialogueIDs.Count == 0)
        {
            Debug.LogWarning("No dialogue lines set up for this situation. Zero in list!");
            CharacterControllerLogic.Instance.GoToIdleState();
            yield return new WaitForSeconds(1);
        }

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
        Debug.LogWarning("GO TO TALKING STATE");

        if (CurrentDialogueIDs.Count == 0)
        {
            Debug.LogWarning("No dialogue lines set up for this situation. Zero in list!");
            CharacterControllerLogic.Instance.GoToIdleState();
            yield return new WaitForSeconds(1);
        }

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

    private bool FindLines(Item inventoryItem, InWorldObject worldObject) // inventory with world
    {
        bool isRandomNo = false;
        switch (inventoryItem.IType)
        {
            case ItemType.AysMagicDynamiteShake:
                {
                    if (worldObject == InWorldObject.Teapot)
                    {
                        GameManager.Instance.MyInventory.DeleteDraggedItem();

                        WorldEvents.BlewUpMisterB = true;
                        Debug.Log("We blew up Mister B!");

                        InGameObjectManager.Instance.ItemEnablerGO.EnableItem(ItemType.Purse);
                        InGameObjectManager.Instance.ItemEnablerGO.EnableItem(ItemType.GalleryKey);

                    }
                    else
                        CurrentDialogueIDs.Add(22000);
                }
                break;
            case ItemType.AysSecretIngredients:
                {
                    if (worldObject == InWorldObject.AyTheTearCollector)
                    {
                        GameManager.Instance.MyInventory.DeleteDraggedItem();

                        Debug.Log("Give Ay his ingredients");

                        //start conversation with Ay somewhere

                    }
                    else
                        CurrentDialogueIDs.Add(22000);
                }
                break;
            case ItemType.GalleryKey:
                {
                    if (worldObject == InWorldObject.GalleryPrivateDoor)
                    {
                        GameManager.Instance.MyInventory.DeleteDraggedItem();
                        InGameObjectManager.Instance.ItemEnablerGO.EnableItem(ItemType.Brush);

                        Debug.Log("The gallery room is now open");
                    }
                    else
                        CurrentDialogueIDs.Add(22000);
                }
                break;
            case ItemType.MaskRemains:
                {
                    if (worldObject == InWorldObject.CopperBowl)
                    {
                        GameManager.Instance.MyInventory.DeleteDraggedItem();

                        Debug.Log("We put the mask remains in the copper bowl! That should please the obstructor");
                        GameManager.Instance.MyInventory.RemoveItem(ItemType.MaskRemains);
                        InGameObjectManager.Instance.GateDoor.OpenGateDoor();
                        WorldEvents.OpenedGate = true;
                    }
                    else
                        CurrentDialogueIDs.Add(22000);
                }
                break;
            case ItemType.TeaLeaves:
                {
                    if (worldObject == InWorldObject.MadameOpposita)
                    {
                        //GameManager.Instance.MyInventory.EndDragging(UIDrawer.DraggingFromSlotNo);

                        Debug.Log("Trigger dialogue in which Opposita starts crying");
                        MadameOpposita.Instance.StartDialogue(15420);
                   //     GameManager.Instance.MyInventory.HideDraggedItem();
                        GameManager.Instance.MyInventory.DeleteDraggedItem();

                    }
                    else
                        CurrentDialogueIDs.Add(22000);
                }
                break;


            default:
                CurrentDialogueIDs.Add(22000);
                break;
        }
        return isRandomNo;
    }

    private bool FindLines(Item inventoryItem, Item subjectedItem)  //inventory with inventory
    {
        bool isRandomNo = false;

        switch (inventoryItem.IType)
        {
            case ItemType.Brush:
                {
                    if (subjectedItem.IType == ItemType.BucketWithPaint)
                    {
                        GameManager.Instance.MyInventory.DeleteDraggedItem();
                        ItemManager.AddItem(ItemType.BrushWithPaint);
                    }
                    else
                    {
                        GetRandomNo();
                        isRandomNo = true;
                    }
                }
                break;
            case ItemType.BucketWithPaint:
                {
                    if (subjectedItem.IType == ItemType.Brush)
                    {
                        GameManager.Instance.MyInventory.DeleteDraggedItem();
                        GameManager.Instance.MyInventory.RemoveItem(ItemType.Brush);
                        ItemManager.AddItem(ItemType.BrushWithPaint);
                        ItemManager.AddItem(ItemType.BucketWithPaint);

                    }
                    else
                    {
                        GetRandomNo();
                        isRandomNo = true;
                    }
                }
                break;
            case ItemType.BrushWithPaint:
                {
                    if (subjectedItem.IType == ItemType.ClownMask)
                    {
                        _putItemBack = true;

                        GameManager.Instance.MyInventory.DeleteDraggedItem();
                        GameManager.Instance.MyInventory.RemoveItem(ItemType.ClownMask);
                        ItemManager.AddItem(ItemType.SelfMadeMask);
                    }
                    else
                    {
                        GetRandomNo();
                        isRandomNo = true;
                    }
                }
                break;
            case ItemType.ClownMask:
                {
                    if (subjectedItem.IType == ItemType.BrushWithPaint)
                    {
                        GameManager.Instance.MyInventory.DeleteDraggedItem();

                        GameManager.Instance.MyInventory.RemoveItem(ItemType.BrushWithPaint);
                        ItemManager.AddItem(ItemType.SelfMadeMask);
                    }
                    else
                    {
                        GetRandomNo();
                        isRandomNo = true;
                    }
                }
                break;
            case ItemType.SelfMadeMask:
                {
                    if (subjectedItem.IType == ItemType.Axe || subjectedItem.IType == ItemType.Hammer)
                    {                        

                        GameManager.Instance.MyInventory.RemoveItem(ItemType.Axe);
                        GameManager.Instance.MyInventory.RemoveItem(ItemType.Hammer);
                        GameManager.Instance.MyInventory.RemoveItem(ItemType.SelfMadeMask);
                        ItemManager.AddItem(ItemType.MaskRemains);
                    }
                    else
                    {
                        GetRandomNo();
                        isRandomNo = true;
                    }
                }
                break;
            case ItemType.Axe:
                {
                    if (subjectedItem.IType == ItemType.SelfMadeMask)
                    {
                        GameManager.Instance.MyInventory.DeleteDraggedItem();

                        GameManager.Instance.MyInventory.RemoveItem(ItemType.Axe);
                        GameManager.Instance.MyInventory.RemoveItem(ItemType.Hammer);
                        GameManager.Instance.MyInventory.RemoveItem(ItemType.SelfMadeMask);
                        ItemManager.AddItem(ItemType.MaskRemains);

                        InGameObjectManager.Instance.ItemEnablerGO.DisableItem(ItemType.Hammer);
                    }
                    else
                    {
                        GetRandomNo();
                        isRandomNo = true;
                    }
                }
                break;
            case ItemType.Hammer:
                {
                    if (subjectedItem.IType == ItemType.SelfMadeMask)
                    {
                        GameManager.Instance.MyInventory.DeleteDraggedItem();

                        GameManager.Instance.MyInventory.RemoveItem(ItemType.Axe);
                        GameManager.Instance.MyInventory.RemoveItem(ItemType.Hammer);
                        GameManager.Instance.MyInventory.RemoveItem(ItemType.SelfMadeMask);
                        ItemManager.AddItem(ItemType.MaskRemains);

                        InGameObjectManager.Instance.ItemEnablerGO.DisableItem(ItemType.Axe);
                    }
                    else
                    {
                        GetRandomNo();
                        isRandomNo = true;
                    }
                }
                break;
            case ItemType.PartyHat:
                {
                    if (subjectedItem.IType == ItemType.Scissors)
                    {
                        GameManager.Instance.MyInventory.DeleteDraggedItem();

                        ItemManager.AddItem(ItemType.SpeakingTrumpet);

                    }
                    else
                    {
                        GetRandomNo();
                        isRandomNo = true;
                    }
                }
                break;
            case ItemType.Scissors:
                {
                    if (subjectedItem.IType == ItemType.PartyHat)
                    {
                        GameManager.Instance.MyInventory.DeleteDraggedItem();
         
                        GameManager.Instance.MyInventory.RemoveItem(ItemType.PartyHat);

                        ItemManager.AddItem(ItemType.SpeakingTrumpet);
                    }
                    else
                    {
                        GetRandomNo();
                        isRandomNo = true;
                    }
                }
                break;
            default:
                CurrentDialogueIDs.Add(23000);
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
