using System.Collections.Generic;
using UnityEngine;

public class Obstructor : MonoBehaviour
{
    public static int CharacterSituation;
    public static Obstructor Instance;
    public Animator Animator;

    private static List<int> LastOptionsBefore17002 = new List<int>() { 17001 };
    private static List<int> LastOptionsBefore17005 = new List<int>() { 17001 };
    private static List<int> LastOptionsBefore17010 = new List<int>() { 17001 };
    private static List<int> LastOptionsBefore17015 = new List<int>() { 17001 };
    private static List<int> LastOptionsBefore17025 = new List<int>() { 17002, 17005, 17010, 17015, 17030, 17050 };
    private static List<int> LastOptionsBefore17030 = new List<int>() { 17002, 17005, 17010, 17015, 17025, 17040, 17050 };
    private static List<int> LastOptionsBefore17040 = new List<int>() { 17025, 17030, 17050 };
    private static List<int> LastOptionsBefore17050 = new List<int>() { 17002, 17005, 17010, 17015, 17025, 17030, 17040 };
    private static List<int> LastOptionsBefore17060 = new List<int>() { 17002, 17005, 17010, 17015, 17025, 17030, 17040, 17050 };


    private static Dictionary<int, List<int>> PrecedingOptions = new Dictionary<int, List<int>>()
    { 
        {17002, LastOptionsBefore17002},
        {17005, LastOptionsBefore17005},
        {17010, LastOptionsBefore17010},
        {17015, LastOptionsBefore17015},
        {17025, LastOptionsBefore17025},
        {17030, LastOptionsBefore17030},
        {17040, LastOptionsBefore17040},
        {17050, LastOptionsBefore17050},
        {17060, LastOptionsBefore17060},
    };

    public void Start()
    {
        Instance = this;

        Animator = GetComponentInChildren<Animator>();
    }

    public void StartDialogue()
    {
        DialogueManager.StartDialogueState(Character.Obstructor);
    }

    public void DialogueLineNumberToSituation(int optionID)   //the last line of dialogue determines which situation will follow
    {
        if (IsLastBefore(optionID, 17002))
            DialogueMenu.AddToDialogueOptions(17002);
        if (IsLastBefore(optionID, 17005))
            DialogueMenu.AddToDialogueOptions(17005);
        if (IsLastBefore(optionID, 17010))
            DialogueMenu.AddToDialogueOptions(17010);
        if (IsLastBefore(optionID, 17015))
            DialogueMenu.AddToDialogueOptions(17015);
        if (IsLastBefore(optionID, 17025))
            DialogueMenu.AddToDialogueOptions(17025);
        if (IsLastBefore(optionID, 17030))
            DialogueMenu.AddToDialogueOptions(17030);
        if (IsLastBefore(optionID, 17040) && DialogueManager.IsDialoguePassed(16025))
            DialogueMenu.AddToDialogueOptions(17040);
        if (IsLastBefore(optionID, 17050))
            DialogueMenu.AddToDialogueOptions(17050);
        if (IsLastBefore(optionID, 17060))
            DialogueMenu.AddToDialogueOptions(17060);

        switch (optionID)
        {
            //opening options
            case 1:
                FindDialogueSituation(1);
                break;
            default:
                FindDialogueSituation(0);
                break;
        }
    }

    public void FindDialogueSituation(int dialogueSituation)
    {
        CharacterControllerLogic.Instance.GoToTalkingState();

        switch (dialogueSituation)
        {
            case 1: //SITUATION 1
                if(WorldEvents.SpokeToObstructor)
                {
                    AddToDialogue(17070);
                    AddToDialogue(17071);
                    AddToDialogue(17072);

                    DialoguePlayback.EndingDialogue = true;

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(17070);
                }
                else
                {
                    AddToDialogue(17001);

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(17001);
                }

                break;
            default: //in all other dialogue options
                DialogueMenu.FindVisibleDialogueOptions(Character.Obstructor);
                break;
        }
    }

    public static void TriggerDialogue(int dialogueOptionID)
    {
        if (dialogueOptionID == 17002)
        {
            AddToDialogue(17002);
            AddToDialogue(17003);
            AddToDialogue(17019);
            AddToDialogue(17020);
            AddToDialogue(17021);
            AddToDialogue(17022);
            AddToDialogue(17023);
            AddToDialogue(17024);
        }

        if (dialogueOptionID == 17005)
        {
            AddToDialogue(17005);
            AddToDialogue(17006);
            AddToDialogue(17007);
            AddToDialogue(17008);
            AddToDialogue(17019);
            AddToDialogue(17020);
            AddToDialogue(17021);
            AddToDialogue(17022);
            AddToDialogue(17023);
            AddToDialogue(17024);
        }

        if (dialogueOptionID == 17010)
        {
            AddToDialogue(17010);
            AddToDialogue(17011);
            AddToDialogue(17012);
            AddToDialogue(17013);
            AddToDialogue(17019);
            AddToDialogue(17020);
            AddToDialogue(17021);
            AddToDialogue(17022);
            AddToDialogue(17023);
            AddToDialogue(17024);
        }

        if (dialogueOptionID == 17015)
        {
            AddToDialogue(17015);
            AddToDialogue(17016);
            AddToDialogue(17017);
            AddToDialogue(17018);
            AddToDialogue(17019);
            AddToDialogue(17020);
            AddToDialogue(17021);
            AddToDialogue(17022);
            AddToDialogue(17023);
            AddToDialogue(17024);
        }

        if (dialogueOptionID == 17025)
        {
            DialoguePlayback.DeleteLineID = 17025;

            AddToDialogue(17025);
            AddToDialogue(17026);
            AddToDialogue(17027);
            AddToDialogue(17028);
        }

        if (dialogueOptionID == 17030)
        {
            DialoguePlayback.DeleteLineID = 17030;

            AddToDialogue(17030);
            AddToDialogue(17031);
            AddToDialogue(17032);
            AddToDialogue(17033);
            AddToDialogue(17034);
            AddToDialogue(17035);
        }

        if (dialogueOptionID == 17040)
        {
            DialoguePlayback.DeleteLineID = 17040;
            
            AddToDialogue(17040);
            AddToDialogue(17041);
            AddToDialogue(17042);
            AddToDialogue(17043);
            AddToDialogue(17044);
            AddToDialogue(17045);
        }

        if (dialogueOptionID == 17050)
        {
            DialoguePlayback.DeleteLineID = 17050;

            AddToDialogue(17051);
            AddToDialogue(17052);
        }

        if (dialogueOptionID == 17060)
        {
            AddToDialogue(17060);
            AddToDialogue(17061);

            DialoguePlayback.EndingDialogue = true;
        }
    }

    private static void AddToDialogue(int dialogueID)
    {
        Debug.Log("Adding to dialogue: " + dialogueID);
        DialoguePlayback.AddToDialogue(dialogueID);
    }

    private bool IsLastBefore(int lastLine, int dialogueOptionID)
    {
        if (PrecedingOptions[dialogueOptionID].Contains(lastLine))
            return true;

        return false;
    }
}
