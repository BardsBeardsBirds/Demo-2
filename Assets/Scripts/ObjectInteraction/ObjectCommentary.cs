using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class ObjectCommentary
{
    public static int CurrentID = 0;
    public static bool AskingLute = false;
    public static int ChangeIndex = 0;
    public static string ChangeLine = "";

    public static List<int> CurrentDialogueIDs = new List<int>();

    public static IEnumerator LetsGetCloserRoutine()
    {
        DialogueManager.ThisDialogueType = DialogueType.ObjectInteraction;

        int id = 7078;

        DialoguePlayback.Instance.SetCurrentDialogueLine(GameManager.ObjectInteractionDialogue[id].Text);

        DialoguePlayback.Instance.ShowDialogueLines();

        string audioFile = "ObjectInteraction/" + id;
        AudioManager.Instance.PlayDialogueAudio(audioFile);

        EndObjectCommentary();
        CharacterControllerLogic.Instance.GoToTalkingLastLineState();

        float timerLength = (float)ObjectInteractionTimer.AudioClipLength;
        yield return new WaitForSeconds(timerLength);   
    }

    public static IEnumerator CommentaryRoutine(DialogueType dialogueType, ObjectsInLevel objectInLevel)  //object in the world
    {
        DialogueManager.ThisDialogueType = dialogueType;

        FindLines(dialogueType, objectInLevel);

        for (int i = 0; i < CurrentDialogueIDs.Count; i++)
        {
            var id = CurrentDialogueIDs[i];
            CurrentID = id;
            Debug.Log(dialogueType + " " + id);
            if (dialogueType == DialogueType.ObjectInvestigation)
            {
                DialoguePlayback.Instance.SetCurrentDialogueLine(GameManager.ObjectInvestigationDialogue[id].Text);
            }
            else if (dialogueType == DialogueType.ObjectInteraction)
            {
                DialoguePlayback.Instance.SetCurrentDialogueLine(GameManager.ObjectInteractionDialogue[id].Text);
            }

            DialoguePlayback.Instance.ShowDialogueLines();


            int audioId = CheckUniqueAudio(id);
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

    public static void FindLines(DialogueType dialogueType, ObjectsInLevel objectInLevel)
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
    private static void FindInvestigationLines(ObjectsInLevel objectInLevel)
    {
        switch (objectInLevel)
        {
            case ObjectsInLevel.Null:
                Debug.Log("this object is null");
                break;
            case ObjectsInLevel.AyTheTearCollector:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.Bart:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.BennyTwospoons:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.LeonTurmeric:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.MadameOpposita:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.MrB:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.Obstructor:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.Sentinel:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.AysMagicDynamiteShake:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.Axe: 
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.Brush:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.BrushWithPaint:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.BucketWithPaint:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.ClownMask:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.ClownNose:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.CupOfCoffee:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.CupOfTea:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.GalleryKey:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.Hammer:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.MaskRemains:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.PartyHat:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.Purse:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.RoughneckShot:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.Scissors:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.SelfMadeMask:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.SpeakingTrumpet:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.TeaLeaves:
                CurrentDialogueIDs.Add(20000);
                break;
            case ObjectsInLevel.CopperBowl:
                CurrentDialogueIDs.Add(20000);
                break;
            default:
                Debug.Log("this object is null");
                break;
        }
    }

    private static void FindInteractionLines(ObjectsInLevel objectInLevel)
    {
        switch (objectInLevel)
        {
            case ObjectsInLevel.Null:
                Debug.Log("this object is null");
                break;
            case ObjectsInLevel.AyTheTearCollector:
                AyTheTearCollector.Instance.StartDialogue();
                break;
            case ObjectsInLevel.Bart:
                if (WorldEvents.SpokeToMrB && WorldEvents.PeopleNotGoingToGallery < 2 && WorldEvents.LookingForGalleryVisitors)
                {
                    //should say: I should ask people to go to the galery
                    CurrentDialogueIDs.Add(21000);
                }
                else if(WorldEvents.EndCelebration)
                {
                    //should say: he is performing. Let's not disturb him
                    CurrentDialogueIDs.Add(21000);
                }
                else
                BartTumblescream.Instance.StartDialogue();
                break;
            case ObjectsInLevel.BennyTwospoons:
                BennyTwospoons.Instance.StartDialogue();
                break;
            case ObjectsInLevel.LeonTurmeric:
                LeonTurmeric.Instance.StartDialogue();
                break;
            case ObjectsInLevel.MadameOpposita:
                MadameOpposita.Instance.StartDialogue();
                break;
            case ObjectsInLevel.MrB:
                MrB.Instance.StartDialogue();
                break;
            case ObjectsInLevel.Obstructor:
                Obstructor.Instance.StartDialogue();
                break;
            case ObjectsInLevel.Sentinel:
                Sentinel.Instance.StartDialogue();
                break;
            case ObjectsInLevel.AysMagicDynamiteShake:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.Axe:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.Brush:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.BrushWithPaint:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.BucketWithPaint:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.ClownMask:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.ClownNose:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.CupOfCoffee:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.CupOfTea:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.GalleryKey:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.Hammer:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.MaskRemains:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.PartyHat:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.Purse:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.RoughneckShot:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.Scissors:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.SelfMadeMask:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.SpeakingTrumpet:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.TeaLeaves:
                CurrentDialogueIDs.Add(21000);
                break;
            case ObjectsInLevel.CopperBowl:
                CurrentDialogueIDs.Add(21000);
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