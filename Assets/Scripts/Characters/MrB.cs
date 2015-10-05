using System.Collections.Generic;
using UnityEngine;

public class MrB : MonoBehaviour
{
    public static int CharacterSituation;
    public static MrB Instance;
    public Animator Animator;

    private static List<int> LastOptionsBefore16010 = new List<int>() { 16001 };
    private static List<int> LastOptionsBefore16011 = new List<int>() { 16001 };
    private static List<int> LastOptionsBefore16012 = new List<int>() { 16001 };
    private static List<int> LastOptionsBefore16022 = new List<int>() { 16010, 16011, 16012 };
    private static List<int> LastOptionsBefore16024 = new List<int>() { 16010, 16011, 16012 };
    private static List<int> LastOptionsBefore16026 = new List<int>() { 16010, 16011, 16012 };

    private static List<int> LastOptionsBefore16040 = new List<int>() { 16034, 16085, 16090, 16100, 16110, 16115, 16120 };
    private static List<int> LastOptionsBefore16055 = new List<int>() { 16034, 16040, 16085, 16090, 16100, 16110, 16115, 16120 };
    private static List<int> LastOptionsBefore16065 = new List<int>() { 16034, 16055, 16080, 16085, 16090, 16100, 16110, 16115, 16120 };
    private static List<int> LastOptionsBefore16075 = new List<int>() { 16034, 16065, 16075, 16085, 16090, 16100, 16110, 16115, 16120 };
    private static List<int> LastOptionsBefore16080 = new List<int>() { 16034, 16085, 16090, 16100, 16110, 16115, 16120 };
    private static List<int> LastOptionsBefore16085 = new List<int>() { 16034, 16090, 16100, 16110, 16115, 16120 };
    private static List<int> LastOptionsBefore16090 = new List<int>() { 16034, 16040, 16055, 16065, 16075, 16080, 16085, 16100, 16110, 16115, 16120 };
    private static List<int> LastOptionsBefore16100 = new List<int>() { 16034, 16040, 16055, 16065, 16075, 16080, 16085, 16090, 16110, 16115, 16120 };
    private static List<int> LastOptionsBefore16110 = new List<int>() { 16034, 16040, 16055, 16065, 16075, 16080, 16085, 16090, 16100, 16115, 16120 };
    private static List<int> LastOptionsBefore16120 = new List<int>() { 16034, 16040, 16055, 16065, 16075, 16080, 16085, 16090, 16100, 16110, 16115 };

    private static Dictionary<int, List<int>> PrecedingOptions = new Dictionary<int, List<int>>()
    { 
        {16010, LastOptionsBefore16010},
        {16011, LastOptionsBefore16011},
        {16012, LastOptionsBefore16012},
        {16022, LastOptionsBefore16022},
        {16024, LastOptionsBefore16024},
        {16026, LastOptionsBefore16026},

        {16040, LastOptionsBefore16040},
        {16055, LastOptionsBefore16055},
        {16065, LastOptionsBefore16065},
        {16075, LastOptionsBefore16075},
        {16080, LastOptionsBefore16080},
        {16085, LastOptionsBefore16085},
        {16090, LastOptionsBefore16090},
        {16100, LastOptionsBefore16100},
        {16110, LastOptionsBefore16110},
        {16120, LastOptionsBefore16120},

    };

    public void Start()
    {
        Instance = this;

        Animator = GetComponentInChildren<Animator>();
    }

    public void StartDialogue()
    {
        DialogueManager.StartDialogueState(Character.MrB, 0);
    }

