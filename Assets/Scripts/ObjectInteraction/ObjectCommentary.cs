using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class ObjectCommentary
{
    //public static int CurrentID = 0;
    public static SpokenLine CurrentSpokenLine;
    public static bool AskingLute = false;
    public static int ChangeIndex = 0;
    public static string ChangeLine = "";

    public static List<int> CurrentDialogueIDs = new List<int>();

    public static IEnumerator LetsGetCloserRoutine()
    {
        DialogueManager.ThisDialogueType = DialogueType.ObjectInteraction;

        int id = 7078;

        SpokenLine spokenLine = GameManager.ObjectInteractionDialogue[id];

        DialogueColour.SetTextColour(spokenLine);

        DialoguePlayback.Instance.SetCurrentDialogueLine(spokenLine.Text);

        DialoguePlayback.Instance.ShowDialogueLines();

        string audioFile = "ObjectInteraction/" + spokenLine.ID;
        AudioManager.Instance.PlayDialogueAudio(audioFile);

        EndObjectCommentary();
        CharacterControllerLogic.Instance.GoToTalkingLastLineState();

        float timerLength = (float)ObjectInteractionTimer.AudioClipLength;
        yield return new WaitForSeconds(timerLength);   
    }

    public static IEnumerator CommentaryRoutine(DialogueType dialogueType, InWorldObject objectInLevel)  //object in the world
    {
        DialogueManager.ThisDialogueType = dialogueType;

        FindLines(dialogueType, objectInLevel);

        for (int i = 0; i < CurrentDialogueIDs.Count; i++)
        {
            CurrentSpokenLine = GameManager.ObjectInteractionDialogue[CurrentDialogueIDs[i]];
            SpokenLine spokenLine = CurrentSpokenLine;

            Debug.Log(dialogueType + " " + spokenLine.ID);

            if (dialogueType == DialogueType.ObjectInvestigation)
            {
                spokenLine = GameManager.ObjectInvestigationDialogue[spokenLine.ID];
                DialoguePlayback.Instance.SetCurrentDialogueLine(spokenLine.Text);
            }
            else if (dialogueType == DialogueType.ObjectInteraction)
            {
                spokenLine = GameManager.ObjectInteractionDialogue[spokenLine.ID];
                DialoguePlayback.Instance.SetCurrentDialogueLine(spokenLine.Text);
            }

            DialogueColour.SetTextColour(spokenLine);

            DialoguePlayback.Instance.ShowDialogueLines();

            int audioId = CheckUniqueAudio(spokenLine.ID);
            string audioFile = "ObjectInteraction/" + audioId;
            AudioManager.Instance.PlayDialogueAudio(audioFile);

            if (i + 1 == ObjectCommentary.CurrentDialogueIDs.Count)
            {
                CharacterControllerLogic.Instance.GoToTalkingLastLineState();
                EndObjectCommentary();
            }

            float timerLength = (float)ObjectInteractionTimer.AudioClipLength;
            yield return new WaitForSeconds(timerLength);
        }
    }

    public static void FindLines(DialogueType dialogueType, InWorldObject objectInLevel)
    {
        if (dialogueType == DialogueType.ObjectInvestigation)
            FindInvestigationLines(objectInLevel);
        else if (dialogueType == DialogueType.ObjectInteraction)
            FindInteractionLines(objectInLevel);     
    }

    private static void ClearDialogueList()
    {
        CurrentDialogueIDs.Clear();
    }

    private static void EndObjectCommentary()
    {
        ClearDialogueList();
    }

    #region ObjectLines
    private static void FindInvestigationLines(InWorldObject objectInLevel)
    {
        switch (objectInLevel)
        {
            case InWorldObject.Null:
                Debug.Log("this object is null");
                break;
            case InWorldObject.AyTheTearCollector:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.Bart:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.BennyTwospoons:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.LeonTurmeric:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.MadameOpposita:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.MrB:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.Obstructor:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.Sentinel:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.AysMagicDynamiteShake:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.Axe: 
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.BookOfMusicalWildlife:
                ItemManager.AddItem(ItemType.BookOfMusicalWildlife);
                //TODO: Add Special diaglogue                 
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.Brush:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.BrushWithPaint:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.BucketWithPaint:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.ClownMask:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.ClownNose:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.CupOfCoffee:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.CupOfTea:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.GalleryKey:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.Hammer:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.MaskRemains:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.PartyHat:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.Purse:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.RoughneckShot:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.Scissors:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.SelfMadeMask:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.SpeakingTrumpet:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.TeaLeaves:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.CopperBowl:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.GoldenScreech:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.GalleryPrivateDoor:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.ElevatorDoor1:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.ElevatorDoor2:
                CurrentDialogueIDs.Add(20000);
                break;
            case InWorldObject.ElevatorDoor3:
                CurrentDialogueIDs.Add(20000);
                break;
            default:
                Debug.Log("this object is null");
                break;
        }
    }

    private static void FindInteractionLines(InWorldObject objectInLevel)
    {
        switch (objectInLevel)
        {
            case InWorldObject.Null:
                Debug.Log("this object is null");
                break;
            case InWorldObject.AyTheTearCollector:
                AyTheTearCollector.Instance.StartDialogue();
                break;
            case InWorldObject.Bart:
                if (WorldEvents.SpokeToMrB && WorldEvents.PeopleNotGoingToGallery < 2 && WorldEvents.LookingForGalleryVisitors)
                {
                    //should say: I should ask people to go to the galery
                    CurrentDialogueIDs.Add(21002);
                }
                else if(WorldEvents.EndCelebration)
                {
                    //should say: he is performing. Let's not disturb him
                    CurrentDialogueIDs.Add(21201);
                }
                else
                    BartTumblescream.Instance.StartDialogue();
                break;
            case InWorldObject.BennyTwospoons:
                BennyTwospoons.Instance.StartDialogue();
                break;
            case InWorldObject.LeonTurmeric:
                LeonTurmeric.Instance.StartDialogue();
                break;
            case InWorldObject.MadameOpposita:
                MadameOpposita.Instance.StartDialogue();
                break;
            case InWorldObject.MrB:
                if (WorldEvents.LookingForGalleryVisitors && WorldEvents.PeopleNotGoingToGallery < 2)
                {
                    CurrentDialogueIDs.Add(21006);  // I should first find people
                }
                else
                    MrB.Instance.StartDialogue();
                break;
            case InWorldObject.Obstructor:
                Obstructor.Instance.StartDialogue();
                break;
            case InWorldObject.Sentinel:
                Sentinel.Instance.StartDialogue();
                break;
            case InWorldObject.AysMagicDynamiteShake:
                CurrentDialogueIDs.Add(21000);
                break;
            case InWorldObject.AysSecretIngredients:
                InGameObjectManager.Instance.TurnOffObject(InGameObjectManager.Instance.AysSecretIngredients);
                break;
            case InWorldObject.Axe:
                ItemManager.AddItem(ItemType.Axe);
                InGameObjectManager.Instance.TurnOffObject(InGameObjectManager.Instance.Axe);
                break;
            case InWorldObject.BookOfMusicalWildlife:
                //Add the book to 
                ItemManager.AddItem(ItemType.BookOfMusicalWildlife);
                //TODO: Add Special diaglogue 
                CurrentDialogueIDs.Add(21000);
                break;
            case InWorldObject.Brush:
                ItemManager.AddItem(ItemType.Brush);
                InGameObjectManager.Instance.TurnOffObject(InGameObjectManager.Instance.Brush);
                break;
            case InWorldObject.BrushWithPaint:
                CurrentDialogueIDs.Add(21000);
                break;
            case InWorldObject.BucketWithPaint:
                ItemManager.AddItem(ItemType.BucketWithPaint);
                InGameObjectManager.Instance.TurnOffObject(InGameObjectManager.Instance.Bucket);
                break;
            case InWorldObject.ClownMask:
                CurrentDialogueIDs.Add(21000);
                break;
            case InWorldObject.ClownNose:
                CurrentDialogueIDs.Add(21000);
                break;
            case InWorldObject.CupOfCoffee:
                CurrentDialogueIDs.Add(21000);
                break;
            case InWorldObject.CupOfTea:
                CurrentDialogueIDs.Add(21000);
                break;
            case InWorldObject.GalleryKey:
                ItemManager.AddItem(ItemType.GalleryKey);   //only if Mr B exploded
                InGameObjectManager.Instance.TurnOffObject(InGameObjectManager.Instance.GalleryKey);
                break;
            case InWorldObject.Hammer:
                ItemManager.AddItem(ItemType.Hammer);
                InGameObjectManager.Instance.TurnOffObject(InGameObjectManager.Instance.Hammer);
                break;
            case InWorldObject.MaskRemains:
                CurrentDialogueIDs.Add(21000);
                break;
            case InWorldObject.PartyHat:
                CurrentDialogueIDs.Add(21000);
                InGameObjectManager.Instance.TurnOffObject(InGameObjectManager.Instance.PartyHat);
                break;
            case InWorldObject.Purse:
                ItemManager.AddItem(ItemType.Purse);
                InGameObjectManager.Instance.TurnOffObject(InGameObjectManager.Instance.Purse);
                break;
            case InWorldObject.RoughneckShot:
                CurrentDialogueIDs.Add(21000);
                break;
            case InWorldObject.Scissors:
                if (WorldEvents.OppositaIsCrying)
                {
                    ItemManager.AddItem(ItemType.Scissors);
                    InGameObjectManager.Instance.TurnOffObject(InGameObjectManager.Instance.Scissors);
                }
                else
                {
                    CurrentDialogueIDs.Add(21000);
                    Debug.Log("Opposita watches over her scissors. You cannot take them.");
                }
                 break;
            case InWorldObject.SelfMadeMask:
                break;
            case InWorldObject.SpeakingTrumpet:
                break;
            case InWorldObject.TeaLeaves:
                ItemManager.AddItem(ItemType.TeaLeaves);
                InGameObjectManager.Instance.TurnOffObject(InGameObjectManager.Instance.TeaLeaves);
                break;
            case InWorldObject.CopperBowl:
                CurrentDialogueIDs.Add(21000);
                break;
            case InWorldObject.GoldenScreech:
                InGameObjectManager.Instance.TurnOffObject(InGameObjectManager.Instance.GoldenScreech);
                WorldEvents.EndCelebration = true;
                break;
            case InWorldObject.GalleryPrivateDoor:
                CurrentDialogueIDs.Add(21000);
                break;
            case InWorldObject.ElevatorDoor1:
                if (InGameObjectManager.Instance.ElevatorDoor1.IsOpen)
                    InGameObjectManager.Instance.ElevatorDoor1.CloseDoor();
                else
                    InGameObjectManager.Instance.ElevatorDoor1.OpenDoor();
                break;
            case InWorldObject.ElevatorDoor2:
                if (InGameObjectManager.Instance.ElevatorDoor2.IsOpen)
                    InGameObjectManager.Instance.ElevatorDoor2.CloseDoor();
                else
                    InGameObjectManager.Instance.ElevatorDoor2.OpenDoor();                
                break;
            case InWorldObject.ElevatorDoor3:
                if (InGameObjectManager.Instance.ElevatorDoor3.IsOpen)
                    InGameObjectManager.Instance.ElevatorDoor3.CloseDoor();
                else
                    InGameObjectManager.Instance.ElevatorDoor3.OpenDoor();
                break;
            case InWorldObject.ElevatorDoor4:
                if (InGameObjectManager.Instance.ElevatorDoor4.IsOpen)
                    InGameObjectManager.Instance.ElevatorDoor4.CloseDoor();
                else
                    InGameObjectManager.Instance.ElevatorDoor4.OpenDoor();
                break;
            case InWorldObject.ElevatorUp:
                ElevatorButton.Direction = ElevatorDirection.Up;
                InGameObjectManager.Instance.ElevatorUp.Pressed();
                break;
            case InWorldObject.ElevatorDown:
                ElevatorButton.Direction = ElevatorDirection.Down;
                InGameObjectManager.Instance.ElevatorDown.Pressed();
                break;
            default:
                Debug.Log("this object is null");
                break;
        }
    }
#endregion

    public static int CheckUniqueAudio(int id)
    {

        return id;
    }
}