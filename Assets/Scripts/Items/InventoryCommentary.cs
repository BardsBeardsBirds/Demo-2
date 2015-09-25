using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryCommentary
{
    public static int LastLineID = 0;
    public static int CurrentID = 0;

    public static List<int> CurrentDialogueIDs = new List<int>();

    public static IEnumerator InventoryCommentaryRoutine(DialogueType dialogueType, Item inventoryItem)
    {
        FindLines(dialogueType, inventoryItem);
        CharacterControllerLogic.Instance.GoToTalkingState();
        DialogueManager.ThisDialogueType = dialogueType;

        for (int i = 0; i < InventoryCommentary.CurrentDialogueIDs.Count; i++)
        {
            var id = CurrentDialogueIDs[i];
            CurrentID = id;

            if (dialogueType == DialogueType.InventoryInvestigation)
            {
                DialoguePlayback.Instance.SetCurrentDialogueLine(GameManager.InventoryInvestigationDialogue[id].Text);
            }
            else if (dialogueType == DialogueType.InventoryInteraction)
            {
                DialoguePlayback.Instance.SetCurrentDialogueLine(GameManager.InventoryInteractionDialogue[id].Text);
            }

            DialoguePlayback.Instance.ShowDialogueLines();

            string audioFile = "ObjectInteraction/" + id;
            AudioManager.Instance.PlayDialogueAudio(audioFile);


            if (i + 1 == InventoryCommentary.CurrentDialogueIDs.Count)
            {
                CharacterControllerLogic.Instance.GoToTalkingLastLineState();
                InventoryCommentary.LastLineID = id;
                ClearDialogueList();
            }

            float timerLength = (float)ObjectInteractionTimer.AudioClipLength;
            yield return new WaitForSeconds(timerLength);
        }
    }

    private static void FindLines(DialogueType dialogueType, Item inventoryItem)
    {
        if (dialogueType == DialogueType.InventoryInvestigation)
            FindInvestigationLines(inventoryItem);
        else if (dialogueType == DialogueType.InventoryInteraction)
            FindInteractionLines(inventoryItem);
    }

    private static void ClearDialogueList()
    {
        CurrentDialogueIDs.Clear();
    }

    #region ObjectLines
    private static void FindInvestigationLines(Item inventoryItem)
    {
        switch (inventoryItem.IType)
        {
            //case ItemType.RoughneckShot:
            //    CurrentDialogueIDs.Add(24001);
            //    break;
            //case ItemType.Carrot:
            //    CurrentDialogueIDs.Add(24002);
            //    break;
            //case ItemType.MaskOfMockery:
            //    CurrentDialogueIDs.Add(24003);
            //    break;
            default:
                CurrentDialogueIDs.Add(24003);
                Debug.LogWarning("Don't know this item: " + inventoryItem.IType);
                break;
        }
    }

    private static void FindInteractionLines(Item inventoryItem)
    {
        switch (inventoryItem.IType)
        {
            //case ItemType.RoughneckShot:
            //    CurrentDialogueIDs.Add(25001);
            //    break;
            //case ItemType.Carrot:
            //    CurrentDialogueIDs.Add(25002);
            //    break;
            //case ItemType.MaskOfMockery:
            //    CurrentDialogueIDs.Add(25003);
            //    break;
            default:
                CurrentDialogueIDs.Add(25000);
                Debug.LogWarning("Don't know this item: " + inventoryItem.IType);
                break;
        }
    }

    public static int FindInvestigationHoverLines(Item inventoryItem)
    {
        int id = 0;

        switch (inventoryItem.IType)
        {
            //case ItemType.RoughneckShot:
            //    id = 25001;
            //    break;
            //case ItemType.Carrot:
            //    id = 25002;
            //    break;
            //case ItemType.MaskOfMockery:
            //    id = 25001;
            //    break;
            default:
                id = 26000;
                Debug.LogWarning("Don't know this item: " + inventoryItem.IType);
                break;
        }
        return id;
    }

    public static int FindInteractionHoverLines(Item inventoryItem)
    {
        int id = 0;

        switch (inventoryItem.IType)
        {
            //case ItemType.RoughneckShot:
            //    id = 5301;
            //    break;
            //case ItemType.Carrot:
            //    id = 5302;
            //    break;
            //case ItemType.MaskOfMockery:
            //    id = 5303;
            //    break;
            default:
                id = 27000;
                Debug.LogWarning("Don't know this item: " + inventoryItem.IType);
                break;
        }
        return id;
    }
    #endregion
}