    public void DialogueLineNumberToSituation(int optionID)   //the last line of dialogue determines which situation will follow
    {

        if (IsLastBefore(optionID, 16010))
            DialogueMenu.AddToDialogueOptions(16010);
        if (IsLastBefore(optionID, 16011))
            DialogueMenu.AddToDialogueOptions(16011);
        if (IsLastBefore(optionID, 16012))
            DialogueMenu.AddToDialogueOptions(16012);
        if (IsLastBefore(optionID, 16022))
            DialogueMenu.AddToDialogueOptions(16022);
        if (IsLastBefore(optionID, 16024))
            DialogueMenu.AddToDialogueOptions(16024);
        if (IsLastBefore(optionID, 16026))
            DialogueMenu.AddToDialogueOptions(16026);
        if (IsLastBefore(optionID, 16040) && !WorldEvents.IsAfterGoldenScreech)
            DialogueMenu.AddToDialogueOptions(16040);
        if (IsLastBefore(optionID, 16055) && DialogueManager.IsDialoguePassed(16040) && DialogueManager.IsDialoguePassed(16080))
            DialogueMenu.AddToDialogueOptions(16055);
        if (IsLastBefore(optionID, 16065) && (DialogueManager.IsDialoguePassed(16055) && DialogueManager.IsDialoguePassed(16080)))
            DialogueMenu.AddToDialogueOptions(16065);
        if (IsLastBefore(optionID, 16075) && DialogueManager.IsDialoguePassed(16065))
            DialogueMenu.AddToDialogueOptions(16075);
        if (IsLastBefore(optionID, 16080) && DialogueManager.IsDialoguePassed(12230))
            DialogueMenu.AddToDialogueOptions(16080);
        if (IsLastBefore(optionID, 16085) && WorldEvents.NeedsToKnowWhatSacrificeIs && DialogueManager.IsDialoguePassed(16080))
            DialogueMenu.AddToDialogueOptions(16085);
        if (IsLastBefore(optionID, 16090))
            DialogueMenu.AddToDialogueOptions(16090);
        if (IsLastBefore(optionID, 16100) && DialogueManager.IsDialoguePassed(13001))       //benny is not pleased
            DialogueMenu.AddToDialogueOptions(16100);
        if (IsLastBefore(optionID, 16110) && WorldEvents.SpokeToOpposita)
            DialogueMenu.AddToDialogueOptions(16110);
        if (IsLastBefore(optionID, 16120))                                                  // exit
            DialogueMenu.AddToDialogueOptions(16120);

        switch (optionID)
        {
            //opening options
            case 1:
                FindDialogueSituation(1);
                break;
            case 2:
                FindDialogueSituation(2);
                break;
            case 3:
                FindDialogueSituation(3);
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
                AddToDialogue(16001);
                AddToDialogue(16002);
                AddToDialogue(16003);
                AddToDialogue(16004);
                AddToDialogue(16005);
                AddToDialogue(16006);
                AddToDialogue(16007);

                DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(16001);

                break;
            case 2: //SITUATION 2
                if (WorldEvents.LookingForGalleryVisitors)
                {
                    AddToDialogue(16034);
                    AddToDialogue(16035);
                    AddToDialogue(16036);
                    AddToDialogue(16037);
                    AddToDialogue(16038);
                    AddToDialogue(16039);

                    WorldEvents.LookingForGalleryVisitors = false;

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(16034);
                }
                else
                {
                    AddToDialogue(16115);
                    AddToDialogue(16116);
                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(16115);
                    Debug.Log("Has passed 16065?? " + DialogueManager.IsDialoguePassed(16065));

                }
                break;
            case 3: //SITUATION 3

                AddToDialogue(16200);
                AddToDialogue(16201);
                AddToDialogue(16202);
                AddToDialogue(16203);

                DialoguePlayback.EndingDialogue = true;

                DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(16200);

                break;
            default: //in all other dialogue options
                DialogueMenu.FindVisibleDialogueOptions(Character.MrB);
                break;
        }
    }

