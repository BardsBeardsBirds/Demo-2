using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager
{
    public static DialogueType ThisDialogueType = DialogueType.None;
    public static Character CurrentDialogueNPC;

    public static List<int> PassedDialogueLines = new List<int>();

    public static void StartDialogueState(Character NPC)
    {
        CurrentDialogueNPC = NPC;

        GameManager.Instance.UICanvas.ShowDialogueOptionsUI();

        CharacterControllerLogic.Instance.GoToTalkingState();

        TimeManager.Instance.CreateRotator(GameManager.Player.transform, GameManager.NPCs[NPC], 4, 2);
        GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("DialogueState", true);

        DialoguePlayback.NPC = NPC;

        switch (NPC)
        {
            case Character.Ay:
                ThisDialogueType = DialogueType.AyDialogue;
                DialogueSituationSelector.LoadAySituations();
                break;
            case Character.Bart:
                ThisDialogueType = DialogueType.BartDialogue;
                DialogueSituationSelector.LoadBartSituations();
                break;
            case Character.Benny:
                ThisDialogueType = DialogueType.BennyDialogue;
                DialogueSituationSelector.LoadBennyTwospoonsSituations();
                break;
            case Character.Leon:
                ThisDialogueType = DialogueType.LeonDialogue;
                DialogueSituationSelector.LoadLeonTurmericSituations();
                break;
            case Character.MrB:
                ThisDialogueType = DialogueType.MrBDialogue;
                DialogueSituationSelector.LoadMrBSituations();
                break;
            case Character.Obstructor:
                ThisDialogueType = DialogueType.ObstructorDialogue;
                DialogueSituationSelector.LoadObstructorSituations();
                break;
            case Character.Opposita:
                ThisDialogueType = DialogueType.OppositaDialogue;
                DialogueSituationSelector.LoadMadameOppositaSituations();
                break;
            case Character.Sentinel:
                ThisDialogueType = DialogueType.SentinelDialogue;
                DialogueSituationSelector.LoadSentinelSituations();
                break;
            default:
                Debug.LogError("Who is this conversation partner?");
                break;
        }
        ThirdPersonCamera.Instance.CameraToDialoguePosition(NPC);
        Emmon.Instance.TriggerPlayerMove(NPC);
    }

    public static void EndDialogueState(Character NPC)
    {
        DialoguePlayback.Instance.HideDialogueLines();

        DialoguePlayback.ClearDialogueList();

        DialogueMenu.ClearDialogueOptionLists();

        ThisDialogueType = DialogueType.None;

        GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("DialogueState", false);
        GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("Talking", false);
        GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("Listening", false);

        GameManager.Instance.UICanvas.HideDialogueOptionsUI();
        ThirdPersonCamera.Instance.ReturnCameraToOldPosition();

        CharacterControllerLogic.Instance.EndTalkingState();
    }
    

    public static void NPCToListeningState(Character NPC)
    {
        GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("Talking", false);
        GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("Listening", true);
    }

    public static void AddToPassedDialogueLines(int id)
    {
        PassedDialogueLines.Add(id);
    }

    public static bool IsDialoguePassed(int id)
    {
        for (int i = 0; i < PassedDialogueLines.Count; i++)
        {
            if (id == PassedDialogueLines[i])
                return true;
        }
        return false;
    }
}