    public static void TriggerDialogue(int dialogueOptionID)
    {
        if (dialogueOptionID == 16010)
        {
            AddToDialogue(16010);
            AddToDialogue(16014);
            AddToDialogue(16015);
            AddToDialogue(16016);
            AddToDialogue(16017);
            AddToDialogue(16018);
            AddToDialogue(16019);
            AddToDialogue(16020);
            AddToDialogue(16021);
        }

        if (dialogueOptionID == 16011)
        {
            AddToDialogue(16011);
            AddToDialogue(16014);
            AddToDialogue(16015);
            AddToDialogue(16016);
            AddToDialogue(16017);
            AddToDialogue(16018);
            AddToDialogue(16019);
            AddToDialogue(16020);
            AddToDialogue(16021);
        }

        if (dialogueOptionID == 16012)
        {
            AddToDialogue(16013);
            AddToDialogue(16014);
            AddToDialogue(16015);
            AddToDialogue(16016);
            AddToDialogue(16017);
            AddToDialogue(16018);
            AddToDialogue(16019);
            AddToDialogue(16020);
            AddToDialogue(16021);
        }

        if (dialogueOptionID == 16022)
        {
            AddToDialogue(16022);
            AddToDialogue(16023);
            AddToDialogue(16028);
            AddToDialogue(16029);
            AddToDialogue(16030);

            WorldEvents.SpokeToMrB = true;
            WorldEvents.LookingForGalleryVisitors = true;
            DialoguePlayback.EndingDialogue = true;
        }

        if (dialogueOptionID == 16024)
        {
            AddToDialogue(16024);
            AddToDialogue(16025);
            AddToDialogue(16028);
            AddToDialogue(16029);
            AddToDialogue(16030);

            WorldEvents.SpokeToMrB = true;
            WorldEvents.LookingForGalleryVisitors = true;
            DialoguePlayback.EndingDialogue = true;
        }

        if (dialogueOptionID == 16026)
        {
            AddToDialogue(16026);
            AddToDialogue(16027);
            AddToDialogue(16028);
            AddToDialogue(16029);
            AddToDialogue(16030);

            WorldEvents.SpokeToMrB = true;
            WorldEvents.LookingForGalleryVisitors = true;
            DialoguePlayback.EndingDialogue = true;
        }

        if (dialogueOptionID == 16040)
        {
            DialoguePlayback.DeleteLineID = 16040;

            AddToDialogue(16040);

            DialoguePlayback.DeleteLineID = 16080;

            AddToDialogue(16041);
            AddToDialogue(16042);
            AddToDialogue(16043);
            AddToDialogue(16044);
            AddToDialogue(16045);
            AddToDialogue(16046);
            AddToDialogue(16047);
            AddToDialogue(16048);

            WorldEvents.IsAfterGoldenScreech = true;

        }

        if (dialogueOptionID == 16055)
        {
            DialoguePlayback.DeleteLineID = 16055;

            AddToDialogue(16055);
            AddToDialogue(16056);
            AddToDialogue(16057);
            AddToDialogue(16058);
            AddToDialogue(16059);
            AddToDialogue(16060);
            AddToDialogue(16061);
        }

        if (dialogueOptionID == 16065)
        {
            DialoguePlayback.DeleteLineID = 16065;

            AddToDialogue(16065);

            DialoguePlayback.DeleteLineID = 16055;

            AddToDialogue(16066);

            DialoguePlayback.DeleteLineID = 16080;

            AddToDialogue(16067);
            AddToDialogue(16068);
            AddToDialogue(16069);
            AddToDialogue(16070);
        }

        if (dialogueOptionID == 16075)
        {
            AddToDialogue(16075);
            AddToDialogue(16076);
        }

        if (dialogueOptionID == 16080)
        {
            DialoguePlayback.DeleteLineID = 16080;

            AddToDialogue(16080);

            DialoguePlayback.DeleteLineID = 16040;

            AddToDialogue(16081);
            AddToDialogue(16082);
            AddToDialogue(16083);
        }

        if (dialogueOptionID == 16085)
        {
            AddToDialogue(16085);
            AddToDialogue(16086);
        }

        if (dialogueOptionID == 16090)
        {
            DialoguePlayback.DeleteLineID = 16090;

            AddToDialogue(16090);
            AddToDialogue(16091);
        }

        if (dialogueOptionID == 16100)
        {
            DialoguePlayback.DeleteLineID = 16100;

            AddToDialogue(16100);
            AddToDialogue(16101);
            AddToDialogue(16102);
        }

        if (dialogueOptionID == 16110)
        {
            DialoguePlayback.DeleteLineID = 16110;

            AddToDialogue(16110);
            AddToDialogue(16111);
            AddToDialogue(16112);
        }

        if (dialogueOptionID == 16120)
        {
            AddToDialogue(16120);

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
